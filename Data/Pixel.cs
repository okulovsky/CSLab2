using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
    {
        void CheckAndSetArgument(double value, ref double field)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            field = value;
        }
        public double r;
        public double R { get { return r; } set { CheckAndSetArgument(value, ref r); } }
        public double g;
        public double G { get { return g; } set { CheckAndSetArgument(value, ref g); } }
        public double b;
        public double B { get { return b; } set { CheckAndSetArgument(value, ref b); } }

        public static double Trim(double value)
        {
            if (value<0) return 0;
            if (value>1) return 1;
            return value;
        }
    }
}
