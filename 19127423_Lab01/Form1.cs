using System;
using System.Drawing;
using System.Windows.Forms;
using SharpGL;

namespace SharpGL_Application
{
    /// <summary>
    /// Cấu trúc struct dùng để lưu tọa độ của 1 điểm trên màn hình
    /// </summary>
    struct Coords
    {
        public int x;
        public int y;

        public Coords(int x, int y) { this.x = x; this.y = y; }

        // tịnh tiến 1 điểm dựa vào điểm truyền vào
        public void translate(Coords point) { this.x += point.x; this.y += point.y; }
        public Coords translate(int x, int y) 
        {
            Coords temp = new Coords(this.x, this.y);
            temp.x += x; temp.y += y; return temp;  
        }
    }
    
    public partial class Form1 : Form
    {
        private Color getSharpColor;
        float[] color = { 0, 0, 0, 1.0f };
        private static OpenGL Gl;
        private BasicShape[] shape = new BasicShape[100];
        
        // Biến lưu trữ giá trị màu

        // Biến kiểm tra có đang bấm phím shift trên bàn phím hay không
        private bool isShiftDown = false;

        // Biến lưu giá trị độ dày mỏng của nét vẽ
        private int thickness = 0;
        private int shapeIndex;

        // Biến lưu hình dạng của hình đang vẽ
        private int typeOfShape = -1;
        public Form1()
        {
            InitializeComponent();
            clock.Start();
            shapeIndex = 0;
        }

        /// <summary>
        /// Hàm khởi tạo openGL: khởi tạo chế dộ vẽ, khởi tạo tọa độ vẽ, khởi tạo khung nhìn
        /// </summary>
        private void initOpenGL()
        {
            Gl.MatrixMode(OpenGL.GL_PROJECTION);
            Gl.LoadIdentity();

            int height = openGLControl.Height;
            int width = openGLControl.Width;
            Gl.Ortho2D(0, width, 0, height);
            Gl.Viewport(0, 0, width, height);
        }

        /// <summary>
        /// Hàm xử lí sự kiện khi màn hình openGL được khởi tạo (sau khi form khởi tạo)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            Gl = openGLControl.OpenGL;
            Gl.ClearColor(1, 1, 1, 1);
            Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values
            initOpenGL();
        }

