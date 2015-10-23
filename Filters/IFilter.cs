using System;

namespace MyPhotoshop
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
        /// <summary>
        /// ���� ����� ������ ���������� �������� ����������, ������� ���������� � NumericUpDown-��������
        /// ����� �� �������� ������ �������
        /// </summary>
        /// <returns></returns>
  	    ParameterInfo[] GetParameters();
        /// <summary>
        /// ���� ����� ��������� ����������, ������� ���� ������������, � ��������� �������� ���� ����������
        /// ����� ������� parameters � �������� ����� ����� �������, ������������� ������� GetParameters
        /// </summary>
        /// <param name="original"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
		Photo Process(Photo original, double[] parameters);
	}
}

