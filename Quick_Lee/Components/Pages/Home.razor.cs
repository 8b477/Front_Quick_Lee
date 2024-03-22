using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using Quick_Lee.Components.Models;

namespace Quick_Lee.Components.Pages
{
    public partial class Home
    {
        #region INJECTION

        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        #endregion



        #region Variables
        private string WordToAdd      = string.Empty;
        private string WordDefinition = string.Empty;
        private bool   IsVisible      = false;

        private readonly List<DicoWords> WordsList = [];
        #endregion



        #region Public Methods

        /// <summary>
        /// Add a Object of type DicoWord into the Collection called WordList.
        /// </summary>
        private void AddToList()
        {
            DicoWords wordDicoToAdd = new(this.WordToAdd, this.WordDefinition, false);

            WordsList.Add(wordDicoToAdd);
        }


        /// <summary>
        /// Invert the Boolean value of "IsVisible" to switch from "hide" to "show" or vice versa.
        /// </summary>
        private void ToggleVisibility(int index)
        {
            this.WordsList[index].IsVisible = !this.WordsList[index].IsVisible;
        }

        #endregion


        #region DEBG TOOLS
        private async Task Debugger(string valueToCheck)
        {
            if(JSRuntime is not null)
            {
                if(string.IsNullOrEmpty(WordToAdd))
                    await JSRuntime.InvokeVoidAsync("console.log", $"The value of parameter : \'{nameof(valueToCheck)}\' is null or empty");

                await JSRuntime.InvokeVoidAsync("console.log", valueToCheck);
            }
            await Console.Out.WriteLineAsync("IJRuntime is not available");
        }

        #endregion

    }
}
