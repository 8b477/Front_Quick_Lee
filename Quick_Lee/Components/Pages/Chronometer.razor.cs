using Microsoft.AspNetCore.Components;
using Quick_Lee.Components.Models;
using System.Timers;


namespace Quick_Lee.Components.Pages
{
    public partial class Chronometer
    {

        #region VARIABLES
        private readonly System.Timers.Timer SetTimer = new();
        private int TimerElapsed = 10; 

        #endregion


        #region PARAMETERS
        [Parameter]
        public List<DicoWords>? DicoList { get; set; }

        [Parameter]
        public EventCallback<List<DicoWords>> DicoListChanged { get; set; } 

        #endregion


        private async Task NotifyParentOfChange()
        {
            await InvokeAsync(() => DicoListChanged.InvokeAsync(DicoList));
        }


        private async void HandlerChronometer()
        {
            SetVisibilityOnTrue();

            SetTimer.Interval = 1000;
            SetTimer.Elapsed += OnTimeEvent;
            SetTimer.AutoReset = true;
            SetTimer.Enabled = true;

            await NotifyParentOfChange();
        }


        private async void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (this.TimerElapsed > 0)
            {
                this.TimerElapsed -= 1;
                await InvokeAsync(() => StateHasChanged());
            }

            if(this.TimerElapsed == 0)
            {
                SetVisibilityOnFalse();

                await NotifyParentOfChange();
            }
        }


        protected void SetVisibilityOnTrue()
        {
            foreach (var item in DicoList ?? throw new ArgumentNullException(nameof(DicoList)))
            {
                item.IsVisible = true;
            }
        }


        protected void SetVisibilityOnFalse()
        {
            foreach (var item in DicoList ?? throw new ArgumentNullException(nameof(DicoList)))
            {
                item.IsVisible = false;
            }
        }


    }
}
