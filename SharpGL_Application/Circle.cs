using System;
using SharpGL;

namespace SharpGL_Application
{
    class Circle : BasicShape
    {
        public Circle()
        {
            radius = 0;
    }
        private int radius;

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
        public override void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            radius = (int)Math.Sqrt((Math.Pow((firstPoint.x - lastPoint.x), 2) +
                Math.Pow((firstPoint.y - lastPoint.y), 2)));
            Gl.Color(color);
            DrawCircle(Gl, firstPoint, radius, thickness);
        }

        public override void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            drawShape_unshift(Gl, firstPoint, lastPoint, color, thickness);
        }

    }
}
