using Foundation;
using MessageUI;
using UIKit;
using Olive;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Email
        {
            public static void Share(string subject, string body)
            {
                Thread.UI.Run(async () =>
                {
                    if (MFMailComposeViewController.CanSendMail)
                    {
                        var controller = new MFMailComposeViewController
                        {
                            Delegate = new MailControllerDelegate()
                        };

                        controller.SetSubject(subject);
                        controller.SetMessageBody(body, false);

                        (UIRuntime.NativeRootScreen as UIViewController)?.PresentViewController(controller, true, null);
                    }
                    else
                    {
                        await Alert.Show("Your device does not support sending email message!");
                    }
                });
            }

            public class MailControllerDelegate : MFMailComposeViewControllerDelegate
            {
                public override void Finished(MFMailComposeViewController controller, MFMailComposeResult result, NSError error)
                {
                    base.Finished(controller, result, error);

                    switch (result)
                    {
                        case MFMailComposeResult.Cancelled:
                            Alert.Toast("Email cancelled");
                            break;
                        case MFMailComposeResult.Saved:
                            Alert.Toast("Email saved");
                            break;
                        case MFMailComposeResult.Sent:
                            Alert.Toast("Email sent");
                            break;
                        case MFMailComposeResult.Failed:
                            Log.For(this).Error(null, "A failure occurred while completing the email");
                            break;
                        default:
                            break;
                    }

                    (UIRuntime.NativeRootScreen as UIViewController)?.DismissViewController(true, null);
                }
            }
        }
    }
}