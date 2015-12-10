using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{

        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();




            var mirrorHorizontal = new TransformFilter<EmptyParameters>("Отразить по горизонтали",
                (size, parameters) => size,
                (oldSize, point, parameters) => new Point(oldSize.Width - point.X-1, point.Y)
                );
            window.AddFilter(mirrorHorizontal);

            Func<Size, RotateParameters, Size> sizeRotator = (size, parameters) =>
                {
                    var angle = Math.PI * parameters.Angle / 180;
                    return new Size(
                    (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
                    (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
                };

            Func<Size,Point,RotateParameters,Point?> pointRotator = (oldSize, point, parameters)=>
                {
                    var newSize = sizeRotator(oldSize,parameters);
                    var angle = Math.PI*parameters.Angle/180;
                    point=new Point(point.X-newSize.Width/2,point.Y-newSize.Height/2);                                                                              
                    var x = oldSize.Width/2 + (int)(point.X*Math.Cos(angle)+point.Y*Math.Sin(angle));
                    var y = oldSize.Height/2 + (int)(-point.X*Math.Sin(angle)+point.Y*Math.Cos(angle));
                    if (x<0 || x>=oldSize.Width || y<0 || y>=oldSize.Height) return null;
                    return new Point(x,y);
                };

            var rotateClockwise = new TransformFilter<RotateParameters>("Повернуть", sizeRotator, pointRotator);
            window.AddFilter(rotateClockwise);

            var lighteningFilter = new PixelFilter<LighteningParameters>("Осветление/затемнение", (pixel, parameters) => pixel * parameters.Coefficient);
            window.AddFilter(lighteningFilter);

            var grayscaleFilter = new PixelFilter<EmptyParameters>("Оттенки серого",
                (original, parameters) =>
                {
                    var gray = 0.299 * original.R + 0.587 * original.G + 0.114 * original.B;
                    return new Pixel(gray, gray, gray);
                });
            window.AddFilter(grayscaleFilter);


			Application.Run (window);
		}
	}
}
