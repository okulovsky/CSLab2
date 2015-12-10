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




            var mirrorHorizontal = new TransformFilter("Отразить по горизонтали",
                size => size,
                (oldSize, point) => new Point(oldSize.Width - point.X-1, point.Y)
                );
            window.AddFilter(mirrorHorizontal);

            var rotateClockwise = new TransformFilter("Повернуть против ч.с.",
                size => new Size(size.Height, size.Width),
                (oldSize, point) => new Point(point.Y, point.X)
                );
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
