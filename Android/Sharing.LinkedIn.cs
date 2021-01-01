using Android.Content;
using Olive;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class LinkedIn
        {
            public static void ShareUrl(string url, string title = "")
            {
                string linkedInUrl;
                if (!title.HasValue())
                    linkedInUrl = $"https://www.linkedin.com/shareArticle?mini=true&url={url}";
                else
                    linkedInUrl = $"https://www.linkedin.com/shareArticle?mini=true&url={url}&title={title}";

                var intent = new Intent(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse(linkedInUrl));
                UIRuntime.CurrentActivity.StartActivity(intent);
            }
        }
    }
}