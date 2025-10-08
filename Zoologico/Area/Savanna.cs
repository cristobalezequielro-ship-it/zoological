
namespace Zoologico.Area
{
    public class Savanna : Enclosure
    {
        public bool MixPredatorsAndPrey { get; set; }
        public Savanna(string name, int capacity, bool mixPredatorsPrey)
            : base(name, capacity, AreaType.Terrestre)
        {
            this.MixPredatorsAndPrey = mixPredatorsPrey;
        }
        public void ReplenishWaterHole()
        {
            Console.WriteLine($"Rellenando la charca de agua en la {this.Name}.");
        }
        public override bool AddAnimal(Animal animal)
        {
            if (!(animal is IAcuatic))
            {
                return base.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} (Especie: {animal.Species}) requiere agua constante y no es apto para la sabana.");
                return false;
            }
        }
    }
}