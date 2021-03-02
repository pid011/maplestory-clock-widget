using MaplestoryClockWidget.Helpers;

using System;
using System.Windows.Media;
using System.Windows.Threading;

namespace MaplestoryClockWidget.ViewModels
{
    public class MainWindowViewModel : Observable
    {
        private string _time;
        private Brush _timeColor;
        private string _date;

        public string Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        public Brush TimeColor
        {
            get => _timeColor;
            set => Set(ref _timeColor, value);
        }

        public string Date
        {
            get => _date;
            set => Set(ref _date, value);
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
            var now = DateTime.Now;

            Time = now.ToString("tt hh시 mm분 ss초");

            TimeColor = MinCheck30(now.Minute, now.Second) || MinCheck60(now.Minute, now.Second)
                ? Brushes.Red : Brushes.White;

            Date = now.ToString("yyyy년 MM월 dd일 dddd");

            static bool MinCheck30(int min, int sec) => min == 29 && sec >= 50;
            static bool MinCheck60(int min, int sec) => min == 59 && sec >= 50;
        }
    }
}
