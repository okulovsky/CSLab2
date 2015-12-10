using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        ITransformer<TParameters> transformer;
        string name;

        public override string ToString()
        {
            return name;
        }

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {

            var oldSize = new Size(original.Width, original.Height);
            transformer.Initialize(parameters, oldSize);
            var newSize = transformer.ResultingSize;
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x=0;x<newSize.Width;x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = transformer.GetPointPrototype(new Point(x, y));
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }
    }
}
