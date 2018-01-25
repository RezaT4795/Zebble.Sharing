namespace Zebble.Device
{
    using System;
    using System.Threading.Tasks;

    public static partial class Sharing
    {
        class ShareMessage
        {
            public string Title, Text, Url;
        }

        public static async Task<bool> Share(string text, string title = null, string url = null, string androidChooserTitle = null,
             DeviceSharingOption[] iosExclude = null, OnError errorAction = OnError.Alert)
        {
            try
            {
                await Thread.UI.Run<Task>(() => DoShare(new ShareMessage { Title = title, Text = text, Url = url }, androidChooserTitle, iosExclude));

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