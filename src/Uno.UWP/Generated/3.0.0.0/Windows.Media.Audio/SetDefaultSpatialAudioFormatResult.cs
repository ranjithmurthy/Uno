#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Audio
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class SetDefaultSpatialAudioFormatResult 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::Windows.Media.Audio.SetDefaultSpatialAudioFormatStatus Status
		{
			get
			{
				throw new global::System.NotImplementedException("The member SetDefaultSpatialAudioFormatStatus SetDefaultSpatialAudioFormatResult.Status is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.Audio.SetDefaultSpatialAudioFormatResult.Status.get
	}
}
