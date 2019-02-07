﻿using Windows.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Disposables;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Shapes
{
	public abstract partial class ArbitraryShapeBase : Shape
	{
		private SerialDisposable _layer = new SerialDisposable();
		private object[] _layerState;

		protected static double LimitWithUserSize(double availableSize, double userSize, double naNFallbackValue)
		{
			bool hasUserSize = userSize != 0 && !double.IsNaN(userSize) && !double.IsInfinity(userSize);
			var hasAvailableSize = !double.IsNaN(availableSize);

#if __WASM__
			// The measuring algorithms for shapes in Wasm and iOS/Android/macOS are not using the
			// infinity the same way.
			// Those implementation will need to be merged.
			hasAvailableSize &= !double.IsInfinity(availableSize);
#endif

			if (hasUserSize && hasAvailableSize)
			{
				return Math.Min(userSize, availableSize);
			}

			if (hasAvailableSize)
			{
				return availableSize;
			}

			//If both availableSize and userSize are NaN, use the fallback.
			return naNFallbackValue;
		}

#if !__WASM__
		protected internal override void OnInvalidateMeasure()
		{
			base.OnInvalidateMeasure();
			RefreshShape(true);
		}
#endif

		/// <summary>
		/// Refreshes the current shape, considering its drawinf parameters.
		/// </summary>
		/// <param name="forceRefresh">Forces a refresh by ignoring the shape parameters.</param>
		protected internal override void RefreshShape(bool forceRefresh = false)
		{
			if (IsLoaded)
			{
				var newLayerState = GetShapeParameters().ToArray();

				var hasChanged = !(_layerState?.SequenceEqual(newLayerState) ?? false);

				if (hasChanged || forceRefresh)
				{
					// Remove the previous layer
					_layer.Disposable = null;

					_layerState = newLayerState;

					_layer.Disposable = BuildDrawableLayer();
				}
			}
		}

		/// <summary>
		/// Provides a enumeration of values that are used to determine if the shape
		/// should be rebuilt. Inheritors should append the base's enumeration.
		/// </summary>
		protected internal virtual IEnumerable<object> GetShapeParameters()
		{
			yield return GetActualSize();
			yield return Fill;
			yield return Stroke;
			yield return StrokeThickness;
			yield return Stretch;
			yield return StrokeDashArray;
			yield return _scaleX;
			yield return _scaleY;
		}

		/// <summary>
		/// Gets whether the shape should preserve the path's origin (and ignore StrokeThickness)
		/// </summary>
		protected bool ShouldPreserveOrigin => this is Path && Stretch == Stretch.None;
	}
}
