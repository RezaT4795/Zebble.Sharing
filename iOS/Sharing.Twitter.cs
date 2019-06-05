using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Social;
using UIKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Twitter
        {
            public static void Tweet(string text)
            {

                Thread.UI.Run(() =>
                {
                    if (SLComposeViewController.IsAvailable(SLServiceType.Twitter))
                    {
                        var twitter = SLComposeViewController.FromService(SLServiceType.Twitter);
                        twitter.SetInitialText(text);
                        UIRuntime.Window.RootViewController.PresentViewController(twitter, true, null);
                    }
                    else
                    {
                        OS.OpenBrowser($"https://twitter.com/intent/tweet?text={text}");
                    }
                });
            }
            public static void TweetPhoto(string text, byte[] photo)
            {
                Thread.UI.Run(() =>
                {
                    if (SLComposeViewController.IsAvailable(SLServiceType.Twitter))
                    {
                        var twitter = SLComposeViewController.FromService(SLServiceType.Twitter);
                        twitter.SetInitialText(text);
                        twitter.AddImage(UIImage.LoadFromData(NSData.FromArray(photo)));
                        UIRuntime.Window.RootViewController.PresentViewController(twitter, true, null);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("For posting photos you need to install Twitter on your device");
                    }
                });

            }
            public static void TweetLink(string text, string url)
            {
                Thread.UI.Run(() =>
                {
                    if (SLComposeViewController.IsAvailable(SLServiceType.Twitter))
                    {
                        var twitter = SLComposeViewController.FromService(SLServiceType.Twitter);
                        twitter.SetInitialText(text);
                        twitter.AddUrl(NSUrl.FromString(url));
                        UIRuntime.Window.RootViewController.PresentViewController(twitter, true, null);
                    }
                    else
                    {
                        OS.OpenBrowser($"https://twitter.com/intent/tweet?text={text}&url={url}");
                    }
                });
            }
        }
    }
}