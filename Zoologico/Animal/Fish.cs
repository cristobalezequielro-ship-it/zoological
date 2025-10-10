
using Zoologico.Area;

namespace Zoologico.Animal
{
    public class Fish : Vertebrado, IAcuatic
    {
        private SalinityLevel waterPreference;

        public SalinityLevel SalinityPreference
        {
            get { return this.waterPreference; }
        }
        public SalinityLevel WaterType { get; set; }
        public bool HasGills => true;
        public Fish(string species, string name, int ageInMonths, string enclosureName,
                    SalinityLevel salinityWaterPreference, HealthStatus healthStatus, DietType diet)
            : base(species, name, ageInMonths, enclosureName)
        {
            this.waterPreference = salinityWaterPreference;
            this.HealthStatus = healthStatus;
            this.Diet = diet;
            this.WaterType = salinityWaterPreference;
        }

        public void Swim() => Console.WriteLine($"{this.Name} is swimming.");
        public override void MakeSound() => Console.WriteLine("Blub blub");

        public override void Eat(string foodItem)
        {
            string dietString = $"{this.Name}";

            switch (this.Diet)
            {
                case DietType.Carnivore:
                    Console.WriteLine($"{dietString} devours {foodItem} with a quick movement.");
                    break;
                case DietType.Herbivore:
                    Console.WriteLine($"{dietString} filters algae and plankton from {foodItem}.");
                    break;
                case DietType.Omnivore:
                    Console.WriteLine($"{dietString} nibbles {foodItem} near the surface.");
                    break;
                default:
                    Console.WriteLine($"{dietString} is eating {foodItem}.");
                    break;
            }
        }
    }
}