using Foundation;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Email
        {
            public static void Share(string subject, string body)
            {
                var emailUrl = $"mailto:?subject={subject}&body={body}";

                Thread.UI.Run(() =>
                {
                    UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(emailUrl));
                });
            }
        }
    }
}