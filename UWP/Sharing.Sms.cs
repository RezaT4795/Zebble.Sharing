using Windows.ApplicationModel.Chat;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Sms
        {
            public static void Share(string text)
            {
                var chat = new ChatMessage { Body = text };
                ChatMessageManager.ShowComposeSmsMessageAsync(chat);
            }
        }
    }
}