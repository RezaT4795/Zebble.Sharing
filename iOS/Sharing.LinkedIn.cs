using Foundation;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class LinkedIn
        {
            public static void ShareUrl(string url, string title = "")
            {
                var linkedInUrl = $"https://www.linkedin.com/shareArticle?mini=true&url={url}";

                Thread.UI.Run(() =>
                {
                    UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(linkedInUrl));
                });
            }
        }
    }
}