using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<T> : IFilter
        where T : IParameters, new()
    {
        public ParameterInfo[] GetParameters()
        {
            return new T().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new T();
            parameters.Parse(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, T parameters);
    }
}
