#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Email.DataProvider
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial class EmailMailboxGetAutoReplySettingsRequestEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		[global::Uno.NotImplemented]
		public  global::Windows.ApplicationModel.Email.DataProvider.EmailMailboxGetAutoReplySettingsRequest Request
		{
			get
			{
				throw new global::System.NotImplementedException("The member EmailMailboxGetAutoReplySettingsRequest EmailMailboxGetAutoReplySettingsRequestEventArgs.Request is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Email.DataProvider.EmailMailboxGetAutoReplySettingsRequestEventArgs.Request.get
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		[global::Uno.NotImplemented]
		public  global::Windows.Foundation.Deferral GetDeferral()
		{
			throw new global::System.NotImplementedException("The member Deferral EmailMailboxGetAutoReplySettingsRequestEventArgs.GetDeferral() is not implemented in Uno.");
		}
		#endif
	}
}