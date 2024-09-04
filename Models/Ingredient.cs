namespace Grimoire.Models
{
    public class Ingredient
    {
        public string Name { get; set; }

        public Ingredient(string name)
        {
            Name = name;
        }

        // Empty constructor for data binding and serialization
        public Ingredient() { }
    }
}
