using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Grimoire.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        private string name;
        private string link;
        private ObservableCollection<Ingredient> ingredients; // Corrected type

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Link
        {
            get => link;
            set
            {
                if (link != value)
                {
                    link = value;
                    OnPropertyChanged(nameof(Link));
                }
            }
        }

        public ObservableCollection<Ingredient> Ingredients // Corrected type
        {
            get => ingredients;
            set
            {
                if (ingredients != value)
                {
                    ingredients = value;
                    OnPropertyChanged(nameof(Ingredients));
                }
            }
        }

        public string Thumbnail { get; set; }
        public bool IsSelected { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new ObservableCollection<Ingredient>(); // Initialize with correct type
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
