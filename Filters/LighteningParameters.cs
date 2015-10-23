using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class LighteningParameters : IParameters
    {
        public double Coefficient { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
			{
				new ParameterInfo { Name="Коэффициент", MaxValue=10, MinValue=0, Increment=0.1, DefaultValue=1 }
			};
        }

        public void Parse(double[] values)
        {
            Coefficient = values[0];
        }
    }
}
