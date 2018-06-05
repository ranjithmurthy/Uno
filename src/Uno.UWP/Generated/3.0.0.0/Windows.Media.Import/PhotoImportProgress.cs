#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Import
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial struct PhotoImportProgress 
	{
		// Forced skipping of method Windows.Media.Import.PhotoImportProgress.PhotoImportProgress()
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  uint ItemsImported;
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  uint TotalItemsToImport;
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  ulong BytesImported;
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  ulong TotalBytesToImport;
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		public  double ImportProgress;
		#endif
	}
}