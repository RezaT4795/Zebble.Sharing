namespace Zebble.Device
{
    using Foundation;
    using UIKit;

    class ShareItemSource : UIActivityItemSource
    {
        NSObject Item;
        string Subject;

        public ShareItemSource(NSObject item, string subject)
        {
            Item = item;
            Subject = subject;
        }

        public override NSObject GetItemForActivity(UIActivityViewController _, NSString __) => Item;

        public override NSObject GetPlaceholderData(UIActivityViewController _) => Item;

        public override string GetSubjectForActivity(UIActivityViewController _, NSString __) => Subject;
    }
}