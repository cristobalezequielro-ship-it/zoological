
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
            Console.WriteLine($"Verificando la calidad del agua en {this.Name}. Nivel de Salinidad: {this.Salinity}.");
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
                    Console.WriteLine($"Error: {animal.Name} prefiere {acuatic.SalinityPreference} y no puede entrar al acuario {this.Name} con salinidad {this.Salinity}.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Error: {animal.Name} no es acuático y no puede entrar al acuario {this.Name}.");
                return false;
            }
        }
    }
}