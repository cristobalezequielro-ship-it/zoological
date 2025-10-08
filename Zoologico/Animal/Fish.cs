
using Zoologico.Area;
namespace Zoologico.Animal
{
    public class Fish : Vertebrado, IAcuatic
    {
        public SalinityLevel WaterType { get; set; }

        public bool HasGills => true;
        public Fish(string species, string name, int age, string enclosure, SalinityLevel waterType)
            : base(species, name, age, enclosure)
        {
            this.WaterType = waterType;
            this.Diet = DietType.Carnivore; 
        }
        public void Swim()
        {
            switch (this.WaterType)
            {
                case SalinityLevel.Freshwater:
                    Console.WriteLine($"{this.Name} está nadando tranquilamente en agua dulce.");
                    break;
                case SalinityLevel.Saltwater:
                    Console.WriteLine($"{this.Name} está nadando activamente en agua salada.");
                    break;
                default:
                    Console.WriteLine($"{this.Name} está nadando.");
                    break;
            }
        }

=======
﻿namespace Zoologico.Animal
{
    public class Fish : Vertebrado, IAcuatic
    {
        public string WaterType { get; set; }
        public Fish(string species, string name, int age, string enclosure, string waterType)
            : base(species, name, age, enclosure) 
        {
            WaterType = waterType;
        }
        public void Swim()
        {
            Console.WriteLine($"{Name} está nadando.");
        }
        public bool HasGills => true;
>>>>>>> 2c5573fae88815f7f263ab74f4890a00b4efa51d
        public override void MakeSound()
        {
            Console.WriteLine("Blub blub");
        }
<<<<<<< HEAD

        public override void Eat(string foodItem)
        {
            switch (this.Diet)
            {
                case DietType.Carnivore:
                    Console.WriteLine($"{this.Name} (Carnívoro) devora {foodItem} con un movimiento rápido.");
                    break;
                case DietType.Herbivore:
                    Console.WriteLine($"{this.Name} (Herbívoro) filtra las algas y plancton de {foodItem}.");
                    break;
                case DietType.Omnivore:
                    Console.WriteLine($"{this.Name} (Omnívoro) mordisquea {foodItem} cerca de la superficie.");
                    break;
                default:
                    base.Eat(foodItem);
                    break;
            }
        }
    }
}