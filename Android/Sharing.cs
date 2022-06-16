namespace Zebble.Device
{
    using Android.App;
    using Android.Content;
    using AndroidX.Core.Content;
    using Java.IO;
    using Olive;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Context = Android.Content.Context;

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

        static void ShareFileToPackage(string package, string url, string title)
        {
            var shareIntent = new Intent(Intent.ActionSend);
            shareIntent.SetType("image/*");
            shareIntent.PutExtra(Intent.ExtraTitle, title);

            File myFiles = new File(url);
            Android.Net.Uri doneUri = FileProvider.GetUriForFile(UIRuntime.CurrentActivity.ApplicationContext,
                    UIRuntime.CurrentActivity.PackageName + ".fileprovider", myFiles);

            shareIntent.PutExtra(Intent.ExtraStream, doneUri);
            shareIntent.SetPackage(package);
            UIRuntime.CurrentActivity.StartActivity(shareIntent);
        }
    }
}