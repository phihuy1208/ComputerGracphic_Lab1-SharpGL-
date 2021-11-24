using SharpGL;

namespace SharpGL_Application
{
    interface BasicShape
    {
/*        void drawShape(OpenGL Gl, Coords[] listPoint, float[] color);*/
        void drawShape_shift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color);
        void drawShape_unshift(OpenGL Gl, Coords firstPoint, Coords lastPoint, float[] color);
    }
}
