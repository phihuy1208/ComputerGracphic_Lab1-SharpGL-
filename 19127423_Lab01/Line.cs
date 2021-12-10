using System;
using SharpGL;
namespace SharpGL_Application
{
    class Line : BasicShape
    {
        public Line (OpenGLControl GlControl)
        {
            this.GlControl = GlControl;
            Gl = GlControl.OpenGL;
            ListPointInput = new Coords[3];
            ListPointOutput = new Coords[2];
            NVertex = 2;
        }

        private void DrawLine(int thickness)
        {
            int p, stepx, stepy;
            int Dx = ListPointOutput[1].x - ListPointOutput[0].x;
            int Dy = ListPointOutput[1].y - ListPointOutput[0].y;
            int _2_Dx = 2*(ListPointOutput[1].x - ListPointOutput[0].x);
            int _2_Dy = 2*(ListPointOutput[1].y - ListPointOutput[0].y);
            int x = ListPointOutput[0].x;
            int y = ListPointOutput[0].y;

            if (_2_Dx < 0) { _2_Dx = -_2_Dx; stepx = -1; } else if (_2_Dx > 0) { stepx = 1; } else { stepx = 0; }
            if (_2_Dy < 0) { _2_Dy = -_2_Dy; stepy = -1; } else if (_2_Dy > 0) { stepy = 1; } else { stepy = 0; }

            Gl.Begin(OpenGL.GL_POINTS);
            thicknessStroke(Gl, x, y, thickness);
            if (_2_Dx > _2_Dy) // |m| > 1
            {
                p = _2_Dy - Dx;
                while (x != ListPointOutput[1].x)
                {
                    if (p <= 0)
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
            else // |m| <= 1
            {
                p = _2_Dx - Dy;
                while (y != ListPointOutput[1].y)
                {
                    if (p <= 0)
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

        // Vẽ đường thẩng khi không nhấn phím shift
        public override void drawShape_unshift(float[] color, int thickness = 0)
        {
            Gl.Color(color);
            ListPointOutput[0] = ListPointInput[0];
            ListPointOutput[1] = ListPointInput[2];
            DrawLine(thickness);
        }

        // Vẽ đường thẩng khi không phím shift
        public override void drawShape_shift(float[] color, int thickness = 0)
        {
            ListPointOutput[0] = ListPointInput[0];
            ListPointOutput[1] = ListPointInput[2];
            Gl.Color(color);
            if (Math.Abs(ListPointInput[2].x - ListPointInput[0].x) < Math.Abs(ListPointInput[2].y - ListPointInput[0].y))
            {
                ListPointOutput[1].x = ListPointInput[0].x;
            }
            else if (Math.Abs(ListPointInput[2].x - ListPointInput[0].x) > Math.Abs(ListPointInput[2].y - ListPointInput[0].y))
            {
                ListPointOutput[1].y = ListPointInput[0].y;
            }
        DrawLine(thickness);
        }

        public override bool nearbyShape(Coords clickPoint)
        {
            ListPointOutput[0] = ListPointInput[0];
            ListPointOutput[1] = ListPointInput[2];
            int xMin = Math.Min(ListPointOutput[0].x, ListPointOutput[1].x), 
                xMax = Math.Max(ListPointOutput[0].x, ListPointOutput[1].x), 
                yMin = Math.Min(ListPointOutput[0].y, ListPointOutput[1].y), 
                yMax = Math.Max(ListPointOutput[0].y, ListPointOutput[1].y);
            if (clickPoint.x < xMin - 5 || clickPoint.y < yMin - 5 || clickPoint.x > xMax + 5 || clickPoint.y > yMax + 5)
                return false;

            int nx = ListPointOutput[0].y - ListPointOutput[1].y;
            int ny = ListPointOutput[1].x - ListPointOutput[0].x;

            double distance = Math.Abs(nx * (clickPoint.x - ListPointOutput[0].x) + ny * (clickPoint.y - ListPointOutput[0].y)) / Math.Sqrt(nx * nx + ny * ny);
            
            return distance < 10 ? true : false;
        }
    }
}
