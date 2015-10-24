using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LighteningParameters>
	{



		public override string ToString ()
		{
			return "Осветление/затемнение";
		}



        public override Pixel ProcessPixel(Pixel original, LighteningParameters parameters)
        {
            return original * parameters.Coefficient;
        }
	}
}