        #region Hàm xử lí sự kiện khi click vào các nút nhấn trên màn hình
        private void Line_Click(object sender, EventArgs e)
        {
            typeOfShape = 1;
            shape[shapeIndex] = new Line(openGLControl);
            initOpenGL();
        }
        private void Triangle_Click(object sender, EventArgs e)
        {
            typeOfShape = 2;
            shape[shapeIndex] = new Triangle(openGLControl);
            initOpenGL();
        }
        private void Square_Click(object sender, EventArgs e)
        {
            typeOfShape = 3;
            shape[shapeIndex] = new Square(openGLControl);
            initOpenGL();
        }
/*        private void Circle_Click(object sender, EventArgs e)
        {
            typeOfShape = 4;
            shape[shapeIndex] = new Circle(openGLControl);
            initOpenGL();
        }*/
        private void Polygon_Click(object sender, EventArgs e)
        {
            typeOfShape = 5;
            shape[shapeIndex] = new Polygon(openGLControl);
            initOpenGL();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            typeOfShape = 0;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            shapeIndex = 0;
            shape = new BasicShape[100];
            Gl.ClearColor(1, 1, 1, 1);
            Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values 
            switch (typeOfShape)
            {
                case 1:
                    shape[shapeIndex] = new Line(openGLControl);
                    break;
                case 2:
                    shape[shapeIndex] = new Triangle(openGLControl);
                    break;
                case 3:
                    shape[shapeIndex] = new Square(openGLControl);
                    break;
                case 4:
                    shape[shapeIndex] = new Circle(openGLControl);
                    break;
                case 5:
                    shape[shapeIndex] = new Polygon(openGLControl);
                    break;
                default:
                    break;
            }
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

        #region Hàm xử lí sự kiện khi dùng chuột tương tác với màn hình vẽ
        bool isMouseDown = false;
        int shapeSelected = -1;
        int vertexSelected = -1;
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (shape[shapeIndex] != null && typeOfShape != 5 && typeOfShape != 0)
            {
                shape[shapeIndex].ListPointInput[0].x = e.X;
                shape[shapeIndex].ListPointInput[0].y = openGLControl.Height - e.Y;
                shape[shapeIndex].Direct = false;
            }
            else if (typeOfShape == 0)
            {
                for (int i = 0; i < shapeIndex; ++i)
                    if (shape[i].nearbyShape(new Coords(e.X, openGLControl.Height - e.Y)))
                    {
                        shapeSelected = i;
                        break;
                    }

                if (shapeSelected >= 0)
                    for (int i = 0; i < shape[shapeSelected].NVertex; i++)
                    {
                        if ((e.X > shape[shapeSelected].ListPointOutput[i].x - 5 &&
                            e.X < shape[shapeSelected].ListPointOutput[i].x + 5) &&
                            (openGLControl.Height - e.Y > shape[shapeSelected].ListPointOutput[i].y - 5 &&
                            openGLControl.Height - e.Y < shape[shapeSelected].ListPointOutput[i].y + 5))
                        {
                            vertexSelected = i;
                            break;
                        }
                    }
            }
        }      
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && typeOfShape != 5 && typeOfShape != 0)
            {
                shape[shapeIndex].ListPointInput[2].x = e.X;
                shape[shapeIndex].ListPointInput[2].y = openGLControl.Height - e.Y;

                Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                for (int i = 0; i < shapeIndex; i++)
                    if (shape[i].GetType().ToString() == "SharpGL_Application.Polygon")
                        shape[i].drawShape_shift(color, thickness);
                    else
                        shape[i].drawShape_unshift(color, thickness);

                if (isShiftDown)
                    shape[shapeIndex].drawShape_shift(color, thickness);
                else
                    shape[shapeIndex].drawShape_unshift(color, thickness);
            }
            else if (typeOfShape == 5)
            {
                if (isMouseDown)
                {
                    Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                    for (int i = 0; i < shapeIndex; i++)
                        if (shape[i].GetType().ToString() == "SharpGL_Application.Polygon")
                            shape[i].drawShape_shift(color, thickness);
                        else
                            shape[i].drawShape_unshift(color, thickness);

                    shape[shapeIndex].ListPointInput[shape[shapeIndex].NVertex].x = e.X;
                    shape[shapeIndex].ListPointInput[shape[shapeIndex].NVertex].y = openGLControl.Height - e.Y;
                    shape[shapeIndex].drawShape_unshift(color, thickness);
                }
            }
            else if (typeOfShape == 0)
            {
                if (vertexSelected >= 0 && isMouseDown)
                {
                    if (shape[shapeSelected].GetType().ToString() == "SharpGL_Application.Line")
                    {
                        shape[shapeSelected].ListPointInput[vertexSelected == 1 ? 2 : vertexSelected].x = e.X;
                        shape[shapeSelected].ListPointInput[vertexSelected == 1 ? 2 : vertexSelected].y = openGLControl.Height - e.Y;
                    }
                    else
                    {
                        shape[shapeSelected].Direct = true;
                        shape[shapeSelected].ListPointOutput[vertexSelected].x = e.X;
                        shape[shapeSelected].ListPointOutput[vertexSelected].y = openGLControl.Height - e.Y;
                    }

                    Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                    for (int i = 0; i < shapeIndex; i++)
                        if (shape[i].GetType().ToString() == "SharpGL_Application.Polygon")
                            shape[i].drawShape_shift(color, thickness);
                        else
                            shape[i].drawShape_unshift(color, thickness);
                }
            }
        }
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (shape[shapeIndex] != null && typeOfShape != 5 && typeOfShape != 0)
            {
                shape[shapeIndex].ListPointInput[2].x = e.X;
                shape[shapeIndex].ListPointInput[2].y = openGLControl.Height - e.Y;
                isMouseDown = false;
                if (isShiftDown)
                    shape[shapeIndex].drawShape_shift(color, thickness);
                else
                    shape[shapeIndex].drawShape_unshift(color, thickness);
                shape[shapeIndex].Direct = true;
                shapeIndex++;
                switch (typeOfShape)
                {
                    case 1:
                        shape[shapeIndex] = new Line(openGLControl);
                        break;
                    case 2:
                        shape[shapeIndex] = new Triangle(openGLControl);
                        break;
                    case 3:
                        shape[shapeIndex] = new Square(openGLControl);
                        break;
                    case 4:
                        shape[shapeIndex] = new Circle(openGLControl);
                        break;
                    default:
                        break;
                }
            }
            else if (typeOfShape == 0)
            {
                if (vertexSelected >= 0)
                {
                    if (shape[shapeSelected].GetType().ToString() == "SharpGL_Application.Line")
                    {
                        shape[shapeSelected].ListPointInput[vertexSelected == 1 ? 2 : vertexSelected].x = e.X;
                        shape[shapeSelected].ListPointInput[vertexSelected == 1 ? 2 : vertexSelected].y = openGLControl.Height - e.Y;
                    }else
                    {
                        shape[shapeSelected].Direct = true;
                        shape[shapeSelected].ListPointOutput[vertexSelected].x = e.X;
                        shape[shapeSelected].ListPointOutput[vertexSelected].y = openGLControl.Height - e.Y;
                    }

                    Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                    for (int i = 0; i < shapeIndex; i++)
                        if (shape[i].GetType().ToString() == "SharpGL_Application.Polygon")
                            shape[i].drawShape_shift(color, thickness);
                        else
                            shape[i].drawShape_unshift(color, thickness);
                    shapeSelected = -1; vertexSelected = -1;
                }
            }
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            Coords clickPoint = new Coords(e.X, openGLControl.Height - e.Y);

            if (typeOfShape == 0 && shapeSelected >= 0)
                shape[shapeSelected].highlight();

            if (typeOfShape == 5 && e.Button == MouseButtons.Left)
            {
/*                isMouseDown = true;*/
                shape[shapeIndex].ListPointInput[shape[shapeIndex].NVertex].x = e.X;
                shape[shapeIndex].ListPointInput[shape[shapeIndex].NVertex].y = openGLControl.Height - e.Y;
                shape[shapeIndex].drawShape_unshift(color, thickness);
                ++shape[shapeIndex].NVertex;
            }
            else if (typeOfShape == 5 && e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
                shape[shapeIndex].drawShape_shift(color, thickness);
                shapeIndex++;
                Gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                for (int i = 0; i < shapeIndex; i++)
                    if (shape[i].GetType().ToString() == "SharpGL_Application.Polygon")
                        shape[i].drawShape_shift(color, thickness);
                    else
                        shape[i].drawShape_unshift(color, thickness);
                shape[shapeIndex] = new Polygon(openGLControl);
            }
        }
        #endregion

        #region Hàm xử lí sự kiện khi nhấn chuột vào nút Set Color để thay đổi màu vẽ

        private void button7_Click(object sender, EventArgs e)
        {
            var clrDlg = new ColorDialog { Color = getSharpColor };
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                getSharpColor = clrDlg.Color;
            }
        }

        #endregion

        #region Hàm xử lí sự kiện khi nhấn phím shift trên màn hình
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
