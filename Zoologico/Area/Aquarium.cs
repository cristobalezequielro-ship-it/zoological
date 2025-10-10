
using Zoologico.Animal; 
namespace Zoologico.Area
{
    public class Aquarium : Enclosure
    {
        public SalinityLevel Salinity { get; set; }

        public Aquarium(int id, string name, int capacity, SalinityLevel salinity)
            : base(id, name, capacity, AreaType.Acuatico)
        {
            this.Salinity = salinity;
        }

        public void CheckWaterQuality()
        {
            Console.WriteLine($"Checking water quality in {this.Name}. Salinity Level: {this.Salinity}.");
        }

        public override bool AddAnimal(Animal.Animal animal)
        {
            if (animal is IAcuatic acuatic)
            {
                if (acuatic.SalinityPreference == this.Salinity)
                {
                    return base.AddAnimal(animal);
                }
                else
                {
                    Console.WriteLine($"Error: {animal.Name} prefers {acuatic.SalinityPreference} and cannot enter the {this.Name} enclosure due to {this.Salinity} salinity.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} is not an aquatic animal and cannot enter the {this.Name} aquarium.");
                return false;
            }
        }
        public override void ListAnimals()
        {
            Console.WriteLine($"--- Animals in {this.Name} (ID: {this.Id}, Tipo: {this.Type}) ---");
            Console.WriteLine($"*** Water Salinity: {this.Salinity} ***");

            if (this.Animals.Any())
            {
                foreach (var animal in this.Animals)
                {
                    Console.WriteLine(animal.GetInformation());
                }
            }
            else
            {
                Console.WriteLine("The enclosure is empty.");
            }
        }
    }
}