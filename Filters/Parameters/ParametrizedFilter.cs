using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public abstract class ParametrizedFilter<TParameters> : IFilter
		where TParameters : IParameters, new()
	{
		public ParameterInfo[] GetParameters()
		{
			var parameters = new TParameters();
			return parameters.GetDescription();
		}
		public Photo Process(Photo original, double[] values)
		{
			var parameters = new TParameters();
			parameters.SetValues(values);
			return Process(original, parameters);
		}

		public abstract Photo Process(Photo original, TParameters parameters);
		
	}
}
