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

            // Use Shell navigation to open the RecipeDetailPage
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}", true,
                new Dictionary<string, object>
                {
                    { "Recipe", newRecipe }
                });
        }

        private async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Recipe selectedRecipe)
            {
                await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            }
        }



        private void OnRecipeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isAnySelected = Recipes.Any(r => r.IsSelected);
            ((Button)FindByName("GenerateShoppingListButton")).IsEnabled = isAnySelected;
        }

        private async void OnGenerateShoppingListClicked(object sender, EventArgs e)
        {
            var selectedRecipes = Recipes.Where(r => r.IsSelected).ToList();
            if (selectedRecipes.Any())
            {
                // Use Shell navigation to open the ShoppingListPage
                await Shell.Current.GoToAsync($"{nameof(ShoppingListPage)}", true,
                    new Dictionary<string, object>
                    {
                        { "SelectedRecipes", selectedRecipes }
                    });
            }
        }
    }
}
