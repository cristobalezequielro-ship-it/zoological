
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
        public virtual void MakeSound()
        {
            Console.WriteLine($"{this.Name} hace un sonido genérico. (El sonido específico debe definirse en la clase hija).");
        }
        public virtual void Eat(string foodItem)
        {
            Console.WriteLine($"{this.Name} ({this.Diet}) está consumiendo {foodItem}.");
        }
        public virtual void InteractWithEnrichment(string item)
        {
            Console.WriteLine($"{this.Name} está interactuando con el objeto de enriquecimiento: {item}.");
        }
        public string GetInformation()
        {
            return $"--- Animal ID: {this.Id} ---\n" +
                   $"Nombre: {this.Name}, Especie: {this.Species}\n" +
                   $"Edad: {this.Age} meses, Salud: {this.HealthStatus}\n" +
                   $"Recinto: {this.Enclosure}\n" +
                   $"Dieta: {this.Diet}";
        }
    }
}