using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : IFilter
	{
		public ParameterInfo[] GetParameters()
		{
			return new ParameterInfo[0];
		}
		
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		
		public Photo Process(Photo original, double[] parameters)
		{
			var result=new Photo(original.Width,original.Height);
			
			for (int x=0;x<result.Width;x++)
				for (int y=0;y<result.Height;y++)
					for (int z=0;z<3;z++)
                    {
                        var gray = 0.299 * original[x, y].R + 0.587 * original[x, y].G + 0.114 * original[x, y].B;
                        result[x, y] = new Pixel(gray,gray,gray);
                    }
			return result;
		}
	}
}

