
namespace Zoologico.Area
{
    public class Aquarium : Enclosure
    {
        public SalinityLevel Salinity { get; set; }
        public Aquarium(string name, int capacity, SalinityLevel salinity)
            : base(name, capacity, AreaType.Acuatico)
        {
            this.Salinity = salinity;
        }
        public void CheckWaterQuality()
        {
            Console.WriteLine($"Verificando la calidad del agua en {this.Name}. Nivel de Salinidad: {this.Salinity}.");
        }

        public override bool AddAnimal(Animal animal)
        {
            if (animal is IAcuatic)
            {
                return base.AddAnimal(animal);
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} (Especie: {animal.Species}) no es acuático y no puede entrar al {this.Name}.");
                return false;
            }
        }
    }
}