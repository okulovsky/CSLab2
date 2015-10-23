using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{

        public LighteningFilter()
            : base(new LighteningParameters())
        { }

		public override string ToString ()
		{
			return "Осветление/затемнение";
		}



        public override Pixel ProcessPixel(Pixel original, IParameters parameters)
        {
            return original * (parameters as LighteningParameters).Coefficient;
        }
	}
}

