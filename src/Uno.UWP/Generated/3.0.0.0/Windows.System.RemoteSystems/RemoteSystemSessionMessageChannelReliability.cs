#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.System.RemoteSystems
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public   enum RemoteSystemSessionMessageChannelReliability 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Reliable,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Unreliable,
		#endif
	}
	#endif
}