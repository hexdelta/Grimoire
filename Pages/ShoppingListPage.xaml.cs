using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Grimoire.Models;
using System.Linq;

namespace Grimoire.Pages
{
    [QueryProperty(nameof(SelectedRecipes), "SelectedRecipes")]

    public partial class ShoppingListPage : ContentPage
    {
        private List<Recipe> _selectedRecipes;
        public List<Recipe> SelectedRecipes
        {
            get => _selectedRecipes;
            set
            {
                _selectedRecipes = value;
                OnPropertyChanged();
                CombineIngredients();
            }
        }

        public ObservableCollection<Ingredient> CombinedIngredients { get; set; }

        public ShoppingListPage()
        {
            InitializeComponent();
            CombinedIngredients = new ObservableCollection<Ingredient>();
            BindingContext = this;
        }

        private void CombineIngredients()
        {
            CombinedIngredients.Clear();
            if (SelectedRecipes != null)
            {
                foreach (var recipe in SelectedRecipes)
                {
                    if (recipe.Ingredients != null)
                    {
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            if (!CombinedIngredients.Any(i => i.Name == ingredient.Name))
                            {
                                CombinedIngredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
        }

        private void OnClearListClicked(object sender, EventArgs e)
        {
            CombinedIngredients.Clear();
        }
    }
}
