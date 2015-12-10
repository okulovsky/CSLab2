using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        public Func<Size, Size> sizeTransform;
        public Func<Size, Point, Point> pointTransform;
        string name;

        public override string ToString()
        {
            return name;
        }

        public TransformFilter(string name, Func<Size, Size> sizeTransform, Func<Size, Point, Point> pointTransform)
        {
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
            this.name = name;
        }

        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x=0;x<newSize.Width;x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = pointTransform(oldSize, new Point(x, y));
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }
            return result;
        }
    }
}
