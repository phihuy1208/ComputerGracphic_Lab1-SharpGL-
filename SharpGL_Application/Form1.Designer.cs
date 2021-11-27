
namespace SharpGL_Application
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Line = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SetColor = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ThicknessStroke = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessStroke)).BeginInit();
            this.SuspendLayout();
            // 
            // Line
            // 
            resources.ApplyResources(this.Line, "Line");
            this.Line.Name = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Triangle
            // 
            resources.ApplyResources(this.Triangle, "Triangle");
            this.Triangle.Name = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            this.Triangle.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // Square
            // 
            resources.ApplyResources(this.Square, "Square");
            this.Square.Name = "Square";
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Circle
            // 
            resources.ApplyResources(this.Circle, "Circle");
            this.Circle.Name = "Circle";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Ellipse
            // 
            resources.ApplyResources(this.Ellipse, "Ellipse");
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            resources.ApplyResources(this.Clear, "Clear");
            this.Clear.Name = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // SetColor
            // 
            this.SetColor.BackColor = System.Drawing.Color.Black;
            this.SetColor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.SetColor, "SetColor");
            this.SetColor.Name = "SetColor";
            this.SetColor.UseVisualStyleBackColor = false;
            this.SetColor.Click += new System.EventHandler(this.SetColor_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.button12, "button12");
            this.button12.Name = "button12";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.button13, "button13");
            this.button13.Name = "button13";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.button14, "button14");
            this.button14.Name = "button14";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.button15, "button15");
            this.button15.Name = "button15";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // openGLControl
            // 
            resources.ApplyResources(this.openGLControl, "openGLControl");
            this.openGLControl.Cursor = System.Windows.Forms.Cursors.Cross;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyDown);
            this.openGLControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyUp);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ThicknessStroke
            // 
            resources.ApplyResources(this.ThicknessStroke, "ThicknessStroke");
            this.ThicknessStroke.Name = "ThicknessStroke";
            this.ThicknessStroke.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThicknessStroke.ValueChanged += new System.EventHandler(this.ThicknessStroke_ValueChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.ThicknessStroke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Ellipse);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.SetColor);
            this.Controls.Add(this.Line);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessStroke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button SetColor;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ThicknessStroke;
    }
}

