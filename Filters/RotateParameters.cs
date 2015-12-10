
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class RotateParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
                {
                new ParameterInfo { DefaultValue = 0, Increment = 10, MinValue = 0, MaxValue = 360, Name = "Угол" }
                };
        }

        public void Parse(double[] values)
        {
            Angle = values[0];
        }
    }
}
