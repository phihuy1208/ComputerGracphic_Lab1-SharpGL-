using System;
using System.Drawing;
using System.Windows.Forms;
using SharpGL;

namespace SharpGL_Application
{
    struct Coords
    {
        public int x;
        public int y;
    }

    public partial class Form1 : Form
    {
        float[] color = { 0, 0, 0, 1.0f };
        private static OpenGL Gl;

        private Point formLocation;
        private Coords[] listPoint = new Coords[3];

        private bool isShiftDown = false;
        private BasicShape shape;

        public Point FormLocation { get => formLocation; set => formLocation = value; }
        public Form1()
        {
            InitializeComponent();
            formLocation = Location;
        }

        private void initOpenGL()
        {
            Gl.MatrixMode(OpenGL.GL_PROJECTION);
            Gl.LoadIdentity();

            int height = openGLControl.Height;
            int width = openGLControl.Width;
            Gl.Ortho2D(0, width, 0, height);
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            Gl = openGLControl.OpenGL;
            /*          Gl.Ortho2D(0, width, 0, height);*/

            Gl.MatrixMode(OpenGL.GL_PROJECTION);
            Gl.LoadIdentity();

            Gl.ClearColor(1, 1, 1, 1);
            Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values
            int height = openGLControl.Height;
            int width = openGLControl.Width;
            Gl.Ortho2D(0, width, 0, height);
            Gl.Viewport(0, 0, width, height);
        }

        #region Button click Event
        private void Line_Click(object sender, EventArgs e)
        {
            shape = new Line();
            initOpenGL();
        }
        private void Circle_Click(object sender, EventArgs e)
        {
            shape = new Circle();
            initOpenGL();
        }
        private void Triangle_Click(object sender, EventArgs e)
        {
            shape = new Triangle();
            initOpenGL();
        }
        private void Square_Click(object sender, EventArgs e)
        {
            shape = new Square();
            initOpenGL();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Gl.ClearColor(1, 1, 1, 1);
            Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values 
        }
        #endregion

        #region Mouse Event
        bool isMouseDown = false;
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            listPoint[0].x = e.X;
            listPoint[0].y = openGLControl.Height - e.Y;
            isMouseDown = true;
        }       
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && shape != null)
            {
                listPoint[1].x = e.X;
                listPoint[1].y = openGLControl.Height - e.Y;
                Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values
                if (isShiftDown)
                    shape.drawShape_shift(Gl, listPoint[0], listPoint[1], color);
                else
                    shape.drawShape_unshift(Gl, listPoint[0], listPoint[1], color);
            }
        }
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            listPoint[2].x = e.X;
            listPoint[2].y = openGLControl.Height - e.Y;
            isMouseDown = false;
            if (shape != null)
                if (isShiftDown)
                    shape.drawShape_shift(Gl, listPoint[0], listPoint[2], color);
                else
                    shape.drawShape_unshift(Gl, listPoint[0], listPoint[2], color);

        }
        #endregion



        #region Set Color
        private void Red_Click(object sender, EventArgs e)
        {
            color[0] = (float)Red.BackColor.R / 255;
            color[1] = (float)Red.BackColor.G / 255;
            color[2] = (float)Red.BackColor.B / 255;
            color[3] = (float)Red.BackColor.A / 255;
        }
        private void Green_Click(object sender, EventArgs e)
        {
            color[0] = (float)Green.BackColor.R / 255;
            color[1] = (float)Green.BackColor.G / 255;
            color[2] = (float)Green.BackColor.B / 255;
            color[3] = (float)Green.BackColor.A / 255;
        }
        private void Blue_Click(object sender, EventArgs e)
        {
            color[0] = (float)Blue.BackColor.R / 255;
            color[1] = (float)Blue.BackColor.G / 255;
            color[2] = (float)Blue.BackColor.B / 255;
            color[3] = (float)Blue.BackColor.A / 255;
        }
        private void Purple_Click(object sender, EventArgs e)
        {
            color[0] = (float)Purple.BackColor.R / 255;
            color[1] = (float)Purple.BackColor.G / 255;
            color[2] = (float)Purple.BackColor.B / 255;
            color[3] = (float)Purple.BackColor.A / 255;
        }
        private void Teal_Click(object sender, EventArgs e)
        {
            color[0] = (float)Teal.BackColor.R / 255;
            color[1] = (float)Teal.BackColor.G / 255;
            color[2] = (float)Teal.BackColor.B / 255;
            color[3] = (float)Teal.BackColor.A / 255;
        }

        #endregion

        #region Keyboard event
        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) isShiftDown = true;
        }

        private void openGLControl_KeyUp(object sender, KeyEventArgs e)
        {
            isShiftDown = false;
        }
        #endregion
    }
}
