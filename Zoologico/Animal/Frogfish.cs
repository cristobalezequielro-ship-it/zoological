
using Zoologico.Area;
namespace Zoologico.Animal
{
    public class Frogfish : Fish
    {
        public string LureColor { get; set; }
        public Frogfish(string name, int age, string enclosure, SalinityLevel waterType, string lureColor)
            : base("Pez Sapo", name, age, enclosure, waterType)
        {
            this.Diet = DietType.Carnivore;
            this.LureColor = lureColor;
        }
        public new void Swim()
        {
            Console.WriteLine($"{this.Name} (Pez Sapo) se arrastra y camina lentamente por el fondo marino.");
        }
        public void LureAndAmbush()
        {
            Console.WriteLine($"{this.Name} mueve su señuelo ({this.LureColor}) y embosca a su presa.");
        }
        public override void Eat(string foodItem)
        {
            Console.WriteLine($"{this.Name} (Pez Sapo) se traga de golpe a {foodItem}.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Croac!");
        }
    }
}