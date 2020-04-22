using Foundation;
using MessageUI;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Sms
        {
            public static void Share(string text)
            {
                if (MFMessageComposeViewController.CanSendText)
                {
                    var messageController = new MFMessageComposeViewController
                    {
                        MessageComposeDelegate = new SmsComposeDelegate(),
                        Body = text
                    };

                    (UIRuntime.NativeRootScreen as UIViewController)?.PresentViewController(messageController, true, null);
                }
            }

            public class SmsComposeDelegate : NSObject, IMFMessageComposeViewControllerDelegate
            {
                public void Finished(MFMessageComposeViewController controller, MessageComposeResult result)
                {
                    (UIRuntime.NativeRootScreen as UIViewController)?.DismissViewController(true, null);
                }
            }
        }
    }
}