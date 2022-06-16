
using Android.Content;
using Android.Net;
using AndroidX.Core.Content;
using Java.IO;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Instagram
        {
            public static void ShareFile(string url, string title)
            {
                ShareFileToPackage("com.instagram.android", url, title);
            }
        }
    }
}
