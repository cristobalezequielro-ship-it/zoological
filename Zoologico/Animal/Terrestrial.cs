
namespace Zoologico.Animal
{
    
    public class Terrestrial : Vertebrado, ITerrestrial, IPredator 
    {
        public HealthStatus HealthStatus { get; set; }
        public DietType Diet { get; set; }
        public Terrestrial(string name, int ageInMonths, string enclosureName, HealthStatus healthStatus, DietType diet)
            : base("Animal Terrestre", name, ageInMonths, enclosureName)
        {
            this.HealthStatus = healthStatus;
            this.Diet = diet;
        }
        public override void MakeSound() => Console.WriteLine($"{this.Name} hace un ruido terrestre.");
        public void Hunt(Animal prey) => Console.WriteLine($"{this.Name} está cazando de forma genérica.");
    }
}
