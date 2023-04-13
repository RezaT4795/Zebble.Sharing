namespace Zebble.Device
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public static partial class Sharing
    {
        class ShareMessage
        {
            public string Title, Text, Url;
            public FileInfo Image;
        }

        public static Task<bool> Share(FileInfo image) => Share(null, image: image);

        public static async Task<bool> Share(string text,
            string title = null,
            string url = null,
            string androidChooserTitle = null,
            FileInfo image = null,
             DeviceSharingOption[] iosExclude = null, OnError errorAction = OnError.Alert)
        {

            var msg = new ShareMessage { Title = title, Text = text, Url = url, Image = image };
            try
            {
                await Thread.UI.Run<Task>(() => DoShare(msg, androidChooserTitle, iosExclude));

                return true;
            }
            catch (Exception ex)
            {
                await errorAction.Apply(ex, "Attempting to share failed: " + ex.Message);
                return false;
            }
        }

        public static async Task<bool> SetClipboard(string text, string androidLabel, OnError errorAction = OnError.Alert)
        {
            try
            {
                await DoSetClipboard(text, androidLabel);
                return true;
            }
            catch (Exception ex)
            {
                await errorAction.Apply(ex, "Attempting to set the clipboard failed: " + ex.Message);
                return false;
            }
        }

        public static async Task<bool> SupportsClipboard(OnError errorAction = OnError.Alert)
        {
            try
            {
                return SupportsClipboard();
            }
            catch (Exception ex)
            {
                await errorAction.Apply(ex, "Unable to share: ");
                return false;
            }
        }
    }
}