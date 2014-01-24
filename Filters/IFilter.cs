using System;

namespace Lab2
{
	public class ParameterInfo
	{
		public string Name;
		public double DefaultValue;
		public double MinValue=0;
		public double MaxValue=1;
		public double Increment;
	}
	
	public interface IFilter
	{
  	    ParameterInfo[] GetParameters();
		Photo Process(Photo original, double[] parameters);
	}
}

