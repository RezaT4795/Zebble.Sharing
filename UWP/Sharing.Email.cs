using Olive;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Email
        {
            public static void Share(string subject, string body)
            {
                OS.OpenBrowser($"mailto:?subject={subject.UrlEncode()}&body={body.UrlEncode()}");
            }
        }
    }
}