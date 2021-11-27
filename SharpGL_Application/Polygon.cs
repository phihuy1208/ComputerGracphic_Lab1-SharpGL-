using System;
using SharpGL;

namespace SharpGL_Application
{
    class Polygon : BasicShape
    {
        private Coords[] getListPentagonPoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            Coords[] listPoint = new Coords[5];
            int radius = (int)Math.Sqrt((Math.Pow((firstPoint.x - lastPoint.x), 2) +
                Math.Pow((firstPoint.y - lastPoint.y), 2)));
            listPoint[0] = new Coords(0, radius); listPoint[0].translate(firstPoint);
            listPoint[1] = new Coords((int)(radius * Math.Cos(Math.PI * 18 / 180)), (int)(radius * Math.Sin(Math.PI * 18 / 180))); listPoint[1].translate(firstPoint);
            listPoint[2] = new Coords((int)(radius * Math.Cos(Math.PI * -54 / 180)), (int)(radius * Math.Sin(Math.PI * -54 / 180))); listPoint[2].translate(firstPoint);
            listPoint[3] = new Coords((int)(-radius * Math.Cos(Math.PI * -54 / 180)), (int)(radius * Math.Sin(Math.PI * -54 / 180))); listPoint[3].translate(firstPoint);
            listPoint[4] = new Coords((int)(-radius * Math.Cos(Math.PI * 18 / 180)), (int)(radius * Math.Sin(Math.PI * 18 / 180))); listPoint[4].translate(firstPoint);

            return listPoint;
        }

        private Coords[] getListHexagonPoint(OpenGL Gl, Coords firstPoint, Coords lastPoint)
        {
            /*Coords[] listPoint = new Coords[6];

            int width = Math.Abs(lastPoint.y - firstPoint.y);
            int length = (int)(2 * width * Math.Sqrt(3) /3);

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
            listPoint[0] = new Coords(xMin + (int)(xMax - xMin) / 4, yMax);
            listPoint[1] = new Coords(xMin + (int)(xMax - xMin) * 3 / 4, yMax);
            listPoint[2] = new Coords(xMax, yMin + (int)(yMax - yMin) / 2);
            listPoint[3] = new Coords(xMin + (int)(xMax - xMin) * 3 / 4, yMin);
            listPoint[4] = new Coords(xMin + (int)(xMax - xMin) / 4, yMin);
            listPoint[5] = new Coords(xMin, yMin + (int)(yMax - yMin) / 2);

            return listPoint;*/

            Coords[] listPoint = new Coords[6];
            int radius = (int)Math.Sqrt((Math.Pow((firstPoint.x - lastPoint.x), 2) +
                Math.Pow((firstPoint.y - lastPoint.y), 2)));

            listPoint[0] = new Coords(0, radius); listPoint[0].translate(firstPoint);
            listPoint[1] = new Coords((int)(radius * Math.Cos(Math.PI * 30 / 180)), (int)(radius * Math.Sin(Math.PI * 30 / 180))); listPoint[1].translate(firstPoint);
            listPoint[2] = new Coords((int)(radius * Math.Cos(Math.PI * -30 / 180)), (int)(radius * Math.Sin(Math.PI * -30 / 180))); listPoint[2].translate(firstPoint);
            listPoint[3] = new Coords(0, - radius); listPoint[3].translate(firstPoint);
            listPoint[4] = new Coords((int)(-radius * Math.Cos(Math.PI * -30 / 180)), (int)(radius * Math.Sin(Math.PI * -30 / 180))); ; listPoint[4].translate(firstPoint);
            listPoint[5] = new Coords((int)(-radius * Math.Cos(Math.PI * 30 / 180)), (int)(radius * Math.Sin(Math.PI * 30 / 180))); listPoint[5].translate(firstPoint);

            return listPoint;
        }

        public override void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            Coords[] listPoint = getListHexagonPoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color, thickness);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color, thickness);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[3], color, thickness);
            line.drawShape_unshift(Gl, listPoint[3], listPoint[4], color, thickness);
            line.drawShape_unshift(Gl, listPoint[4], listPoint[5], color, thickness);
            line.drawShape_unshift(Gl, listPoint[5], listPoint[0], color, thickness);
        }

        public override void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0)
        {
            Coords[] listPoint = getListPentagonPoint(Gl, firstPoint, lastPoint);
            Line line = new Line();
            line.drawShape_unshift(Gl, listPoint[0], listPoint[1], color, thickness);
            line.drawShape_unshift(Gl, listPoint[1], listPoint[2], color, thickness);
            line.drawShape_unshift(Gl, listPoint[2], listPoint[3], color, thickness);
            line.drawShape_unshift(Gl, listPoint[3], listPoint[4], color, thickness);
            line.drawShape_unshift(Gl, listPoint[4], listPoint[0], color, thickness);
        }
    }
}
