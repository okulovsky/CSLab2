using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter<EmptyParameters>
	{

		public override string ToString()
		{
			return "Оттенки серого";
		}



		public override Pixel ProcessPixel(Pixel original, EmptyParameters parameters)
		{
			var lightness = original.R + original.G + original.B;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
				
		}


	}
}

