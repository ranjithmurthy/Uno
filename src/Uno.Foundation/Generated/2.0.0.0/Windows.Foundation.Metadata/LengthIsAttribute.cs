#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Foundation.Metadata
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class LengthIsAttribute : global::System.Attribute
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public LengthIsAttribute( int indexLengthParameter) : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Foundation.Metadata.LengthIsAttribute", "LengthIsAttribute.LengthIsAttribute(int indexLengthParameter)");
		}
		#endif
		// Forced skipping of method Windows.Foundation.Metadata.LengthIsAttribute.LengthIsAttribute(int)
	}
}
