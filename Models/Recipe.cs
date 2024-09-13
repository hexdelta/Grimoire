using System.Collections.ObjectModel;

namespace Grimoire.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Link { get; set; }  // Recipe source link, can be blank
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public string Thumbnail { get; set; } // Path to the thumbnail image
        public bool IsSelected { get; set; }  // For selection in the UI

        public Recipe(string name)
        {
            Name = name;
        }

        public Recipe() : this("Unnamed Recipe")
        {
        }
    }
}
