using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Microsoft.Phone.Tasks;

namespace barcodescanner
{
    public class ScannerResult : TaskEventArgs
    {
        public ScannerResult() : base()
        {
        }

        public ScannerResult(TaskResult result) : base(result)
        {
        }

        /// <summary>
        /// Scanned Code
        /// </summary>
        public String ScanCode { get; internal set; }

        /// <summary>
        /// Scanned Code Format
        /// </summary>
        public String ScanFormat { get; internal set; }
    }
}
