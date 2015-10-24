using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class PixelFilter<T> : ParametrizedFilter<T>
        where T : IParameters, new()
    {
        Func<Pixel, T, Pixel> processor;
        string name;
        public PixelFilter(string name, Func<Pixel,T,Pixel> processor)
        {
            this.name = name;
            this.processor = processor;
        }

        public override string ToString()
        {
            return name;
        }

        public override Photo Process(Photo original, T parameters)
        {
            var result = new Photo(original.Width, original.Height);

            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    for (int z = 0; z < 3; z++)
                        result[x, y] = processor(original[x, y], parameters);

            return result;
        }
    }
}
