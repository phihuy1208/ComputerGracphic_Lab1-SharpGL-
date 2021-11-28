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

        public Coords(int x, int y) { this.x = x; this.y = y; }

        public void translate(Coords point) { this.x += point.x; this.y += point.y; }
    }
    
    public partial class Form1 : Form
    {
        float[] color = { 0, 0, 0, 1.0f };
        private Color getSharpColor;

        private static OpenGL Gl;

        private Coords[] listPoint = new Coords[3];

        private bool isShiftDown = false;
        private BasicShape shape;
        private int thickness = 0;

        public Form1()
        {
            InitializeComponent();
            clock.Start();
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
        private void Polygon_Click(object sender, EventArgs e)
        {
            shape = new Polygon();
            initOpenGL();
        }
        private void SetColor_Click(object sender, EventArgs e)
        {
            var clrDlg = new ColorDialog { Color = getSharpColor };
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                getSharpColor = clrDlg.Color;
            }
            color[0] = (float)getSharpColor.R / 255;
            color[1] = (float)getSharpColor.G / 255;
            color[2] = (float)getSharpColor.B / 255;
            color[3] = (float)getSharpColor.A / 255;

            SetColor.BackColor = getSharpColor;
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
                    shape.drawShape_shift(Gl, listPoint[0], listPoint[1], color, thickness);
                else
                    shape.drawShape_unshift(Gl, listPoint[0], listPoint[1], color, thickness);
            }
        }
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            listPoint[2].x = e.X;
            listPoint[2].y = openGLControl.Height - e.Y;
            isMouseDown = false;
            if (shape != null)
                if (isShiftDown)
                    shape.drawShape_shift(Gl, listPoint[0], listPoint[2], color, thickness);
                else
                    shape.drawShape_unshift(Gl, listPoint[0], listPoint[2], color, thickness);

        }
        #endregion

        #region Set Color
       
        private void button7_Click(object sender, EventArgs e)
        {
            var clrDlg = new ColorDialog { Color = getSharpColor };
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                getSharpColor = clrDlg.Color;
            }
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

        // hàm xử lý sự kiện khi thay đổi giá trị tại numbericupdown control
        private void ThicknessStroke_ValueChanged(object sender, EventArgs e)
        {
            if (ThicknessStroke.Value < 1)
                ThicknessStroke.Value = 1;
            thickness = (int)ThicknessStroke.Value - 1;
        }

        // Hàm xử lý sự kiện khi thời gian thay đổi
        private void clock_Tick(object sender, EventArgs e)
        {
            Hour_Minute.Text = DateTime.Now.ToString("HH:mm");
            Second.Text = DateTime.Now.ToString("ss");
            Date.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
