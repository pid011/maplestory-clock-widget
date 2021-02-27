using MaplestoryClockWidget.Helpers;

using System;
using System.Windows.Threading;

namespace MaplestoryClockWidget.ViewModels
{
    public class MainWindowViewModel : Observable
    {
        private string _time;
        private bool _flagTimeVisible;

        public string Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        public bool FlagTimeVisible
        {
            get => _flagTimeVisible;
            set => Set(ref _flagTimeVisible, value);
        }

        public MainWindowViewModel()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToString("tt hh시 mm분 ss초");
        }
    }
}
