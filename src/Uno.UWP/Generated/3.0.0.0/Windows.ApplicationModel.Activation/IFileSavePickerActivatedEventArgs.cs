#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Activation
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IFileSavePickerActivatedEventArgs : global::Windows.ApplicationModel.Activation.IActivatedEventArgs
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		global::Windows.Storage.Pickers.Provider.FileSavePickerUI FileSavePickerUI
		{
			get;
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Activation.IFileSavePickerActivatedEventArgs.FileSavePickerUI.get
	}
}
