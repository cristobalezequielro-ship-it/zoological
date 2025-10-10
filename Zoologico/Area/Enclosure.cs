
namespace Zoologico.Area
{
    public abstract class Enclosure
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public AreaType Type { get; private set; }
        protected List<Animal.Animal> Animals { get; set; } = new List<Animal.Animal>();

        public Enclosure(int id, string name, int capacity, AreaType type)
        {
            this.Id = id;
            this.Name = name;
            this.Capacity = capacity;
            this.Type = type;
        }

        public virtual bool AddAnimal(Animal.Animal animal)
        {
            if (Animals.Count >= Capacity)
            {
                Console.WriteLine($"Error: The enclosure {this.Name} is full.");
                return false;
            }
            if (Animals.Any(a => a.Name.Equals(animal.Name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Error: The animal {animal.Name} is already in the enclosure {this.Name}.");
                return false;
            }
            Animals.Add(animal);
            return true;
        }

        public bool RemoveAnimal(string animalName)
        {
            var animalToRemove = Animals.FirstOrDefault(a => a.Name.Equals(animalName, StringComparison.OrdinalIgnoreCase));
            if (animalToRemove != null)
            {
                Animals.Remove(animalToRemove);
                Console.WriteLine($"\nAnimal {animalName} successfully removed from {this.Name}.");
                return true;
            }
            return false;
        }
        public virtual void ListAnimals()
        {
            Console.WriteLine($"--- Animals in {this.Name} (ID: {this.Id}, Tipo: {this.Type}) ---");
            if (this.Animals.Any())
            {
                foreach (var animal in this.Animals)
                {
                    Console.WriteLine(animal.GetInformation());
                }
            }
            else
            {
                Console.WriteLine("The enclosure is empty.");
            }
        }
    }
}