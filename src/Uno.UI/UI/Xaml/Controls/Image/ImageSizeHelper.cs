using System;
using System.Collections.Generic;
using System.Text;
using static Windows.UI.Xaml.Media.Stretch;

namespace Windows.UI.Xaml.Controls
{
	internal static class ImageSizeHelper
	{
		public static void MeasureSource(this Image image, Windows.Foundation.Rect parent, ref Windows.Foundation.Rect child)
		{
			switch (image.Stretch)
			{
				case UniformToFill:
					var uniformToFillScale = (child.Width * parent.Height >= child.Height * parent.Width)
						? parent.Height / child.Height // child is flatter than parent
						: parent.Width / child.Width; // child is taller than parent
					child.Width *= uniformToFillScale;
					child.Height *= uniformToFillScale;
					break;

				case Uniform:
					var uniformScale = (child.Width * parent.Height > child.Height * parent.Width)
						? parent.Width / child.Width // child is taller than parent
						: parent.Height / child.Height; // child is flatter than parent
					child.Width *= uniformScale;
					child.Height *= uniformScale;
					break;

				case Fill:
					child.Width = parent.Width;
					child.Height = parent.Height;
					break;

				case None:
					break;
			}
		}

		public static void ArrangeSource(this Image image, Windows.Foundation.Rect parent, ref Windows.Foundation.Rect child)
		{
			// In order to match UWP behaviors, in some specific cases the image must be left align
			var isForcedLeft = (image.Stretch == None || image.Stretch == UniformToFill) && parent.Width <= child.Width;

			switch (image.HorizontalAlignment)
			{
				case HorizontalAlignment.Left:
					child.X = 0;
					break;
				case HorizontalAlignment.Right:
					child.X = isForcedLeft && !Double.IsNaN(image.Width) ? 0 : parent.Width - child.Width;
					break;
				case HorizontalAlignment.Center:
					child.X = isForcedLeft && !Double.IsNaN(image.Width) ? 0 : (parent.Width * 0.5f) - (child.Width * 0.5f);
					break;
				case HorizontalAlignment.Stretch:
					child.X = isForcedLeft ? 0 : (parent.Width * 0.5f) - (child.Width * 0.5f);
					break;
			}

			// In order to match UWP behaviors, in some specific cases the image must be top align
			var isForcedTop = (image.Stretch == None || image.Stretch == UniformToFill) && parent.Height <= child.Height;

			switch (image.VerticalAlignment)
			{
				case VerticalAlignment.Top:
					child.Y = 0;
					break;
				case VerticalAlignment.Bottom:
					child.Y = isForcedTop && !Double.IsNaN(image.Height) ? 0 : parent.Height - child.Height;
					break;
				case VerticalAlignment.Center:
					child.Y = isForcedTop && !Double.IsNaN(image.Height) ? 0 : (parent.Height * 0.5f) - (child.Height * 0.5f);
					break;
				case VerticalAlignment.Stretch:
					child.Y = isForcedTop ? 0 : (parent.Height * 0.5f) - (child.Height * 0.5f);
					break;
			}
		}
	}
}
