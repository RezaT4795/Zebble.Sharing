namespace Zebble.Device
{
    using Android.App;
    using Android.Content;
    using Context = Android.Content.Context;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Olive;

    public partial class Sharing
    {
        public static bool SupportsClipboard() => true;

        static Task DoShare(ShareMessage message, string androidChooserTitle, DeviceSharingOption[] _)
        {
            var items = new List<string>();

            if (message.Text.HasValue()) items.Add(message.Text);

            if (message.Url.HasValue()) items.Add(message.Url);

            var intent = new Intent(Intent.ActionSend).SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, string.Join(Environment.NewLine, items));
            if (message.Title.HasValue()) intent.PutExtra(Intent.ExtraSubject, message.Title);

            var chooserIntent = Intent.CreateChooser(intent, androidChooserTitle);
            chooserIntent.SetFlags(ActivityFlags.ClearTop).SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(chooserIntent);

            return Task.CompletedTask;
        }

        static Task DoSetClipboard(string text, string label)
        {
            var clipboard = UIRuntime.GetService<ClipboardManager>(Context.ClipboardService);
            clipboard.PrimaryClip = ClipData.NewPlainText(label ?? string.Empty, text);

            return Task.CompletedTask;
        }
    }
}