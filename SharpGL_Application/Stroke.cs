using SharpGL;

namespace SharpGL_Application
{
    abstract class Stroke
    {
        public abstract void thicknessStroke(OpenGL Gl, int x, int y, int thickness = 0); 
    }
}
