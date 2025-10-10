
namespace Zoologico.Animal
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string Enclosure { get; set; }
        public DietType Diet { get; set; }

        public Animal(string species, string name, int ageInMonths, string enclosureName)
        {
            this.Species = species;
            this.Name = name; 
            this.Age = ageInMonths;
            this.Enclosure = enclosureName;
            this.HealthStatus = HealthStatus.Optima;
            this.Diet = DietType.Undefined;
            this.Id = new Random().Next(1000, 9999);
        }
        protected string GetDietString()
        {
            switch (this.Diet)
            {
                case DietType.Carnivore:
                    return "Carnívoro";
                case DietType.Herbivore:
                    return "Herbívoro";
                case DietType.Omnivore:
                    return "Omnívoro";
                default:
                    return "Dieta Desconocida";
            }
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{this.Name} makes a generic sound. (Specific sound must be defined in the derived class).");
        }

        public virtual void Eat(string foodItem)
        {
            // Uso de GetDietString()
            Console.WriteLine($"{this.Name} ({GetDietString()}) is consuming {foodItem}.");
        }

        public virtual void InteractWithEnrichment(string item)
        {
            Console.WriteLine($"{this.Name} is interacting with the enrichment item: {item}.");
        }

        public string GetInformation()
        {
            // Uso de GetDietString()
            return $"--- Animal ID: {this.Id} ---\n" +
                   $"Nombre: {this.Name}, Especie: {this.Species}\n" +
                   $"Edad: {this.Age} meses, Salud: {this.HealthStatus}\n" +
                   $"Recinto: {this.Enclosure}\n" +
                   $"Dieta: {GetDietString()}"; // CORRECCIÓN AQUÍ
        }
    }
}