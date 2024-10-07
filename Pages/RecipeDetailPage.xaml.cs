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
                if (_recipe.Ingredients.Any(i => i.Name.Equals(newIngredientName, StringComparison.OrdinalIgnoreCase)))
                {
                    DisplayAlert("Error", "This ingredient is already in the list.", "OK");
                    IngredientEntry.Text = string.Empty;
                    return;
                }
                // Create a new Ingredient object and add it to the list
                var newIngredient = new Ingredient { Name = newIngredientName };
                _recipe.Ingredients.Add(newIngredient);

                IngredientEntry.Text = string.Empty; // Clear the input field
            }
        }

        private async void OnSaveRecipeClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateRecipe", _recipe);

            await Navigation.PopAsync();
        }

        private void OnRemoveIngredientClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Ingredient ingredient)
            {
                _recipe.Ingredients.Remove(ingredient);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            // If Recipe was edited, ensure it updates the MainPage collection
            if (BindingContext is Recipe updatedRecipe)
            {
                // Optional: Notify MainPage to refresh the data or manually update the list
                MessagingCenter.Send(this, "UpdateRecipe", updatedRecipe);
            }
        }
    }
}
