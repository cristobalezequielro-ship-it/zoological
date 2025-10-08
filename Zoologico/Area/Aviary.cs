
using Zoologico.Animal; 
namespace Zoologico.Area
{
    public class Aviary : Enclosure
    {
        public double HeightMeters { get; set; }
        public Aviary(string name, int capacity, double height)
            : base(name, capacity, AreaType.Aereo)
        {
            this.HeightMeters = height;
        }
        public void InspectNet()
        {
            Console.WriteLine($"Inspeccionando la red de contención del aviario {this.Name}.");
        }
        public override bool AddAnimal(Animal animal)
        {
            if (animal is IFlyer)
            {
                return base.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} no puede ser agregado. El aviario solo acepta animales voladores.");
                return false;
            }
        }
    }
}