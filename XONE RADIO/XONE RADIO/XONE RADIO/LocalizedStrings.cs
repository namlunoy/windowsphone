using XONE_RADIO.Resources;

namespace XONE_RADIO
{
	/// <summary>
	/// Provides access to string resources.
	/// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}