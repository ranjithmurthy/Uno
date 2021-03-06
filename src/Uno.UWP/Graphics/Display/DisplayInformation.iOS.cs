﻿#if __IOS__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Windows.Foundation;

namespace Windows.Graphics.Display
{
	public sealed partial class DisplayInformation
	{
		private object _didChangeStatusBarOrientationObserver;

		partial void Initialize()
		{
			InitializeOrientation();
		}

		private void InitializeOrientation()
		{
			_didChangeStatusBarOrientationObserver = NSNotificationCenter
				.DefaultCenter
				.AddObserver(
					UIApplication.DidChangeStatusBarOrientationNotification, 
					n => {
						UpdateCurrentOrientation();
						OrientationChanged?.Invoke(this, CurrentOrientation);
					}
				);

			UpdateCurrentOrientation();
		}

		private void UpdateCurrentOrientation()
		{
			var currentOrientationMask = UIApplication.SharedApplication
			   .StatusBarOrientation;

			switch (currentOrientationMask)
			{
				case UIInterfaceOrientation.LandscapeLeft:
					CurrentOrientation = DisplayOrientations.LandscapeFlipped;
					break;

				case UIInterfaceOrientation.LandscapeRight:
					CurrentOrientation = DisplayOrientations.Landscape;
					break;

				case UIInterfaceOrientation.Portrait:
					CurrentOrientation = DisplayOrientations.Portrait;
					break;

				case UIInterfaceOrientation.PortraitUpsideDown:
					CurrentOrientation = DisplayOrientations.PortraitFlipped;
					break;
			}

			NativeOrientation = CurrentOrientation;
		}

		public static UIInterfaceOrientationMask[] PreferredOrientations =
		{
			UIInterfaceOrientationMask.Portrait,
			UIInterfaceOrientationMask.LandscapeRight,
			UIInterfaceOrientationMask.LandscapeLeft,
			UIInterfaceOrientationMask.PortraitUpsideDown
		};

		static partial void SetOrientationPartial(DisplayOrientations orientations)
		{
			var currentOrientationMask = UIApplication.SharedApplication
			   .StatusBarOrientation
			   .ToUIInterfaceOrientationMask();

			var toOrientationMask = orientations.ToUIInterfaceOrientationMask();

			//If we are not already in one of the requested orientations, we need to force the application to rotate.
			if (!toOrientationMask.HasFlag(currentOrientationMask))
			{
				//Rotate to the most preferred orientation that is requested
				//e.g. if our mask is Portrait | PortraitUpsideDown, we prefer to intially rotate to Portrait rather than PortraitUpsideDown
				var toOrientation = PreferredOrientations.FirstOrDefault(ori => toOrientationMask.HasFlag(ori)).ToUIInterfaceOrientation();

				UIDevice.CurrentDevice
					.SetValueForKey(
						new NSNumber((int)toOrientation),
						new NSString("orientation")
					);

				UIApplication.SharedApplication.SetStatusBarOrientation(toOrientation, false);
			}

			//Forces the rotation if the physical device is being held in an orientation that has now become supported
			UIViewController.AttemptRotationToDeviceOrientation();
		}

	}
}
#endif