using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
	public class FreeTransformer : ITransformer<EmptyParameters>
	{
		Func<Size, Size> sizeTransformer;
		Func<Point, Size, Point> pointTransformer;

		Size oldSize;

		public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer )
		{
			this.sizeTransformer = sizeTransformer;
			this.pointTransformer = pointTransformer;
		}

		public void Prepare(System.Drawing.Size size, EmptyParameters parameters)
		{
			oldSize = size;
			ResultSize = sizeTransformer(oldSize);
		}

		public System.Drawing.Size ResultSize
		{
			get;
			private set;
		}

		public System.Drawing.Point? MapPoint(System.Drawing.Point newPoint)
		{
			return pointTransformer(newPoint, oldSize);
		}
	}
}
