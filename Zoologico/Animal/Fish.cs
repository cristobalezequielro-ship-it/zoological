
using Zoologico.Area;
namespace Zoologico.Animal
{
    public class Fish : Vertebrado, IAcuatic
    {
        private SalinityLevel waterPreference;

        public SalinityLevel WaterType { get; set; }

        public SalinityLevel SalinityPreference
        {
            get { return this.waterPreference; }
        }

        public bool HasGills => true;
        public Fish(string species, string name, int ageInMonths, string enclosureName,
                    SalinityLevel waterPreference, HealthStatus healthStatus, DietType diet)
            : base(species, name, ageInMonths, enclosureName)
        {
            this.waterPreference = waterPreference;
            this.HealthStatus = healthStatus; 
            this.Diet = diet; 
            this.WaterType = waterPreference;
        }
        public void Swim()
        {
            switch (this.waterPreference)
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
        public override void MakeSound()
        {
            Console.WriteLine("Blub blub");
        }

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