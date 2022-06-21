using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UIKit;

namespace Zebble.Device
{
    

    public partial class Sharing
    {
        public partial class Instagram
        {
            public static bool ShareFile(string path, string title)
            {

                return Thread.UI.Run<bool>(() =>
                {
                    string uti = "com.instagram.exclusivegram";
                    var controller = new UIDocumentInteractionController
                    {
                        Url = new NSUrl(path,false),
                        Uti = uti
                    };
                    return controller.PresentOptionsMenu(UIScreen.MainScreen.Bounds, UIApplication.SharedApplication.Delegate.GetWindow(), true);
                });

                
            }
        }
    }
}
