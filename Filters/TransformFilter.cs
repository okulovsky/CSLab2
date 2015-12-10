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
        public Func<Size, TParameters, Size> sizeTransform;
        public Func<Size, Point, TParameters, Point?> pointTransform;
        string name;

        public override string ToString()
        {
            return name;
        }

        public TransformFilter(string name, Func<Size, TParameters, Size> sizeTransform, Func<Size, Point, TParameters, Point?> pointTransform)
        {
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
            this.name = name;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize,parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x=0;x<newSize.Width;x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = pointTransform(oldSize, new Point(x, y), parameters);
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }
    }
}
