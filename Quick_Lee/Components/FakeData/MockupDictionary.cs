using Quick_Lee.Components.Models;

namespace Quick_Lee.Components.FakeData
{
    public class MockupDictionary
    {
        public List<DicoWords>? WordsList { get; private set; }

        public MockupDictionary()
        {
            InitializeWordsList();
        }

        private void InitializeWordsList()
        {
            WordsList = new List<DicoWords>
        {
            new DicoWords("Learn","Apprend",true ),
            new DicoWords("New", "Nouveau", true),
            new DicoWords("Baby", "Bébé", true),
            new DicoWords("Therefore", "Par conséquent", true),
            new DicoWords("Learn", "Apprend", true),
            new DicoWords("Though", "Cependant", true),
            new DicoWords("Shift", "Changement", true),
            new DicoWords("Neither", "Ni l'un ni l'autre", true),
            new DicoWords("Whether", "Si", true),
            new DicoWords("Might", "Pourrait", true),
            new DicoWords("Elapsed", "Ecoulée", true),
        };
        }

    }
}
