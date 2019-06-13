using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Facebook.Share.Model;
using Xamarin.Facebook.Share.Widget;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Facebook
        {
            public static void SharePhotosOnFacebook(IEnumerable<byte[]> photos, string hashtag = null)
            {
                var content = new SharePhotoContent.Builder().Build();
                foreach (var photo in photos)
                {
                    content.Photos.Add(new SharePhoto.Builder().SetBitmap(BitmapFactory.DecodeByteArray(photo, 0, photo.Count())).Build());
                }
                ShareDialog.Show(UIRuntime.CurrentActivity, content);
            }

            public static void SharePhotoOnFacebook(byte[] photo, string hashtag = null)
            {
                SharePhotosOnFacebook(new[] { photo }, hashtag);
            }

            public static void ShareVideoOnFacebook(string videoUrl, byte[] previewImage = null, string hashtag = null)
            {
                var content = new ShareVideoContent.Builder();
                content.SetPreviewPhoto(new SharePhoto.Builder().SetBitmap(BitmapFactory.DecodeByteArray(previewImage, 0, previewImage.Count())).Build());
                content.SetVideo(new ShareVideo.Builder().SetLocalUrl(Android.Net.Uri.Parse(videoUrl)).Build());
                ShareDialog.Show(UIRuntime.CurrentActivity, content.Build());
            }

            public static void ShareLinkOnFacebook(string quote, string url)
            {
                var content = new ShareLinkContent.Builder();
                content.SetContentUrl(Android.Net.Uri.Parse(url));
                content.SetQuote(quote);
                ShareDialog.Show(UIRuntime.CurrentActivity, content.Build());
            }
        }

    }
}