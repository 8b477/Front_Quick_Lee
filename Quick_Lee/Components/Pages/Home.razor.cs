using Quick_Lee.Components.Models;

namespace Quick_Lee.Components.Pages
{
    public partial class Home
    {

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


    }
}
