using System;
using SharpGL;

namespace SharpGL_Application
{
    class Triangle : BasicShape
    {
        private Coords[] getListIsoscelesTrianglePoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            Coords[] listPoint = new Coords[3];
            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = (firstPoint.x + lastPoint.x) / 2;
                    listPoint[0].y = lastPoint.y;

                    listPoint[1].x = lastPoint.x;
                    listPoint[1].y = firstPoint.y;

                    listPoint[2] = firstPoint;
                }
                else
                {
                    listPoint[0].x = (firstPoint.x + lastPoint.x) / 2;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1].x = firstPoint.x;
                    listPoint[1].y = lastPoint.y;

                    listPoint[2] = lastPoint;
                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = (firstPoint.x + lastPoint.x) / 2;
                    listPoint[0].y = lastPoint.y;

                    listPoint[1] = firstPoint;

                    listPoint[2].x = lastPoint.x;
                    listPoint[2].y = firstPoint.y;
                }
                else
                {
                    listPoint[0].x = (firstPoint.x + lastPoint.x) / 2;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1].x = firstPoint.x;
                    listPoint[1].y = lastPoint.y;

                    listPoint[2] = lastPoint;
                }
            }
            return listPoint;
        }
        private Coords[] getListEquilateralTrianglePoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            Coords[] listPoint = new Coords[3];
            int length = (int)(Math.Abs(firstPoint.y - lastPoint.y) / Math.Sin(Math.PI * 60 / 180));

            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x + length / 2;
                    listPoint[0].y = lastPoint.y;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = firstPoint.y;

                    listPoint[2] = firstPoint;
                }
                else
                {
                    listPoint[0].x = firstPoint.x + length / 2;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = lastPoint.y;

                    listPoint[2].x = firstPoint.x;
                    listPoint[2].y = lastPoint.y;

                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x - length / 2;
                    listPoint[0].y = lastPoint.y;

                    listPoint[1] = firstPoint;

                    listPoint[2].x = firstPoint.x - length;
                    listPoint[2].y = firstPoint.y;
                }
                else
                {
                    listPoint[0].x = firstPoint.x - length / 2;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1].x = firstPoint.x;
                    listPoint[1].y = lastPoint.y;

                    listPoint[2].x = firstPoint.x - length;
                    listPoint[2].y = lastPoint.y;
                }
            }
            return listPoint;
        }
        public void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color)
        {
            Coords[] listPoint = getListIsoscelesTrianglePoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[0], color);
        }
        public void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color)
        {
            Coords[] listPoint = getListEquilateralTrianglePoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[0], color);
        }


    }
}
