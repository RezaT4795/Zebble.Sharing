using Android.Content;
using Android.Net;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Sms
        {
            public static void Share(string text)
            {
                var messageIntent = new Intent(Intent.ActionView, Uri.Parse("sms:" + ""));
                messageIntent.PutExtra("sms_body", text);
                UIRuntime.CurrentActivity.StartActivity(messageIntent);
            }
        }
    }
}