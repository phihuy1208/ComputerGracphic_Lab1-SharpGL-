using System;
using System.Drawing;
using SharpGL;

namespace SharpGL_Application
{
    class Square : BasicShape
    {
        public Square(OpenGLControl GlControl)
        {
            this.GlControl = GlControl;
            Gl = GlControl.OpenGL;
            ListPointInput = new Coords[3];
            NVertex = 4;
        }
        // Hàm trả ra danh sách các điểm của hình chữ nhật theo thứ tự nhất định 
        private Coords[] getListRectanglePoint()
        {
            int length = Math.Abs(ListPointInput[2].x - ListPointInput[0].x);
            int width =  Math.Abs(ListPointInput[2].y - ListPointInput[0].y);
            Coords[] listPoint = new Coords[4];
            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x;
                    listPoint[0].y = ListPointInput[0].y + width;

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[0].y + width;

                    listPoint[2].x = ListPointInput[0].x + length;
                    listPoint[2].y = ListPointInput[0].y;

                    listPoint[3] = ListPointInput[0];
                }
                else
                {
                    listPoint[0] = ListPointInput[0];

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[0].y;

                    listPoint[2].x = ListPointInput[0].x + length;
                    listPoint[2].y = ListPointInput[0].y - width;

                    listPoint[3].x = ListPointInput[0].x;
                    listPoint[3].y = ListPointInput[0].y - width;
                }
            }
            else
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x - length;
                    listPoint[0].y = ListPointInput[0].y + width;

                    listPoint[1].x = ListPointInput[0].x;
                    listPoint[1].y = ListPointInput[0].y + width;

                    listPoint[2] = ListPointInput[0];

                    listPoint[3].x = ListPointInput[0].x - length;
                    listPoint[3].y = ListPointInput[0].y;
                }
                else
                {
                    listPoint[0].x = ListPointInput[0].x - length;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1] = ListPointInput[0];

                    listPoint[2].x = ListPointInput[0].x;
                    listPoint[2].y = ListPointInput[0].y - width;

                    listPoint[3].x = ListPointInput[0].x - length;
                    listPoint[3].y = ListPointInput[0].y - width;
                }
            }
            return listPoint;
        }
        // Hàm trả ra danh sách các điểm của hình vuông theo thứ tự nhất định 
        private Coords[] getListSquarePoint()
        {
            int length = Math.Min(Math.Abs(ListPointInput[2].x - ListPointInput[0].x), Math.Abs(ListPointInput[2].y - ListPointInput[0].y));
            Coords[] listPoint = new Coords[4];
            if (ListPointInput[0].x < ListPointInput[2].x)
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x;
                    listPoint[0].y = ListPointInput[0].y + length;

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[0].y + length;

                    listPoint[2].x = ListPointInput[0].x + length;
                    listPoint[2].y = ListPointInput[0].y;

                    listPoint[3] = ListPointInput[0];
                }
                else
                {
                    listPoint[0] = ListPointInput[0];

                    listPoint[1].x = ListPointInput[0].x + length;
                    listPoint[1].y = ListPointInput[0].y;

                    listPoint[2].x = ListPointInput[0].x + length;
                    listPoint[2].y = ListPointInput[0].y - length;

                    listPoint[3].x = ListPointInput[0].x;
                    listPoint[3].y = ListPointInput[0].y - length;
                }
            }
            else
            {
                if (ListPointInput[0].y < ListPointInput[2].y)
                {
                    listPoint[0].x = ListPointInput[0].x - length;
                    listPoint[0].y = ListPointInput[0].y + length;

                    listPoint[1].x = ListPointInput[0].x;
                    listPoint[1].y = ListPointInput[0].y + length;

                    listPoint[2] = ListPointInput[0];

                    listPoint[3].x = ListPointInput[0].x - length;
                    listPoint[3].y = ListPointInput[0].y;
                }
                else
                {
                    listPoint[0].x = ListPointInput[0].x - length;
                    listPoint[0].y = ListPointInput[0].y;

                    listPoint[1] = ListPointInput[0];

                    listPoint[2].x = ListPointInput[0].x;
                    listPoint[2].y = ListPointInput[0].y - length;

                    listPoint[3].x = ListPointInput[0].x - length;
                    listPoint[3].y = ListPointInput[0].y - length;
                }
            }
            return listPoint;
        }
        // Vẽ hình chữ nhật (Không bấm phím shift)
        public override void drawShape_unshift(float[] color, int thickness = 0)
        {
            if (Direct == false) ListPointOutput = getListRectanglePoint();
            Line line = new Line(GlControl);

            line.ListPointInput[0] = ListPointOutput[0];
            line.ListPointInput[2] = ListPointOutput[1];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[1];
            line.ListPointInput[2] = ListPointOutput[2];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[2];
            line.ListPointInput[2] = ListPointOutput[3];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[3];
            line.ListPointInput[2] = ListPointOutput[0];
            line.drawShape_unshift(color, thickness);
        }
        // Vẽ hình vuông (Nhấn phím shift)
        public override void drawShape_shift(float[] color, int thickness = 0)
        {
            if (Direct == false) ListPointOutput = getListSquarePoint();
            Line line = new Line(GlControl);

            line.ListPointInput[0] = ListPointOutput[0];
            line.ListPointInput[2] = ListPointOutput[1];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[1];
            line.ListPointInput[2] = ListPointOutput[2];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[2];
            line.ListPointInput[2] = ListPointOutput[3];
            line.drawShape_unshift(color, thickness);

            line.ListPointInput[0] = ListPointOutput[3];
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
            line.ListPointInput[2] = ListPointOutput[3];
            if (line.nearbyShape(clickPoint)) return true;

            line.ListPointInput[0] = ListPointOutput[3];
            line.ListPointInput[2] = ListPointOutput[0];
            if (line.nearbyShape(clickPoint)) return true;

            return false;
        }
    }
}
