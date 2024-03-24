using Microsoft.AspNetCore.Components;
using Quick_Lee.Components.FakeData;
using System.Timers;

namespace Quick_Lee.Components.Pages
{
    public partial class Chronometer
    {

        [Inject]
        public MockupDictionary MockupDictionary { get; set; }


        private readonly System.Timers.Timer SetTimer = new();
        private int TimerElapsed = 10;

        private void HandlerChronometer()
        {
            foreach(var item in MockupDictionary.WordsList ?? throw new ArgumentNullException(nameof(MockupDictionary)))
            {
                item.IsVisible = true;
            }

            SetTimer.Interval = 1000;
            SetTimer.Elapsed += OnTimeEvent;
            SetTimer.AutoReset = true;
            SetTimer.Enabled = true;

        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (this.TimerElapsed > 0)
            {
                this.TimerElapsed -= 1;
                InvokeAsync(() => StateHasChanged());
            }

            if(this.TimerElapsed == 0)
            {
                foreach (var item in MockupDictionary.WordsList ?? throw new ArgumentNullException(nameof(MockupDictionary)))
                {
                    item.IsVisible = false;
                }
            }
        }
    }
}
