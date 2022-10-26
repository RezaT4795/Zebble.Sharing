using Foundation;
using System;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Whatsapp
        {
            public static void Share(string text)
            {
                var whatsappUrl = $"whatsapp://send?text={text}".ToNsUrl();
                Thread.UI.Run(() => UIApplication.SharedApplication.OpenUrl(whatsappUrl));
            }
        }
    }
}