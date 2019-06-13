using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Social;
using System.Threading.Tasks;
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
                    var dialog = new ShareDialog
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    };
                    dialog.SetShareContent(content);
                    dialog.Show();
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
                    var content = new ShareVideoContent();
                    content.PreviewPhoto = SharePhoto.From(UIImage.LoadFromData(NSData.FromArray(previewImage)), true);
                    content.SetContentUrl(NSUrl.FromString(videoUrl));
                    if (string.IsNullOrEmpty(hashtag))
                        content.Hashtag = new Hashtag() { StringRepresentation = hashtag };
                    var dialog = new ShareDialog
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    };
                    dialog.SetShareContent(content);
                    dialog.Show();
                });
            }

            public static void ShareLinkOnFacebook(string quote, string url)
            {
                Thread.UI.Post(() =>
                {
                    var content = new ShareLinkContent();
                    content.SetContentUrl(NSUrl.FromString(url));
                    content.Quote = quote;
                    var dialog = new ShareDialog
                    {
                        Mode = ShareDialogMode.ShareSheet,
                        FromViewController = (UIViewController)UIRuntime.NativeRootScreen
                    };
                    dialog.SetShareContent(content);
                    dialog.Show();
                });
            }
        }
    }
}