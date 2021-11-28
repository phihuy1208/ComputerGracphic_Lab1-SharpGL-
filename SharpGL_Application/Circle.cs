using System;
using SharpGL;

namespace SharpGL_Application
{
    class Circle : BasicShape
    {
        public Circle()
        {
        }


        private void draw8point(OpenGL Gl, Coords centerPoint, int x, int y, int thickness)
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
        private void DrawCircle(OpenGL Gl, Coords centerPoint, int R, int thickness)
        {
            int p;
            int y = R;
            int x = 0;
            p = 3 - 2 * R;
            draw8point(Gl, centerPoint, x, y, thickness);
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
                draw8point(Gl, centerPoint, x, y, thickness);
            }
        }

        private void draw4point(OpenGL Gl, Coords centerPoint, int x, int y, int thickness)
        {
            Gl.Begin(OpenGL.GL_POINTS);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y + y, thickness);
            thicknessStroke(Gl, centerPoint.x + x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y - y, thickness);
            thicknessStroke(Gl, centerPoint.x - x, centerPoint.y + y, thickness);
            Gl.End();
        }
        private void DrawEllipse(OpenGL Gl, Coords centerPoint, int a, int b, int thickness)
        {

            int x = 0;
            int y = b;

            int x0 = (int)(a * a / Math.Sqrt(a * a + b * b));
            int P = b * b - a * a * b + a * a / 4;
            draw4point(Gl, centerPoint,  x, y, thickness);
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
                draw4point(Gl, centerPoint, x, y, thickness);
            }

            x = a;
            y = 0;

            P = a * a - b * b * a + b * b / 4;
            draw4point(Gl, centerPoint, x, y, thickness);
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
                draw4point(Gl, centerPoint, x, y, thickness);
            }
        }

        public override void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            int length = Math.Abs(lastPoint.x - firstPoint.x);
            int width = Math.Abs(lastPoint.y - firstPoint.y);

            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    xMin = firstPoint.x;
                    yMin = firstPoint.y;

                    xMax = xMin + length;
                    yMax = yMin + width;
                }
                else
                {
                    xMin = firstPoint.x;
                    yMin = firstPoint.y - width;

                    xMax = xMin + length;
                    yMax = firstPoint.y;
                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    xMin = firstPoint.x - length;
                    yMin = firstPoint.y;

                    xMax = firstPoint.x;
                    yMax = yMin + width;
                }
                else
                {
                    xMin = firstPoint.x - length;
                    yMin = firstPoint.y - width;

                    xMax = firstPoint.x;
                    yMax = firstPoint.y;
                }
            }

            Coords center = new Coords(xMin + length / 2, yMin + width / 2);
            Gl.Color(color);
            if (length > 1 && width > 1)
                DrawEllipse(Gl, center, length / 2, width / 2, thickness);
        }

        public override void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            int length = Math.Min(Math.Abs(lastPoint.x - firstPoint.x), Math.Abs(lastPoint.y - firstPoint.y));

            int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    xMin = firstPoint.x;
                    yMin = firstPoint.y;

                    xMax = xMin + length;
                    yMax = yMin + length;
                }
                else
                {
                    xMin = firstPoint.x;
                    yMin = firstPoint.y - length;

                    xMax = xMin + length;
                    yMax = firstPoint.y;
                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    xMin = firstPoint.x - length;
                    yMin = firstPoint.y;

                    xMax = firstPoint.x;
                    yMax = yMin + length;
                }
                else
                {
                    xMin = firstPoint.x - length;
                    yMin = firstPoint.y - length;

                    xMax = firstPoint.x;
                    yMax = firstPoint.y;
                }
            }

            Coords center = new Coords(xMin + length / 2, yMin + length / 2);
            
            Gl.Color(color);
            DrawCircle(Gl, center, length/2, thickness);
        }

    }
}
