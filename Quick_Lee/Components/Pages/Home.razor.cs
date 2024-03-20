using Quick_Lee.Components.Models;

namespace Quick_Lee.Components.Pages
{
    public partial class Home
    {

        readonly List<DicoWords> WordsList = [];

        string WordToAdd = string.Empty;
        string WordDefinition = string.Empty;


        public void AddToList()
        {
            DicoWords wordDicoToAdd = new(this.WordToAdd, this.WordDefinition);

            WordsList.Add(wordDicoToAdd);
        }
 
       
    }
}
