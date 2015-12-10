using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    internal class FreeTransformer<TParameters> : ITransformer<TParameters>
    {
        public Func<Size, TParameters, Size> SizeTransformer;
        public Func<Size, Point, TParameters, Point?> PointTransformer;
        TParameters parameters;
        Size originalSize;

        public void Initialize(TParameters parameters, System.Drawing.Size originalSize)
        {
            ResultingSize = SizeTransformer(originalSize, parameters);
            this.parameters = parameters;
            this.originalSize = originalSize;
        }

        public System.Drawing.Size ResultingSize
        {
            get;
            private set;
        }

        public System.Drawing.Point? GetPointPrototype(System.Drawing.Point point)
        {
            return PointTransformer(originalSize, point, parameters);
        }
    }
}
