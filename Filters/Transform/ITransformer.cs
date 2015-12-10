using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public interface ITransformer<T>
    {
        void Initialize(T parameters, Size originalSize);
        Size ResultingSize { get; }
        Point? GetPointPrototype(Point point);
    }
}
