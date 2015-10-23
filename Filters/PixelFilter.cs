using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters parameters)
            : base(parameters)
        { }

        public override Photo Process(Photo original, IParameters parameters)
        {
            var result = new Photo(original.Width, original.Height);

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    for (int z = 0; z < 3; z++)
                        result[x, y] = ProcessPixel(original[x, y], parameters);

            return result;
        }

        public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);
    }
}
