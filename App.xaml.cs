using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Grimoire.Models;

namespace Grimoire
{
    public partial class App : Application
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        public App()
        {
            InitializeComponent();

            // Initialize the Recipes collection
            Recipes = new ObservableCollection<Recipe>();

            // Set the main page to be AppShell or any other starting page
            MainPage = new AppShell();
        }
    }
}
