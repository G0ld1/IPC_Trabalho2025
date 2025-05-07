using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace A_Mapping2.Views
{
    /// <summary>
    /// Interaction logic for ProcessingWindow.xaml
    /// </summary>
    public partial class ProcessingWindow : Window
    {

        private DispatcherTimer _timer;
        private int _progressValue;

        public event EventHandler ProcessingCompleted;

        public ProcessingWindow()
        {
            InitializeComponent();
            StartProgress();
        }

        private void StartProgress()
        {
            _progressValue = 0;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(30) // ~3s no total
            };
            _timer.Tick += (s, e) =>
            {
                _progressValue++;
                ProgressBar.Value = _progressValue;

                if (_progressValue >= 100)
                {
                    _timer.Stop();
                    ProcessingCompleted?.Invoke(this, EventArgs.Empty);
                }
            };
            _timer.Start();
        }
    }
}
