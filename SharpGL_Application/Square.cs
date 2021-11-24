using System;
using SharpGL;

namespace SharpGL_Application
{
    class Square : BasicShape
    {
        private Coords[] getListRectanglePoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            int length = Math.Abs(lastPoint.x - firstPoint.x);
            int width =  Math.Abs(lastPoint.y - firstPoint.y);
            Coords[] listPoint = new Coords[4];
            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x;
                    listPoint[0].y = firstPoint.y + width;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = firstPoint.y + width;

                    listPoint[2].x = firstPoint.x + length;
                    listPoint[2].y = firstPoint.y;

                    listPoint[3] = firstPoint;
                }
                else
                {
                    listPoint[0] = firstPoint;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = firstPoint.y;

                    listPoint[2].x = firstPoint.x + length;
                    listPoint[2].y = firstPoint.y - width;

                    listPoint[3].x = firstPoint.x;
                    listPoint[3].y = firstPoint.y - width;
                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x - length;
                    listPoint[0].y = firstPoint.y + width;

                    listPoint[1].x = firstPoint.x;
                    listPoint[1].y = firstPoint.y + width;

                    listPoint[2] = firstPoint;

                    listPoint[3].x = firstPoint.x - length;
                    listPoint[3].y = firstPoint.y;
                }
                else
                {
                    listPoint[0].x = firstPoint.x - length;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1] = firstPoint;

                    listPoint[2].x = firstPoint.x;
                    listPoint[2].y = firstPoint.y - width;

                    listPoint[3].x = firstPoint.x - length;
                    listPoint[3].y = firstPoint.y - width;
                }
            }
            return listPoint;
        }

        private Coords[] getListSquarePoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            int length = Math.Min(Math.Abs(lastPoint.x - firstPoint.x), Math.Abs(lastPoint.y - firstPoint.y));
            Coords[] listPoint = new Coords[4];
            if (firstPoint.x < lastPoint.x)
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x;
                    listPoint[0].y = firstPoint.y + length;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = firstPoint.y + length;

                    listPoint[2].x = firstPoint.x + length;
                    listPoint[2].y = firstPoint.y;

                    listPoint[3] = firstPoint;
                }
                else
                {
                    listPoint[0] = firstPoint;

                    listPoint[1].x = firstPoint.x + length;
                    listPoint[1].y = firstPoint.y;

                    listPoint[2].x = firstPoint.x + length;
                    listPoint[2].y = firstPoint.y - length;

                    listPoint[3].x = firstPoint.x;
                    listPoint[3].y = firstPoint.y - length;
                }
            }
            else
            {
                if (firstPoint.y < lastPoint.y)
                {
                    listPoint[0].x = firstPoint.x - length;
                    listPoint[0].y = firstPoint.y + length;

                    listPoint[1].x = firstPoint.x;
                    listPoint[1].y = firstPoint.y + length;

                    listPoint[2] = firstPoint;

                    listPoint[3].x = firstPoint.x - length;
                    listPoint[3].y = firstPoint.y;
                }
                else
                {
                    listPoint[0].x = firstPoint.x - length;
                    listPoint[0].y = firstPoint.y;

                    listPoint[1] = firstPoint;

                    listPoint[2].x = firstPoint.x;
                    listPoint[2].y = firstPoint.y - length;

                    listPoint[3].x = firstPoint.x - length;
                    listPoint[3].y = firstPoint.y - length;
                }
            }
            return listPoint;
        }

        public void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color)
        {
            Coords[] listPoint = getListRectanglePoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[3], color);
            line.drawShape_unshift(Gl, listPoint[3], listPoint[0], color);
        }
        public void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color)
        {
            Coords[] listPoint = getListSquarePoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[3], color);
            line.drawShape_unshift(Gl, listPoint[3], listPoint[0], color);
        }

    }
}
