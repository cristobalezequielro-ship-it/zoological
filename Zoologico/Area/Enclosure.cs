

namespace Zoologico.Area
{
    public abstract class Enclosure
    {
        public int Id { get; }
        public string Name { get; set; }
        public AreaType Type { get; set; }
        public int MaxCapacity { get; set; }
        public List<Zoologico.Animal.Animal> CurrentAnimals { get; } = new List<Zoologico.Animal.Animal>();
        protected Enclosure(int id, string name, int maxCapacity, AreaType areaType)
        {
            this.Id = id;
            this.Name = name;
            this.MaxCapacity = maxCapacity;
            this.Type = areaType;
        }

        public virtual bool AddAnimal(Zoologico.Animal.Animal animal)
        {
            if (CurrentAnimals.Count < MaxCapacity)
            {
                CurrentAnimals.Add(animal);
                animal.Enclosure = this.Name;
                Console.WriteLine($"Se agregó a {animal.Name} al recinto {this.Name}.");
                return true;
            }
            else
            {
                Console.WriteLine($"No se puede agregar {animal.Name} a {this.Name}: capacidad máxima alcanzada.");
                return false;
            }
        }

        public bool RemoveAnimal(string name)
        {
            var animalToRemove = CurrentAnimals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (animalToRemove != null)
            {
                CurrentAnimals.Remove(animalToRemove);
                animalToRemove.Enclosure = "None";
                Console.WriteLine($"{animalToRemove.Name} ha sido retirado con éxito de {this.Name}.");
                return true;
            }
            return false;
        }

        public void ListAnimals()
        {
            Console.WriteLine($"\n--- Animales en el recinto {this.Name} (ID: {this.Id}, Tipo: {this.Type}) ---");
            if (CurrentAnimals.Count == 0)
            {
                Console.WriteLine("El recinto está vacío.");
                return;
            }
            foreach (var animal in CurrentAnimals)
            {
                Console.WriteLine(animal.GetInformation());
            }
        }
    }
}