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
                    if (UIApplication.SharedApplication.CanOpenUrl("twitter://".ToNsUrl()))
                    {
                        var twitter = SLComposeViewController.FromService(SLServiceType.Twitter);
                        twitter.SetInitialText(text);
                        UIRuntime.Window.RootViewController.PresentViewController(twitter, true, null);
                    }
                    else
                    {
                        var urlToOpen = $"https://twitter.com/intent/tweet?text={text}".ToNsUrl();
                        UIApplication.SharedApplication.OpenUrl(urlToOpen);
                    }
                });
            }
            public static void TweetPhoto(string text, byte[] photo)
            {
                Thread.UI.Run(() =>
                {
                    if (UIApplication.SharedApplication.CanOpenUrl("twitter://".ToNsUrl()))
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
                    if (UIApplication.SharedApplication.CanOpenUrl("twitter://".ToNsUrl()))
                    {
                        var twitter = SLComposeViewController.FromService(SLServiceType.Twitter);
                        twitter.SetInitialText(text);
                        twitter.AddUrl(url.ToNsUrl());
                        UIRuntime.Window.RootViewController.PresentViewController(twitter, true, null);
                    }
                    else
                    {
                        var urlToOpen = $"https://twitter.com/intent/tweet?text={text}&url={url}".ToNsUrl();
                        UIApplication.SharedApplication.OpenUrl(urlToOpen);
                    }
                });
            }

            public static void Retweet(string tweetId)
            {
                var url = $"https://twitter.com/intent/retweet?tweet_id={tweetId}".ToNsUrl();
                Thread.UI.Run(() => UIApplication.SharedApplication.OpenUrl(url));
            }
        }
    }
}