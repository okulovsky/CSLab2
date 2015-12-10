
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class RotateParameters : IParameters
    {
        [ParameterInfo(DefaultValue = 0, Increment = 10, MinValue = 0, MaxValue = 360, Name = "Угол")]
        public double Angle { get; set; }
    }
}
