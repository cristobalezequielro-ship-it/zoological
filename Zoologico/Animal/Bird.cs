
namespace Zoologico.Animal
{
    public class Bird : Vertebrado, IFlyer
    {
        public string FeatherColor { get; set; }
        public Bird(string species, string name, int ageInMonths, string enclosureName,
                    HealthStatus healthStatus, DietType diet, string featherColor)
            : base(species, name, ageInMonths, enclosureName)
        {
            this.FeatherColor = featherColor;
            this.HealthStatus = healthStatus;
            this.Diet = diet;
        }
        public void Fly()
        {
            Console.WriteLine($"{this.Name} está batiendo sus alas y volando en el aviario.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Pio pio");
        }
    }
}