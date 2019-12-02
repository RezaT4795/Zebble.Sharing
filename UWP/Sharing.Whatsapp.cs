namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Whatsapp
        {
            public static void Share(string text)
            {
                OS.OpenBrowser("https://web.whatsapp.com/");
            }
        }
    }
}