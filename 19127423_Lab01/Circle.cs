using System;
using SharpGL;

namespace SharpGL_Application
{
    class Circle : BasicShape
    {
        public Circle(OpenGLControl GlControl)
        {
            this.GlControl = GlControl;
            Gl = GlControl.OpenGL;
            ListPointInput = new Coords[3];
        }

        #region Hình tròn
        // Hàm vẽ vẽ 8 điểm đối xứng qua các trục x = y, x = 0, y = 0 của 1 điểm cho trước
        private void draw8point(Coords centerPoint, int x, int y, int thickness)
        {
            Gl.Begin(OpenGL.GL_POINTS);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y + y, thickness);
            thicknessStroke(Gl, centerPoint.x + y, centerPoint.y + x, thickness);
            thicknessStroke(Gl, centerPoint.x + y, centerPoint.y - x, thickness);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - y, centerPoint.y - x, thickness);
            thicknessStroke(Gl, centerPoint.x - y, centerPoint.y + x, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y + y, thickness);
            Gl.End();
        }
        // Hàm vẽ đường tròn theo thuật toán midpoint
        private void DrawCircle(Coords centerPoint, int R, int thickness)
        {
            int p;
            int y = R;
            int x = 0;
            p = 3 - 2 * R;
            draw8point(centerPoint, x, y, thickness);
            while (x < y)
            {
                if (p < 0)
                    p += 4 * x + 6;
                else
                {
                    p += 4 * (x - y) + 10;
                    y--;
                }
                x++;
                draw8point(centerPoint, x, y, thickness);
            }
        }
        #endregion

        #region Hình Ellipse
        // Hàm vẽ vẽ điểm đối xứng qua các trục x = 0, y = 0 của 1 điểm cho trước
        private void draw4point(Coords centerPoint, int x, int y, int thickness)
        {
            Gl.Begin(OpenGL.GL_POINTS);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y + y, thickness);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y + y, thickness);
            Gl.End();
        }
        // Hàm vẽ hình ellipse theo thuật toán midpoint
        private void DrawEllipse(OpenGL Gl, Coords centerPoint, int a, int b, int thickness)
        {

            int x = 0;
            int y = b;

            int x0 = (int)(a * a / Math.Sqrt(a * a + b * b));
            int P = b * b - a * a * b + a * a / 4;
            draw4point(centerPoint,  x, y, thickness);
            while (x <= x0)
            {
                if (P < 0)
                    P += (b * b) * (2 * x + 3);

                else
                {

                    P += (b * b) * (2 * x + 3) - 2 * a * a * (y - 1);
                    y--;
                }
                x++;
                draw4point(centerPoint, x, y, thickness);
            }

            x = a;
            y = 0;

            P = a * a - b * b * a + b * b / 4;
            draw4point(centerPoint, x, y, thickness);
            while (x > x0)
            {
                if (P < 0)
                    P += (a * a) * (2 * y + 3);
                else
                {
                    P += (a * a) * (2 * y + 3) - 2 * b * b * (x - 1);

                    x--;
                }
                y++;
                draw4point(centerPoint, x, y, thickness);
            }
        }
        #endregion

        // Hàm vẽ hình ellipse (Không bấm phím shift)
        public override void drawShape_unshift(float[] color, int thickness = 0)
        {
            int length = Math.Abs(ListPointInput[2].x - ListPointInput[0].x);
            int width = Math.Abs(ListPointInput[2].y - ListPointInput[0].y);

            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    xMin = ListPointInput[0].x;
                    yMin = ListPointInput[0].y;

                    xMax = xMin + length;
                    yMax = yMin + width;
                }
                else
                {
                    xMin = ListPointInput[0].x;
                    yMin = ListPointInput[0].y - width;

                    xMax = xMin + length;
                    yMax = ListPointInput[0].y;
                }
            }
            else
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    xMin = ListPointInput[0].x - length;
                    yMin = ListPointInput[0].y;

                    xMax = ListPointInput[0].x;
                    yMax = yMin + width;
                }
                else
                {
                    xMin = ListPointInput[0].x - length;
                    yMin = ListPointInput[0].y - width;

                    xMax = ListPointInput[0].x;
                    yMax = ListPointInput[0].y;
                }
            }

            Coords center = new Coords(xMin + length / 2, yMin + width / 2);
            Gl.Color(color);
            if (length > 1 && width > 1)
                DrawEllipse(Gl, center, length / 2, width / 2, thickness);
        }
        // Hàm vẽ hình tròn (Bấm phím shift)
        public override void drawShape_shift(float[] color, int thickness = 0)
        {
            int length = Math.Min(Math.Abs(ListPointInput[2].x - ListPointInput[0].x), Math.Abs(ListPointInput[2].y - ListPointInput[0].y));

            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    xMin = ListPointInput[0].x;
                    yMin = ListPointInput[0].y;

                    xMax = xMin + length;
                    yMax = yMin + length;
                }
                else
                {
                    xMin = ListPointInput[0].x;
                    yMin = ListPointInput[0].y - length;

                    xMax = xMin + length;
                    yMax = ListPointInput[0].y;
                }
            }
            else
            {
                if (ListPointInput[1].y < ListPointInput[2].y)
                {
                    xMin = ListPointInput[0].x - length;
                    yMin = ListPointInput[0].y;

                    xMax = ListPointInput[0].x;
                    yMax = yMin + length;
                }
                else
                {
                    xMin = ListPointInput[0].x - length;
                    yMin = ListPointInput[0].y - length;

                    xMax = ListPointInput[0].x;
                    yMax = ListPointInput[0].y;
                }
            }

            Coords center = new Coords(xMin + length / 2, yMin + length / 2);
            
            Gl.Color(color);
            DrawCircle(center, length/2, thickness);
        }

        public override bool nearbyShape(Coords clickPoint)
        {
            int length = Math.Abs(ListPointInput[2].x - ListPointInput[0].x);
            int width = Math.Abs(ListPointInput[2].y - ListPointInput[0].y);
            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;
            Coords center = new Coords(xMin + length / 2, yMin + width / 2);
            double radius = Math.Sqrt(Math.Pow(center.x - ListPointInput[0].x, 2) + Math.Pow(center.y - ListPointInput[0].y, 2));
            double distance = Math.Sqrt(Math.Pow(clickPoint.x - ListPointInput[0].x, 2) + Math.Pow(clickPoint.y - ListPointInput[0].y, 2));

            if (Math.Abs(distance - radius) <= 10)
                return true;
            return false;
        }

    }
}
