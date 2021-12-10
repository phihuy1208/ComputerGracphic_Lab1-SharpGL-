using SharpGL;

namespace SharpGL_Application
{
    /// <summary>
    /// class BasicShape: bao gồm các hàm, cách thức để vẽ một shape ra màn hình. 
    /// class BasicShape kế thừa class Stroke để có thể điều chỉnh nét vẽ của 1 hình
    /// </summary>
    abstract class BasicShape : Stroke
    {
        /// <summary>
        /// listPoint: lưu các điểm khi điều khiển chuột
        /// listPoint[0]: tọa độ khi click chuột phải xuống
        /// listPoint[1]: tọa độ của chuột khi click chuột xuống và di chuyển
        /// listPoint[2]: tọa độ khi thả chuột phải lên
        /// </summary>
        private Coords[] listPointInput;
        internal Coords[] ListPointInput { get => listPointInput; set => listPointInput = value; }

        private Coords[] listPointOutput;
        internal Coords[] ListPointOutput { get => listPointOutput; set => listPointOutput = value; }

        private OpenGLControl _GlControl;
        private OpenGL _Gl;
        public OpenGLControl GlControl { get => _GlControl; set => _GlControl = value; }
        public OpenGL Gl { get => _Gl; set => _Gl = value; }

        private int nVertex = 0;
        public int NVertex { get => nVertex; set => nVertex = value; }

        bool direct = true; 
        public bool Direct { get => direct; set => direct = value; }

        public abstract void drawShape_shift(float[] color, int thickness = 0);
        public abstract void drawShape_unshift(float[] color, int thickness = 0);
        public override void thicknessStroke(OpenGL Gl, int x, int y, int thickness = 0)
        {
            if (thickness == 0)
                Gl.Vertex(x, y);
            else 
            {
                // Tô màu bên trong tâm của tường pixel
                thicknessStroke(Gl, x, y, thickness - 1);
                // Tô màu 4 góc bên ngoài cùng của pixel với độ dày thickness
                Gl.Vertex(x - thickness, y - thickness);
                Gl.Vertex(x - thickness, y + thickness);
                Gl.Vertex(x + thickness, y - thickness);
                Gl.Vertex(x + thickness, y + thickness);

                // Tô màu khoảng trống ở giữa của 4 góc
                for (int i = -thickness + 1; i <= thickness - 1; i++)
                {
                    Gl.Vertex(x + i , y + thickness);
                    Gl.Vertex(x + i, y - thickness);
                    Gl.Vertex(x + thickness, y + i);
                    Gl.Vertex(x - thickness, y - i);
                }
            }
        }
        public abstract bool nearbyShape(Coords clickPoint);
        public void highlight()
        {
            for (int i = 0; i < NVertex; i++)
            {
                float[] colorBlack = { 0, 0, 0, 1 };
                Circle c = new Circle(_GlControl);
                c.listPointInput[0] = ListPointOutput[i].translate(-5, -5);
                c.listPointInput[2] = ListPointOutput[i].translate(5, 5);
                c.drawShape_shift(colorBlack);
            }

        }
    }
}
