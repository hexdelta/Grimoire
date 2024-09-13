using Grimoire.Pages;

namespace Grimoire
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for pages that aren't directly accessible through the Flyout menu
            Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
            Routing.RegisterRoute(nameof(ShoppingListPage), typeof(ShoppingListPage));
        }
    }
}
