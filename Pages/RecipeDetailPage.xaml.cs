using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Grimoire.Models;

namespace Grimoire.Pages
{
    public partial class RecipeDetailPage : ContentPage
    { 

        private Recipe _recipe;

        public RecipeDetailPage(Recipe recipe)
        {
            InitializeComponent();

            // Bind the passed recipe to the page
            _recipe = recipe;
            BindingContext = _recipe;
        }

        private void OnAddIngredientClicked(object sender, EventArgs e)
        {
            string newIngredientName = IngredientEntry.Text;
            if (!string.IsNullOrWhiteSpace(newIngredientName))
            {
                // Create a new Ingredient object and add it to the list
                var newIngredient = new Ingredient { Name = newIngredientName };
                _recipe.Ingredients.Add(newIngredient);

                IngredientEntry.Text = string.Empty; // Clear the input field
            }
        }

        private async void OnSaveRecipeClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page (MainPage)
            await Navigation.PopAsync();
        }

        private void OnRemoveIngredientClicked(object sender, EventArgs e)
        {
            // Ingredient removal logic, will do later
        }
    }
}
