using Olive;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class LinkedIn
        {
            public static void ShareUrl(string url, string title = "")
            {
                var link = $"https://www.linkedin.com/shareArticle?mini=true&url={url.UrlEncode()}&title=&summary={title.OrEmpty().UrlEncode()}&source=";
                OS.OpenBrowser(link);
            }
        }
    }
}