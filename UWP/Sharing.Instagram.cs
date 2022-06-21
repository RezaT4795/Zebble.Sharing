using System;

namespace Zebble.Device
{
    using Olive;
    using System.Collections.Generic;
    using Windows.ApplicationModel.DataTransfer;
    using Windows.Foundation;
    using Windows.Storage;
    using Windows.Storage.Streams;

    public partial class Sharing
    {
        public partial class Instagram
        {
            public static void ShareFile(string url, string title)
            { 
                Thread.UI.Run(() =>
                {
                    var manager = DataTransferManager.GetForCurrentView();
                    manager.DataRequested +=
                        new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>((s, e) => ShareImage(s, e, url, title));
                    DataTransferManager.ShowShareUI();
                });
                
            }

            private static async void ShareImage(DataTransferManager sender, DataRequestedEventArgs eventArgs, string url, string title)
            {
                var tempExportFile = await StorageFile.GetFileFromPathAsync(url);
                var imageItems = new List<IStorageItem> { tempExportFile };

                var imageReference = RandomAccessStreamReference.CreateFromFile(tempExportFile);
                eventArgs.Request.Data.SetStorageItems(imageItems);
                eventArgs.Request.Data.SetBitmap(imageReference);
                eventArgs.Request.Data.Properties.Thumbnail = imageReference;
                eventArgs.Request.Data.Properties.Title = title;

            }
        }
    }
}
