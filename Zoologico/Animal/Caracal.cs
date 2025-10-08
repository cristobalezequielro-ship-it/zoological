
using Zoologico.Animal;
namespace Zoologico.Animale
{
    public class Caracal : Mamifero, ITerrestrial
    {
        public string FurColor { get; set; }

        public Caracal(string name, int age, string enclosure, string furColor)
            : base("Caracal", name, age, enclosure, true, 78)
        {
            this.FurColor = furColor;
            this.Diet = DietType.Carnivore;
        }
        public override void Eat(string foodItem)
        {
            if (this.Diet == DietType.Carnivore)
            {
                Console.WriteLine($"{this.Name} (Carnívoro) está acechando, desgarrando y consumiendo {foodItem} con gran habilidad.");
            }
            else
            {
                base.Eat(foodItem);
            }
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name} (Caracal) emite un maullido fuerte y sisea.");
        }
        public int NumberOfLegs => 4;
        public void Run()
        {
            Console.WriteLine($"{this.Name} corre muy rápido a gran velocidad en la sabana.");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.Name} camina cuidadosamente, acechando.");
        }

        public void Hunt()
        {
            Console.WriteLine($"{this.Name} realiza un salto prodigioso de 3 metros para cazar aves.");
        }

        public bool IsNocturnal => true;
    }
}