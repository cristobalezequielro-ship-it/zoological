
﻿
namespace Zoologico.Animal
{
    public abstract class Vertebrado : Animal
    {
        public Vertebrado(string species, string name, int age, string enclosure)
            : base(species, name, age, enclosure)
        {
        }
        public virtual void MoveSkeleton()
        {
            Console.WriteLine($"{this.Name} está moviendo su estructura ósea interna.");
        public void MoveSkeleton()
        {
            Console.WriteLine($"{Name} está moviendo su estructura ósea interna.");
        }
    }
}