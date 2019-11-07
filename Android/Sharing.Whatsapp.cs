using Android.Content;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Whatsapp
        {
            public static void Share(string text)
            {
                var whatsappUrl = $"whatsapp://send?text={text}";

                var intent = new Intent(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse(whatsappUrl));
                UIRuntime.CurrentActivity.StartActivity(intent);
            }
        }
    }
}