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
                        result[x, y] = new Pixel(
                            Pixel.Trim(original[x, y].R * parameters[0]),
                            Pixel.Trim(original[x, y].G * parameters[0]),
                            Pixel.Trim(original[x, y].B * parameters[0])
                            );
                    }
						
			return result;
		}
	}
}

