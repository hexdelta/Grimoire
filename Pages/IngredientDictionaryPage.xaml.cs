using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Grimoire.Models;

namespace Grimoire.Pages
{
    public partial class IngredientDictionaryPage : ContentPage
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public IngredientDictionaryPage()
        {
            InitializeComponent();
            Ingredients = new ObservableCollection<Ingredient>(); // Initialize with an empty list
            BindingContext = this; // Bind the page context to this instance for data binding
        }

        // Event handler for adding a new ingredient
        private void OnAddIngredientClicked(object sender, EventArgs e)
        {
            var newIngredient = new Ingredient();
            Ingredients.Add(newIngredient);
        }

        // Event handler for deleting an ingredient'''''
        private void OnDeleteIngredientClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var ingredient = button.BindingContext as Ingredient;
            if (ingredient != null && Ingredients.Contains(ingredient))
            {
                Ingredients.Remove(ingredient);
            }
        }
    }
}
