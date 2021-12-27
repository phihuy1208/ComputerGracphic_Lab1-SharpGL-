using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL_Application
{
	class AffineTransform
	{
		double[,] _matrixTransform;//ma trận 3x3 biểu diễn phép biến đổi affine
		public void Translate(int dx, int dy) // xây dựng matrix transform cho phép tịnh tiến theo vector (dx,dy)
        {
			_matrixTransform = new double[,] { {1, 0, dx },
											{0, 1, dy},
											{0, 0, 1 } };

		}
		public void Rotate(double angle) //xây dựng matrix transform cho phép xoay 1 góc angle
        {
			_matrixTransform = new double[,] { {Math.Cos(angle), -Math.Sin(angle), 0 },
											   {Math.Sin(angle),  Math.Cos(angle), 0 },
											   {              0,                0, 1 } };
		}
		public void Scale(double sx, double sy)//xây dựng matrix transform cho phép tỉ lệ theo hệ số
        { 
			_matrixTransform = new double[,] { {sx,  0, 0 },
											   { 0, sy, 0 },
											   { 0,  0, 1 } };
		}
		public void TransformPoint(ref Coords point)//transform 1 điểm (x,y) theo matrix transform đã có
        {
			point.x = (int)Math.Round((_matrixTransform[0, 0] * point.x + _matrixTransform[0, 1] * point.y + _matrixTransform[0, 2]) /(_matrixTransform[2, 0] * point.x + _matrixTransform[2, 1] * point.y + _matrixTransform[2, 2]));

			point.y = (int)Math.Round((_matrixTransform[1, 0] * point.x + _matrixTransform[1, 1] * point.y + _matrixTransform[1, 2]) / (_matrixTransform[2, 0] * point.x + _matrixTransform[2, 1] * point.y + _matrixTransform[2, 2]));
		}

		public AffineTransform() { _matrixTransform = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }; }
		~AffineTransform() { }
	};

	class GeometricTransformer
	{
		public void Transform(ref BasicShape shape, AffineTransform transformer)
		{
			for (int i = 0; i < shape.ListPointOutput.Length; i++)
				transformer.TransformPoint(ref shape.ListPointOutput[i]);
		}
		public GeometricTransformer() { }
		~GeometricTransformer() { }
	};
}
