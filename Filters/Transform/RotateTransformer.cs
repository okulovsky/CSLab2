using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class RotateTransformer : ITransformer<RotateParameters>
    {
        Size originalSize;
        double angle;


        public void Initialize(RotateParameters parameters, System.Drawing.Size originalSize)
        {
            this.originalSize = originalSize;
            angle = parameters.Angle * Math.PI / 180;
            ResultingSize = new Size(
                    (int)(originalSize.Width * Math.Abs(Math.Cos(angle)) + originalSize.Height * Math.Abs(Math.Sin(angle))),
                    (int)(originalSize.Height * Math.Abs(Math.Cos(angle)) + originalSize.Width * Math.Abs(Math.Sin(angle))));
        }

        public System.Drawing.Size ResultingSize
        {
            get;
            private set;
        }

        public System.Drawing.Point? GetPointPrototype(System.Drawing.Point point)
        {
            point = new Point(point.X - ResultingSize.Width / 2, point.Y - ResultingSize.Height / 2);
            var x = originalSize.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
            var y = originalSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
            if (x < 0 || x >= originalSize.Width || y < 0 || y >= originalSize.Height) return null;
            return new Point(x, y);
        }
    }
}
