using System;

namespace MyPhotoshop
{
	public class LighteningFilter : IFilter
	{
		public ParameterInfo[] GetParameters()
		{
			return new []
			{
				new ParameterInfo { Name="Коэффициент", MaxValue=10, MinValue=0, Increment=0.1, DefaultValue=1 }
				
			};
		}
		
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}

		
		public Photo Process(Photo original, double[] parameters)
		{
			var result=new Photo(original.Width,original.Height);
			
			for (int x=0;x<result.Width;x++)
				for (int y=0;y<result.Height;y++)
					for (int z=0;z<3;z++)
                    {
                        result.data[x, y] = new Pixel();
                        result.data[x, y].R = Pixel.Trim(original.data[x, y].R * parameters[0]);
                        result.data[x, y].G = Pixel.Trim(original.data[x, y].G * parameters[0]);
                        result.data[x, y].B = Pixel.Trim(original.data[x, y].B * parameters[0]);
                    }
						
			return result;
		}
	}
}

