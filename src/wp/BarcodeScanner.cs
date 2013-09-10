using System.Runtime.Serialization;
using WPCordovaClassLib;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Windows;
using System.Diagnostics;


namespace Cordova.Extension.Commands
{
    public class BarcodeScanner : WPCordovaClassLib.Cordova.Commands.BaseCommand
    {
        public void scan(string options) 
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                var root = Application.Current.RootVisual as PhoneApplicationFrame;

                root.Navigated += new System.Windows.Navigation.NavigatedEventHandler(root_Navigated);

                root.Navigate(new System.Uri("/Plugins/com.phonegap.plugins.barcodescanner/Scanner.xaml?dummy=" + Guid.NewGuid().ToString(), UriKind.Relative));
            });
        }

        void root_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!(e.Content is barcodescanner.Scanner)) return;

            (Application.Current.RootVisual as PhoneApplicationFrame).Navigated -= root_Navigated;

            barcodescanner.Scanner scanner = (barcodescanner.Scanner)e.Content;

            if (scanner != null)
            {
                scanner.Completed += new EventHandler<barcodescanner.ScannerResult>(scanner_Completed);
            }
        }

        void scanner_Completed(object sender, barcodescanner.ScannerResult e)
        {
            string result;

            if (e.TaskResult == TaskResult.OK)
            {
                result = String.Format("\"cancelled\":{0}, \"text\":\"{1}\", \"format\":\"{2}\"", false.ToString().ToLower(), e.ScanCode, e.ScanFormat);
            }
            else
            {
                result = String.Format("\"cancelled\":{0}, \"text\":\"\", \"format\":\"\"", true.ToString().ToLower());
            }

            DispatchCommandResult(new WPCordovaClassLib.Cordova.PluginResult(WPCordovaClassLib.Cordova.PluginResult.Status.OK, "{" + result + "}"));
        }

        public void encode(string options)
        {
            DispatchCommandResult(new WPCordovaClassLib.Cordova.PluginResult(WPCordovaClassLib.Cordova.PluginResult.Status.ERROR, "Not implemented"));
        }
    }
}
