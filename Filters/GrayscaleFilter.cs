using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter
    {
        public override ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }



        public override Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var gray = 0.299 * original.R + 0.587 * original.G + 0.114 * original.B;
            return new Pixel(gray, gray, gray);
        }
    }
}
