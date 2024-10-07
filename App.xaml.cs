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
            Recipes = new ObservableCollection<Recipe>();

            MainPage = new AppShell();
        }
    }
}
