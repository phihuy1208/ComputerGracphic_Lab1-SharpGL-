using System;
using SharpGL;

namespace SharpGL_Application
{
    class Triangle : BasicShape
    {
        public Triangle(OpenGLControl GlControl)
        {
            this.GlControl = GlControl;
            Gl = GlControl.OpenGL;
            ListPointInput = new Coords[3];
            NVertex = 3;
        }
        // Hàm trả ra danh sách các điểm của hình tam giác cân theo thứ tự nhất định 
        private Coords[] getListIsoscelesTrianglePoint()
        {
            Coords[] listPoint = new Coords[3];
            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = (ListPointInput[0].x + ListPointInput[2].x) / 2;
                    listPoint[0].y = ListPointInput[2].y;

                    listPoint[1].x = ListPointInput[2].x;
                    listPoint[1].y = ListPointInput[0].y;

                    listPoint[2] = ListPointInput[0];
                }
                else
                {
                    listPoint[0].x = (ListPointInput[0].x + ListPointInput[2].x) / 2;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1].x = ListPointInput[0].x;
                    listPoint[1].y = ListPointInput[2].y;

                    listPoint[2] = ListPointInput[2];
                }
            }
            else
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = (ListPointInput[0].x + ListPointInput[2].x) / 2;
                    listPoint[0].y = ListPointInput[2].y;

                    listPoint[1] = ListPointInput[0];

                    listPoint[2].x = ListPointInput[2].x;
                    listPoint[2].y = ListPointInput[0].y;
                }
                else
                {
                    listPoint[0].x = (ListPointInput[0].x + ListPointInput[2].x) / 2;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1].x = ListPointInput[0].x;
                    listPoint[1].y = ListPointInput[2].y;

                    listPoint[2] = ListPointInput[2];
                }
            }
            return listPoint;
        }
        // Hàm trả ra danh sách các điểm của hình tam giác đều theo thứ tự nhất định 
        private Coords[] getListEquilateralTrianglePoint()
        {
            Coords[] listPoint = new Coords[3];
            int length = (int)(Math.Abs(ListPointInput[0].y - ListPointInput[2].y) / Math.Sin(Math.PI * 60 / 180));

            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x + length / 2;
                    listPoint[0].y = ListPointInput[2].y;

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[0].y;

                    listPoint[2] = ListPointInput[0];
                }
                else
                {
                    listPoint[0].x = ListPointInput[0].x + length / 2;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[2].y;

                    listPoint[2].x = ListPointInput[0].x;
                    listPoint[2].y = ListPointInput[2].y;

                }
            }
            else
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x - length / 2;
                    listPoint[0].y = ListPointInput[2].y;

                    listPoint[1] = ListPointInput[0];

                    listPoint[2].x = ListPointInput[0].x - length;
                    listPoint[2].y = ListPointInput[0].y;
                }
                else
                {
                    listPoint[0].x = ListPointInput[0].x - length / 2;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1].x = ListPointInput[0].x;
                    listPoint[1].y = ListPointInput[2].y;

                    listPoint[2].x = ListPointInput[0].x - length;
                    listPoint[2].y = ListPointInput[2].y;
                }
            }
            return listPoint;
        }

        // Vẽ tam giác cân (Không bấm phím shift)
        public override void drawShape_unshift(float[] color, int thickness = 0)
        {
            ListPointOutput = getListIsoscelesTrianglePoint();
            Line line = new Line(GlControl);

            line.ListPointInput[0] = ListPointOutput[0];
            line.ListPointInput[2] = ListPointOutput[1];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[1];
            line.ListPointInput[2] = ListPointOutput[2];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[2];
            line.ListPointInput[2] = ListPointOutput[0];
            line.drawShape_unshift(color, thickness);
        }
        // Vẽ tam giác đều (bấm phím shift)
        public override void drawShape_shift(float[] color, int thickness = 0)
        {
            ListPointOutput = getListEquilateralTrianglePoint();
            Line line = new Line(GlControl);

            line.ListPointInput[0] = ListPointOutput[0];
            line.ListPointInput[2] = ListPointOutput[1];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[1];
            line.ListPointInput[2] = ListPointOutput[2];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[2];
            line.ListPointInput[2] = ListPointOutput[0];
            line.drawShape_unshift(color, thickness);
        }

        public override bool nearbyShape(Coords clickPoint)
        {
            Line line = new Line(GlControl);

            line.ListPointInput[0] = ListPointOutput[0];
            line.ListPointInput[2] = ListPointOutput[1];
            if (line.nearbyShape(clickPoint)) return true;

            line.ListPointInput[0] = ListPointOutput[1];
            line.ListPointInput[2] = ListPointOutput[2];
            if (line.nearbyShape(clickPoint)) return true;

            line.ListPointInput[0] = ListPointOutput[2];
            line.ListPointInput[2] = ListPointOutput[0];
            if (line.nearbyShape(clickPoint)) return true;

            return false;
        }
    }
}
