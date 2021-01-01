using System;
using System.Collections.Generic;
using Olive;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Facebook
        {
            public static void SharePhotosOnFacebook(IEnumerable<byte[]> photos, string hashtag = null)
            {
                throw new NotImplementedException();
            }

            public static void SharePhotoOnFacebook(byte[] photo, string hashtag = null)
            {
                throw new NotImplementedException();
            }

            public static void ShareVideoOnFacebook(string videoUrl, byte[] previewImage = null, string hashtag = null)
            {
                throw new NotImplementedException();
            }

            public static void ShareLinkOnFacebook(string quote, string url)
            {
                OS.OpenBrowser("https://www.facebook.com/sharer/sharer.php?u=" + url.UrlEncode());
            }
        }
    }
}
