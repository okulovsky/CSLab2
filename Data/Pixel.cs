﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
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

        public Pixel(double _r, double _g, double _b)
        {
            r = b = g = 0;
            R = _r;
            G = _g;
            B = _b;
        }
        

        public static double Trim(double value)
        {
            if (value<0) return 0;
            if (value>1) return 1;
            return value;
        }

        public static Pixel operator *(Pixel pixel, double c)
        {
            return new Pixel(
                Trim(pixel.R * c),
                Trim(pixel.G * c),
                Trim(pixel.B * c));
        }
    }
}