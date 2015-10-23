using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter
    {

        public GrayscaleFilter()
            : base(new EmptyParameters())
        { }

        public override string ToString()
        {
            return "Оттенки серого";
        }



        public override Pixel ProcessPixel(Pixel original, IParameters parameters)
        {
            var gray = 0.299 * original.R + 0.587 * original.G + 0.114 * original.B;
            return new Pixel(gray, gray, gray);
        }
    }
}
