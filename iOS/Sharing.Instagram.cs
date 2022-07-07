using Foundation;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Instagram
        {
            public static bool ShareFile(string path, string title)
                => Thread.UI.Run<bool>(() =>
                {
                    var url = NSUrl.FromString("instagram-stories://share");

                    if (!UIApplication.SharedApplication.CanOpenUrl(url)) return false;

                    var items = new[] { new NSDictionary<NSString, NSObject>(
                        new NSString("com.instagram.sharedSticker.backgroundImage"),
                        NSData.FromFile(path)
                    ) };
                    var options = new UIPasteboardOptions
                    {
                        ExpirationDate = new NSDate().AddSeconds(60)
                    };

                    UIPasteboard.General.SetItems(items, options);

                    return UIApplication.SharedApplication.OpenUrl(url);
                });
        }
    }
}
