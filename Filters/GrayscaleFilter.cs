using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }


        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.Width, original.Height);

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    for (int z = 0; z < 3; z++)
                        result[x, y] = ProcessPixel(original[x, y], parameters);

            return result;
        }

        public Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var gray = 0.299 * original.R + 0.587 * original.G + 0.114 * original.B;
            return new Pixel(gray, gray, gray);
        }
    }
}
