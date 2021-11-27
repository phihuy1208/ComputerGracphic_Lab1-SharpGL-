using System;
using SharpGL;
namespace SharpGL_Application
{
    class Line : BasicShape
    {
        public Line ()
        {
        }

        private void DrawLine(OpenGL Gl, Coords firstPoint, Coords LastPoint, int thickness)
        {
            int p, stepx, stepy;
            int Dx = LastPoint.x - firstPoint.x;
            int Dy = LastPoint.y - firstPoint.y;
            int _2_Dx = 2*(LastPoint.x - firstPoint.x);
            int _2_Dy = 2*(LastPoint.y - firstPoint.y);
            int x = firstPoint.x;
            int y = firstPoint.y;

            if (_2_Dx < 0) { _2_Dx = -_2_Dx; stepx = -1; } else if (_2_Dx > 0) { stepx = 1; } else { stepx = 0; }
            if (_2_Dy < 0) { _2_Dy = -_2_Dy; stepy = -1; } else if (_2_Dy > 0) { stepy = 1; } else { stepy = 0; }

            Gl.Begin(OpenGL.GL_POINTS);
            thicknessStroke(Gl, x, y, thickness);
            if (_2_Dx >= _2_Dy)
            {
                p = _2_Dy - Dx;
                while (x != LastPoint.x)
                {
                    if (p < 0)
                        p += _2_Dy;
                    else
                    {
                        p += _2_Dy - _2_Dx;
                        y+= stepy;
                    }
                    x+=stepx;
                    thicknessStroke(Gl, x, y, thickness);
                }
            }
            else
            {
                p = _2_Dx - Dy;
                while (y != LastPoint.y)
                {
                    if (p < 0)
                        p += _2_Dx;
                    else
                    {
                        p += _2_Dx - _2_Dy;
                        x += stepx;
                    }
                    y += stepy;
                    thicknessStroke(Gl, x, y, thickness);
                }
            }
            Gl.End();
        }

        public override void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            Gl.Color(color);
            DrawLine(Gl, firstPoint, lastPoint, thickness);
        }

        public override void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            Gl.Color(color);
                if (Math.Abs(lastPoint.x - firstPoint.x) < Math.Abs(lastPoint.y - firstPoint.y))
                {
                    lastPoint.x = firstPoint.x;
                }
                else if (Math.Abs(lastPoint.x - firstPoint.x) > Math.Abs(lastPoint.y - firstPoint.y))
                {
                    lastPoint.y = firstPoint.y;
                }
            DrawLine(Gl, firstPoint, lastPoint, thickness);
        }
    }
}
