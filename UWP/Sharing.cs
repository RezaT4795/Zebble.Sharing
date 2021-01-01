namespace Zebble.Device
{
    using System;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.DataTransfer;
    using Windows.Foundation;
    using Olive;

    public partial class Sharing
    {
        static DataTransferManager DataTransferManager;

        public static bool SupportsClipboard() => true;

        static Task DoShare(ShareMessage message, string _, DeviceSharingOption[] __)
        {
            if (DataTransferManager == null)
            {
                DataTransferManager = DataTransferManager.GetForCurrentView();
                DataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>((sender, eventArgse) => ShareTextHandler(sender, eventArgse, message));
            }

            DataTransferManager.ShowShareUI();
            return Task.CompletedTask;
        }

        static void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs eventArgse, ShareMessage message)
        {
            var request = eventArgse.Request;

            request.Data.Properties.Title = message.Title ?? Windows.ApplicationModel.Package.Current.DisplayName;

            if (message.Text.HasValue()) request.Data.SetText(message.Text);

            if (message.Url.HasValue()) request.Data.SetWebLink(new Uri(message.Url));
        }

        static Task DoSetClipboard(string text, string _)
        {
            var package = new DataPackage();
            package.SetData("DataPackageOperation", DataPackageOperation.Copy);
            package.SetText(text);

            Clipboard.SetContent(package);
            return Task.CompletedTask;
        }
    }
}
