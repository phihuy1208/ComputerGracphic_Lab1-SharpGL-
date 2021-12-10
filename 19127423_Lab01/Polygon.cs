using System;
using SharpGL;

namespace SharpGL_Application
{
    class Polygon : BasicShape
    {
        public Polygon(OpenGLControl GlControl)
        {
            this.GlControl = GlControl;
            Gl = GlControl.OpenGL;
            ListPointInput = new Coords[20];
            ListPointOutput = new Coords[20];
        }
        public override void drawShape_unshift(float[] color, int thickness = 0)
        {
            ListPointOutput[NVertex] = ListPointInput[NVertex];
            if (NVertex == 0) {
                Gl.Begin(OpenGL.GL_POINTS);
                thicknessStroke(Gl, ListPointInput[0].x, ListPointInput[0].y, thickness);
                Gl.End();
            }
            else
            {
                Line line = new Line(GlControl);
                for (int i = 1; i <= NVertex; i++)
                {
                    line.ListPointInput[0] = ListPointOutput[i - 1];
                    line.ListPointInput[2] = ListPointOutput[i];
                    line.drawShape_unshift(color, thickness);
                }
            }
        }

        public override void drawShape_shift(float[] color, int thickness = 0)
        {
            Line line = new Line(GlControl);
            for (int i = 1; i <= NVertex; i++)
            {
                line.ListPointInput[0] = ListPointOutput[i - 1];
                line.ListPointInput[2] = ListPointOutput[i == NVertex ? 0 : i];
                line.drawShape_unshift(color, thickness);
            }
        }
        public override bool nearbyShape(Coords clickPoint)
        {
            Line line = new Line(GlControl);
            for (int i = 1; i <= NVertex; i++)
            {
                line.ListPointInput[0] = ListPointOutput[i - 1];
                line.ListPointInput[2] = ListPointOutput[i == NVertex? 0 : i];
                if (line.nearbyShape(clickPoint)) return true;
            }
            return false;
        }
        // Hàm trả ra danh sách các điểm của hình ngũ giác đều theo thứ tự nhất định 
        /*     private Coords[] getListPentagonPoint()
             {
                 Coords[] listPoint = new Coords[5];
                 int radius = (int)Math.Sqrt((Math.Pow((ListPoint[0].x - ListPoint[2].x), 2) +
                     Math.Pow((ListPoint[0].y - ListPoint[2].y), 2)));
                 listPoint[0] = new Coords(0, radius); listPoint[0].translate(ListPoint[0]);
                 listPoint[1] = new Coords((int)(radius * Math.Cos(Math.PI * 18 / 180)), (int)(radius * Math.Sin(Math.PI * 18 / 180))); listPoint[1].translate(ListPoint[0]);
                 listPoint[2] = new Coords((int)(radius * Math.Cos(Math.PI * -54 / 180)), (int)(radius * Math.Sin(Math.PI * -54 / 180))); listPoint[2].translate(ListPoint[0]);
                 listPoint[3] = new Coords((int)(-radius * Math.Cos(Math.PI * -54 / 180)), (int)(radius * Math.Sin(Math.PI * -54 / 180))); listPoint[3].translate(ListPoint[0]);
                 listPoint[4] = new Coords((int)(-radius * Math.Cos(Math.PI * 18 / 180)), (int)(radius * Math.Sin(Math.PI * 18 / 180))); listPoint[4].translate(ListPoint[0]);

                 return listPoint;
             }*//*

             // Hàm trả ra danh sách các điểm của hình lục giác đều theo thứ tự nhất định 
     *//*        private Coords[] getListHexagonPoint()
             {
                 *//*Coords[] listPoint = new Coords[6];

                 int width = Math.Abs(ListPoint[2].y - ListPoint[0].y);
                 int length = (int)(2 * width * Math.Sqrt(3) /3);

                 int xMin = 0, xMax = 0, yMin = 0, yMax = 0;

                 if (ListPoint[0].x < ListPoint[2].x)
                 {
                     if (ListPoint[0].y < ListPoint[2].y)
                     {
                         xMin = ListPoint[0].x;
                         yMin = ListPoint[0].y;

                         xMax = xMin + length;
                         yMax = yMin + width;
                     }
                     else
                     {
                         xMin = ListPoint[0].x;
                         yMin = ListPoint[0].y - width;

                         xMax = xMin + length;
                         yMax = ListPoint[0].y;
                     }
                 }
                 else
                 {
                     if (ListPoint[0].y < ListPoint[2].y)
                     {
                         xMin = ListPoint[0].x - length;
                         yMin = ListPoint[0].y;

                         xMax = ListPoint[0].x;
                         yMax = yMin + width;
                     }
                     else
                     {
                         xMin = ListPoint[0].x - length;
                         yMin = ListPoint[0].y - width;

                         xMax = ListPoint[0].x;
                         yMax = ListPoint[0].y;
                     }
                 }
                 listPoint[0] = new Coords(xMin + (int)(xMax - xMin) / 4, yMax);
                 listPoint[1] = new Coords(xMin + (int)(xMax - xMin) * 3 / 4, yMax);
                 listPoint[2] = new Coords(xMax, yMin + (int)(yMax - yMin) / 2);
                 listPoint[3] = new Coords(xMin + (int)(xMax - xMin) * 3 / 4, yMin);
                 listPoint[4] = new Coords(xMin + (int)(xMax - xMin) / 4, yMin);
                 listPoint[5] = new Coords(xMin, yMin + (int)(yMax - yMin) / 2);

                 return listPoint;*//*

                 Coords[] listPoint = new Coords[6];
                 int radius = (int)Math.Sqrt((Math.Pow((ListPoint[0].x - ListPoint[2].x), 2) +
                     Math.Pow((ListPoint[0].y - ListPoint[2].y), 2)));

                 listPoint[0] = new Coords(0, radius); listPoint[0].translate(ListPoint[0]);
                 listPoint[1] = new Coords((int)(radius * Math.Cos(Math.PI * 30 / 180)), (int)(radius * Math.Sin(Math.PI * 30 / 180))); listPoint[1].translate(ListPoint[0]);
                 listPoint[2] = new Coords((int)(radius * Math.Cos(Math.PI * -30 / 180)), (int)(radius * Math.Sin(Math.PI * -30 / 180))); listPoint[2].translate(ListPoint[0]);
                 listPoint[3] = new Coords(0, - radius); listPoint[3].translate(ListPoint[0]);
                 listPoint[4] = new Coords((int)(-radius * Math.Cos(Math.PI * -30 / 180)), (int)(radius * Math.Sin(Math.PI * -30 / 180))); ; listPoint[4].translate(ListPoint[0]);
                 listPoint[5] = new Coords((int)(-radius * Math.Cos(Math.PI * 30 / 180)), (int)(radius * Math.Sin(Math.PI * 30 / 180))); listPoint[5].translate(ListPoint[0]);

                 return listPoint;
             }*//*

             // Hàm vẽ hình ngũ giác đều (Không bấm phím shift)
             public override void drawShape_shift(float[] color, int thickness = 0)
             {
                 Coords[] listPoint = getListHexagonPoint();
                 Line line = new Line(GlControl);

                 line.ListPoint[0] = listPoint[0];
                 line.ListPoint[2] = listPoint[1];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[1];
                 line.ListPoint[2] = listPoint[2];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[2];
                 line.ListPoint[2] = listPoint[3];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[3];
                 line.ListPoint[2] = listPoint[4];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[4];
                 line.ListPoint[2] = listPoint[5];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[5];
                 line.ListPoint[2] = listPoint[0];
                 line.drawShape_unshift(color, thickness);
             }
             // Hàm vẽ hình lục giác đều (Bấm phím shift)
             public override void drawShape_unshift(float[] color, int thickness = 0)
             {
                 Coords[] listPoint = getListPentagonPoint();
                 Line line = new Line(GlControl);

                 line.ListPoint[0] = listPoint[0];
                 line.ListPoint[2] = listPoint[1];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[1];
                 line.ListPoint[2] = listPoint[2];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[2];
                 line.ListPoint[2] = listPoint[3];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[3];
                 line.ListPoint[2] = listPoint[4];
                 line.drawShape_unshift(color, thickness);

                 line.ListPoint[0] = listPoint[4];
                 line.ListPoint[2] = listPoint[0];
                 line.drawShape_unshift(color, thickness);
             }

             public override bool nearbyShape(Coords clickPoint)
             {
                 return true;
             }
         }*/
    }
}
