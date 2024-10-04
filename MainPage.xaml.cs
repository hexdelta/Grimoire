using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Grimoire.Models;
using Grimoire.Pages;

namespace Grimoire
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Recipe>();
            RecipeCollection.ItemsSource = Recipes;
        }

        private async void OnAddRecipeClicked(object sender, EventArgs e)
        {
            var newRecipe = new Recipe("New Recipe");
            Recipes.Add(newRecipe);

            // Navigate to the RecipeDetailPage to edit the new recipe
            await Navigation.PushAsync(new RecipeDetailPage(newRecipe));
        }

        private async void OnRecipeTapped(object sender, SelectionChangedEventArgs e)
        {
            // When a recipe is tapped, navigate to the detail page
            if (e.CurrentSelection.FirstOrDefault() is Recipe selectedRecipe)
            {
                await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));

                // Reset the selection to avoid confusion
                RecipeCollection.SelectedItem = null;
            }
        }

        private void OnRecipeSelectionChanged(object sender, CheckedChangedEventArgs e)
        {
            // Check if any recipes are selected and enable the shopping list button
            var isAnySelected = Recipes.Any(r => r.IsSelected);
            GenerateShoppingListButton.IsEnabled = isAnySelected;
        }

        private async void OnGenerateShoppingListClicked(object sender, EventArgs e)
        {
            var selectedRecipes = Recipes.Where(r => r.IsSelected).ToList();
            if (selectedRecipes.Any())
            {
                // Navigate to ShoppingListPage
                await Shell.Current.GoToAsync($"{nameof(ShoppingListPage)}", true,
                    new Dictionary<string, object>
                    {
                        { "SelectedRecipes", selectedRecipes }
                    });
            }
        }
    }
}
