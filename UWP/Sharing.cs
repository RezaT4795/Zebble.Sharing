namespace Zebble.Device
{
    using System;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.DataTransfer;
    using Windows.Foundation;
    using Olive;
    using Windows.Storage.Streams;

    public partial class Sharing
    {
        static DataTransferManager DataTransferManager;
        static ShareMessage Message;

        public static bool SupportsClipboard() => true;

        static Task DoShare(ShareMessage message, string _, DeviceSharingOption[] __)
        {
            Message = message;
            if (DataTransferManager == null)
            {
                DataTransferManager = DataTransferManager.GetForCurrentView();
                DataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>((sender, eventArgse) => ShareTextHandler(sender, eventArgse));
            }

            DataTransferManager.ShowShareUI();
            return Task.CompletedTask;
        }

        static async void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs eventArgse)
        {
            var request = eventArgse.Request;

            request.Data.Properties.Title = Message.Title ?? Windows.ApplicationModel.Package.Current.DisplayName;

            if (Message.Text.HasValue()) request.Data.SetText(Message.Text);

            if (Message.Url.HasValue()) request.Data.SetWebLink(new Uri(Message.Url));

            if (Message.Image != null)
            {
                var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(Message.Image.FullName);
                request.Data.SetBitmap(RandomAccessStreamReference.CreateFromFile(file));
            }                 
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
