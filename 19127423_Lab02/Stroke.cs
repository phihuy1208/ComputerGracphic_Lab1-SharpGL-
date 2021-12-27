using SharpGL;

namespace SharpGL_Application
{/// <summary>
/// class stroke: gồm các hàm để thay đổi độ dày, mỏng của nét vẽ
/// </summary>
    abstract class Stroke
    {
        public abstract void thicknessStroke(OpenGL Gl, int x, int y, int thickness = 0);
    }
}
