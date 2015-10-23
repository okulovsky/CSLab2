using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int Width;
		public readonly int Height;
		public readonly Pixel[,] data;
        public Photo(int width, int height)
        {
            Width = width;
            Height = height;
            data = new Pixel[width, height];
        }
	}
}

