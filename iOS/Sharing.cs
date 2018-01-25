namespace Zebble.Device
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Foundation;
    using UIKit;

    public partial class Sharing
    {
        public static bool SupportsClipboard() => true;

        public static List<NSString> ExcludedUIActivityTypes { get; set; } = new List<NSString> { UIActivityType.PostToFacebook };

        static async Task DoShare(ShareMessage message, string _, DeviceSharingOption[] excludedTypes)
        {
            var items = new List<NSObject>();
            if (message.Text.HasValue()) items.Add(new ShareItemSource(message.Text.ToNs(), message.Title));
            if (message.Url.HasValue()) items.Add(new ShareItemSource(NSUrl.FromString(message.Url), message.Title));

            var controller = new UIActivityViewController(items.ToArray(), null);

            if (excludedTypes != null)
                controller.ExcludedActivityTypes = excludedTypes.Select(GetUIActivityType).Trim()
                    .Select(x => x.ToNs()).ToArray();

            var vc = GetVisibleViewController();

            if (Device.OS.IsAtLeastiOS(8))
            {
                if (controller.PopoverPresentationController != null)
                    controller.PopoverPresentationController.SourceView = vc.View;
            }

            await vc.PresentViewControllerAsync(controller, animated: true);
        }

        static UIViewController GetVisibleViewController(UIViewController controller = null)
        {
            controller = controller ?? UIRuntime.Window.RootViewController;

            if (controller.PresentedViewController == null)
                return controller;

            if (controller.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)controller.PresentedViewController).VisibleViewController;
            }

            if (controller.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)controller.PresentedViewController).SelectedViewController;
            }

            return GetVisibleViewController(controller.PresentedViewController);
        }

        static string GetUIActivityType(DeviceSharingOption type)
        {
            if (Device.OS.IsBeforeiOS(7))
            {
                switch (type)
                {
                    case DeviceSharingOption.AddToReadingList:
                    case DeviceSharingOption.AirDrop:
                    case DeviceSharingOption.PostToFlickr:
                    case DeviceSharingOption.PostToTencentWeibo:
                    case DeviceSharingOption.PostToVimeo:
                    case DeviceSharingOption.OpenInIBooks:
                        return null;
                    default: break;
                }
            }

            return type.ToString();
        }

        static Task DoSetClipboard(string text, string _)
        {
            UIPasteboard.General.String = text;
            return Task.CompletedTask;
        }
    }
}
