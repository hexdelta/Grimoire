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

            MessagingCenter.Subscribe<RecipeDetailPage, Recipe>(this, "UpdateRecipe", (sender, updatedRecipe) =>
            {
                // Find the existing recipe and update it
                var existingRecipe = Recipes.FirstOrDefault(r => r == updatedRecipe);
                if (existingRecipe != null)
                {
                    // Update properties (like name) if necessary
                    existingRecipe.Name = updatedRecipe.Name;
                    // Trigger collection change notification if needed
                }
            });
        }

        private async void OnAddRecipeClicked(object sender, EventArgs e)
        {
            var newRecipe = new Recipe("New Recipe")
            {
                Thumbnail = "default_thumbnail.png",
                IsSelected = false
            };
            Recipes.Add(newRecipe);

            await Navigation.PushAsync(new RecipeDetailPage(newRecipe));
        }


        private async void OnRecipeSelected(object sender, SelectionChangedEventArgs e)
        {
            RecipeCollection.SelectedItem = null;

            if (e.CurrentSelection.FirstOrDefault() is Recipe selectedRecipe)
            {
                await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            }
        }


        private void OnRecipeSelectionChanged(object sender, CheckedChangedEventArgs e)
        {
            var isAnySelected = Recipes.Any(r => r.IsSelected);
            GenerateShoppingListButton.IsEnabled = isAnySelected;
        }

        private async void OnGenerateShoppingListClicked(object sender, EventArgs e)
        {
            var selectedRecipes = Recipes.Where(r => r.IsSelected).ToList();
            if (selectedRecipes.Any())
            {
                await Shell.Current.GoToAsync($"{nameof(ShoppingListPage)}", true,
                    new Dictionary<string, object>
                    {
                { "SelectedRecipes", selectedRecipes }
                    });
            }
        }

    }
}
