namespace Zoologico.Animal
{
    public abstract class Invertebrado : Animal
    {
        public Invertebrado(string species, string name, int age, string enclosure)
            : base(species, name, age, enclosure)
        {
        }
        public virtual void ShedSkin()
        {
            Console.WriteLine($"{Name} está mudando su capa externa.");
        }
    }
}