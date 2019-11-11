using Android.Content;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Email
        {
            public static void Share(string subject, string body)
            {
                var emailUrl = $"mailto:?subject={subject}&body={body}";

                var intent = new Intent(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse(emailUrl));
                UIRuntime.CurrentActivity.StartActivity(intent);
            }
        }
    }
}