using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int Width;
		public readonly int Height;
		private readonly Pixel[,] data;
        public Photo(int width, int height)
        {
            Width = width;
            Height = height;
            data = new Pixel[width, height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    data[x, y] = new Pixel();
        }

        public Pixel this[int x, int y]
        {
            get
            {
                return data[x, y];
            }
        }
	}
}

