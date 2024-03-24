﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Quick_Lee.Components.FakeData;
using Quick_Lee.Components.Models;


namespace Quick_Lee.Components.Pages
{
    public partial class Home
    {

        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        [Inject]
        public MockupDictionary? MockupDictionary { get; set; }


        private string WordToAdd = string.Empty;
        private string WordDefinition = string.Empty;
        private bool IsVisible = true;


        /// <summary>
        /// Add a Object of type DicoWord into the Collection called WordList.
        /// </summary>
        private void AddToList()
        {
            DicoWords wordDicoToAdd = new(this.WordToAdd, this.WordDefinition, IsVisible);

            MockupDictionary?.WordsList.Add(wordDicoToAdd);
        }

        /// <summary>
        /// Remove item of type DicoWord from the Collection called WordList.
        /// </summary>
        /// <param name="index">identificatory item to remove</param>
        private void DeleteItemFromDicoList(int index)
        {
            MockupDictionary?.WordsList.Remove(MockupDictionary.WordsList[index]);
        }


        /// <summary>
        /// Invert the Boolean value of "IsVisible" to switch from "hide" to "show" or vice versa.
        /// </summary>
        private void ToggleVisibility(int index)
        {
            if (MockupDictionary is null) 
                throw new ArgumentNullException(nameof(MockupDictionary));

            MockupDictionary.WordsList[index].IsVisible = !MockupDictionary.WordsList[index].IsVisible;
        }



        public void HandleDataUpdated()
        {
            StateHasChanged();
        }

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
