using Microsoft.Maui.Controls;
using Grimoire.Models;

namespace Grimoire.Pages
{
    [QueryProperty(nameof(Recipe), "Recipe")]
    public partial class RecipeDetailPage : ContentPage
    {
        private Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged(); // Notify that the property has changed for data binding
            }
        }

        public RecipeDetailPage()
        {
            InitializeComponent();
        }

        private void OnAddIngredientClicked(object sender, EventArgs e)
        {
            var newIngredient = new Ingredient();
            Recipe.Ingredients.Add(newIngredient);
        }

        private void OnRemoveIngredientClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var ingredient = button.BindingContext as Ingredient;
            if (ingredient != null && Recipe.Ingredients.Contains(ingredient))
            {
                Recipe.Ingredients.Remove(ingredient);
            }
        }

        private async void OnSaveRecipeClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Recipe saved!", "OK");
            await Shell.Current.GoToAsync(".."); // Navigate back to the previous page
        }
    }
}
