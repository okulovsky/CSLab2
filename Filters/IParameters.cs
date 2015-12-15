using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public interface IParameters
	{
		ParameterInfo[] GetDescription();
		void SetValues(double[] values);
	}
}
