
using Zoologico.Animal;


namespace Zoologico.Area
{
    public class Savanna : Enclosure
    {
        public bool MixPredatorsAndPrey { get; set; }
        public Savanna(int id, string name, int capacity, bool mixPredatorsPrey)
            : base(id, name, capacity, AreaType.Terrestre)
        {
            this.MixPredatorsAndPrey = mixPredatorsPrey;
        }

        public void ReplenishWaterHole()
        {
            Console.WriteLine($"Rellenando la charca de agua en la {this.Name}.");
        }

        public override bool AddAnimal(Animal.Animal animal)
        {
            if (animal is ITerrestrial)
            {
                if (!this.MixPredatorsAndPrey)
                {
                    bool isNewPredator = animal is IPredator;
                    bool hasConflict = CurrentAnimals.Any(a => (a is IPredator) != isNewPredator);

                    if (hasConflict)
                    {
                        Console.WriteLine($"Error: No se puede agregar {animal.Name} (Especie: {animal.Species}) al recinto {this.Name} debido a la mezcla de depredadores y presas.");
                        return false;
                    }
                }
                return base.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} (Especie: {animal.Species}) no es terrestre y no puede entrar a la sabana {this.Name}.");
                return false;
            }
        }
    }
}