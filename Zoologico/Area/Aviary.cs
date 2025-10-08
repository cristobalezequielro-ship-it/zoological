
using Zoologico.Animal;


namespace Zoologico.Area
{
    public class Aviary : Enclosure
    {
        public double HeightMeters { get; set; }
        public bool MixPredatorsAndPrey { get; set; }
        public Aviary(int id, string name, int capacity, double height, bool mixPredatorsPrey = false)
            : base(id, name, capacity, AreaType.Aereo)
        {
            this.HeightMeters = height;
            this.MixPredatorsAndPrey = mixPredatorsPrey;
        }

        public void InspectNet()
        {
            Console.WriteLine($"Inspeccionando la red de contención del aviario {this.Name}.");
        }

        public override bool AddAnimal(Animal.Animal animal)
        {
            if (animal is IFlyer)
            {
                if (!this.MixPredatorsAndPrey)
                {
                    bool isNewPredator = animal is IPredator;
                    bool hasConflict = CurrentAnimals.Any(a => (a is IPredator) != isNewPredator);

                    if (hasConflict)
                    {
                        Console.WriteLine($"Error: No se puede agregar {animal.Name} al aviario. Hay conflicto entre depredadores y presas.");
                        return false;
                    }
                }
                return base.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} (Especie: {animal.Species}) no es aéreo y no puede entrar al aviario {this.Name}.");
                return false;
            }
        }
    }
}