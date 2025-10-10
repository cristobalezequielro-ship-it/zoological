
namespace Zoologico.Animal
{
    public class Macaw : Bird
    {
        public Macaw(string name, int age, string enclosure, string featherColor)
            : base("Guacamaya", name, age, enclosure, featherColor)
        {
            this.Diet = DietType.Omnivore;
        }
        public override void Eat(string foodItem)
        {
            Console.WriteLine($"{this.Name} (Guacamayo) está rompiendo y comiendo {foodItem}, usando su fuerte pico para abrir nueces.");
        }
        public override void MoveSkeleton()
        {
            Console.WriteLine($"{this.Name} está batiendo su esqueleto para volar largas distancias.");
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name} emite un fuerte graznido o chillido característico.");
        }
    }
}