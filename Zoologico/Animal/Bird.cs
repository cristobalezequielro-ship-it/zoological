
namespace Zoologico.Animal
{
    public class Bird : Vertebrado, IFlyer
    {
        public string FeatherColor { get; set; }
        public Bird(string species, string name, int age, string enclosure, string featherColor)
            : base(species, name, age, enclosure)
        {
            this.FeatherColor = featherColor;
            this.Diet = DietType.Omnivore;
        }
        public override void Eat(string foodItem)
        {
            switch (this.Diet)
            {
                case DietType.Omnivore:
                    Console.WriteLine($"{this.Name} (Omnívoro) picotea {foodItem} con gran precisión.");
                    break;
                case DietType.Carnivore:
                    Console.WriteLine($"{this.Name} (Carnívoro) desgarra {foodItem} con su pico y garras.");
                    break;
                default:
                    base.Eat(foodItem);
                    break;
            }
        }
        public override void MoveSkeleton()
        {
            Console.WriteLine($"{this.Name} flexiona su estructura ósea para batir sus alas o caminar.");
        }
        public void Fly()
        {
            Console.WriteLine($"{this.Name} está batiendo sus alas y volando.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Pio pio");
        }
    }
}