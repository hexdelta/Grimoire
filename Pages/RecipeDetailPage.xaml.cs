using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Grimoire.Models;

namespace Grimoire.Pages
{
    public partial class RecipeDetailPage : ContentPage
    {
        private Recipe _recipe;

        // Parameterless constructor for XAML instantiation
        public RecipeDetailPage()
        {
            InitializeComponent();
            _recipe = new Recipe(); // Initialize with a default Recipe
            BindingContext = _recipe;
        }

        // Constructor with parameter for programmatic instantiation
        public RecipeDetailPage(Recipe recipe) : this() // Calls the parameterless constructor
        {
            _recipe = recipe ?? new Recipe(); // Use provided recipe or create a new one
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
            if (Application.Current is App app)
            {
                if (!app.Recipes.Contains(_recipe))
                {
                    app.Recipes.Add(_recipe);
                }
            }

            await Navigation.PopAsync();
        }

        private void OnRemoveIngredientClicked(object sender, EventArgs e)
        {
            // Ingredient removal logic, will do later
        }
    }
}
