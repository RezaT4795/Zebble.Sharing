using System;
using System.Collections.Generic;

using Foundation;
using UIKit;
using Facebook.ShareKit;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Facebook
        {
            public static void SharePhotosOnFacebook(IEnumerable<byte[]> photos, string hashtag = null)
            {
                Thread.UI.Post(() =>
                {
                    var content = new SharePhotoContent();
                    var sharedPhotos = new List<SharePhoto>();
                    foreach (var photo in photos)
                    {
                        sharedPhotos.Add(SharePhoto.From(UIImage.LoadFromData(NSData.FromArray(photo)), true));
                    }
                    content.Photos = sharedPhotos.ToArray();
                    if (!string.IsNullOrEmpty(hashtag))
                        content.Hashtag = new Hashtag() { StringRepresentation = hashtag };
                    
                    new ShareDialog((UIViewController)UIRuntime.NativeRootScreen, content, @delegate: null)
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    }.Show();
                });
            }
            public static void SharePhotoOnFacebook(byte[] photo, string hashtag = null)
            {
                SharePhotosOnFacebook(new[] { photo }, hashtag);
            }

            public static void ShareVideoOnFacebook(string videoUrl, byte[] previewImage = null, string hashtag = null)
            {
                Thread.UI.Post(() =>
                {
                    var video = new ShareVideo(new NSCoder())
                    {
                        PreviewPhoto = SharePhoto.From(UIImage.LoadFromData(NSData.FromArray(previewImage)), true),
                        VideoUrl = videoUrl.ToNsUrl()
                    };
                    var content = new ShareVideoContent { Video = video };
                    if (string.IsNullOrEmpty(hashtag)) content.Hashtag = new Hashtag() { StringRepresentation = hashtag };
                    
                    new ShareDialog((UIViewController)UIRuntime.NativeRootScreen, content, @delegate: null)
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    }.Show();
                });
            }

            public static void ShareLinkOnFacebook(string quote, string url)
            {
                Thread.UI.Post(() =>
                {
                    var content = new ShareLinkContent();
                    content.SetContentUrl(url.ToNsUrl());
                    content.Quote = quote;
                    
                    new ShareDialog((UIViewController)UIRuntime.NativeRootScreen, content, @delegate: null)
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    }.Show();
                });
            }
        }
    }
}