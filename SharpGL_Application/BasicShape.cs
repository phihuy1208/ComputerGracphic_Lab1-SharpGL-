using SharpGL;

namespace SharpGL_Application
{
    abstract class BasicShape : Stroke
    {
        /*        void drawShape(OpenGL Gl, Coords[] listPoint, float[] color);*/
        public abstract void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0);
        public abstract void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color, int thickness = 0);
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
    }
}
