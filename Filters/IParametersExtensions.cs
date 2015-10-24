using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyPhotoshop
{
    public static class IParametersExtensions
    {
        public static ParameterInfo[] GetDescription(this IParameters parameters)
        {
            return parameters.GetType().GetProperties()
                .Select(property => property.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(attrs => attrs.Length != 0)
                .Select(attrs => attrs[0])
                .Cast<ParameterInfo>()
                .ToArray();

        }
        public static void Parse(this IParameters parameters, double[] values)
        {
            var properties = parameters.GetType().GetProperties()
                .Where(property=>property.GetCustomAttributes(typeof(ParameterInfo),false).Length!=0)
                .ToArray();
            if (properties.Length != values.Length)
                throw new ArgumentException();
            for (int i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i], null);
        }
    }
}
