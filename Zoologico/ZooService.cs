
using Zoologico.Animal;
using Zoologico.Area;
namespace Zoologico
{
    public class ZooService
    {
        private List<Area.Enclosure> recintosDelZoo { get; set; } = new List<Area.Enclosure>();

        public ZooService()
        {
            InitializeEnclosures();
        }

        private void InitializeEnclosures()
        {
            int nextId = 1;

            var acuarioPrincipal = new Area.Aquarium(nextId++, "Acuario Principal", 5, SalinityLevel.Freshwater);
            var aviarioCentral = new Area.Aviary(nextId++, "Aviario Tropical", 3, 30.0, false);
            var sabanaAfricana = new Area.Savanna(nextId++, "Sabana de Fauna Mayor", 2, true);

            recintosDelZoo.Add(acuarioPrincipal);
            recintosDelZoo.Add(aviarioCentral);
            recintosDelZoo.Add(sabanaAfricana);
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the Zoo Management System!");
            Console.WriteLine("Enclosures ready!");
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. Remove Animal");
                Console.WriteLine("3. List Animals in Enclosure");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleAddAnimal();
                        break;
                    case "2":
                        HandleRemoveAnimal();
                        break;
                    case "3":
                        HandleListAnimals();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
            Console.WriteLine("Execution finished. Goodbye!");
        }

        private Enclosure GetSelectedEnclosure()
        {
            Console.WriteLine("\n--- SELECCIONAR RECINTO ---");
            Console.WriteLine("Recintos disponibles:");
            for (int i = 0; i < recintosDelZoo.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recintosDelZoo[i].Name} (ID: {recintosDelZoo[i].Id})");
            }
            Console.Write("Selecciona el número del recinto: ");
            string selection = Console.ReadLine();
            if (int.TryParse(selection, out int index) && index > 0 && index <= recintosDelZoo.Count)
            {
                return recintosDelZoo[index - 1];
            }
            else
            {
                Console.WriteLine("¡Selección inválida!");
                return null;
            }
        }

        private void HandleAddAnimal()
        {
            Console.WriteLine("\n--- AGREGAR ANIMAL ---");
            Console.WriteLine("¿Qué tipo de **comportamiento** quieres agregar?");
            Console.WriteLine("1. Nadador (Acuático) 🐟");
            Console.WriteLine("2. Volador (Aéreo) 🦅");
            Console.WriteLine("3. Terrestre (Sabana) 🦒");
            Console.Write("Enter your choice: ");
            string behaviorChoice = Console.ReadLine();

            if (behaviorChoice != "1" && behaviorChoice != "2" && behaviorChoice != "3")
            {
                Console.WriteLine("Opción de comportamiento no reconocida. Cancelando.");
                return;
            }
            Console.Write("Introduce el Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Introduce la EDAD (solo el número): ");
            if (!int.TryParse(Console.ReadLine(), out int ageValue)) { Console.WriteLine("Edad inválida. Cancelando."); return; }
            Console.Write("Unidad: [D]ías, [M]eses, [A]ños (D/M/A): ");
            string unit = Console.ReadLine().ToUpper();
            int ageInMonths = (unit == "A") ? (ageValue * 12) : (unit == "D" ? (int)System.Math.Round((double)ageValue / 30.0) : ageValue);


            Console.WriteLine("Niveles de Salud: [1] Óptima, [2] Good, [3] Critical");
            Console.Write("Ingrese el estado de salud (1, 2, o 3): ");
            string healthChoice = Console.ReadLine();
            HealthStatus finalHealth = (healthChoice == "1") ? HealthStatus.Optima :
                                       (healthChoice == "2" ? HealthStatus.Good : HealthStatus.Critical);

   
            Console.WriteLine("Tipo de Dieta: [1] Carnívoro, [2] Herbívoro, [3] Omnívoro");
            Console.Write("Ingrese la dieta (1, 2, o 3): ");
            string dietChoice = Console.ReadLine();
            DietType finalDiet = (dietChoice == "1") ? DietType.Carnivore :
                                 (dietChoice == "2" ? DietType.Herbivore : DietType.Omnivore);


            Zoologico.Animal.Animal newAnimal = null;
            string targetEnclosureName = string.Empty;

            switch (behaviorChoice)
            {
                case "1":
                    targetEnclosureName = "Acuario Principal";
                    Console.WriteLine("Tipo de Agua: [1] Dulce, [2] Salada");
                    Console.Write("Ingrese el tipo de agua (1 o 2): ");
                    string waterChoice = Console.ReadLine();
                    SalinityLevel finalSalinity = (waterChoice == "2") ? SalinityLevel.Saltwater : SalinityLevel.Freshwater;

                    newAnimal = new Fish("Pez Genérico", name, ageInMonths, targetEnclosureName, finalSalinity, finalHealth, finalDiet);
                    break;

                case "2":
                    targetEnclosureName = "Aviario Tropical";
                    newAnimal = new Bird("Pájaro Genérico", name, ageInMonths, targetEnclosureName, finalHealth, finalDiet, "Gris");
                    break;

                case "3":
                    targetEnclosureName = "Sabana de Fauna Mayor";
                    newAnimal = new Terrestrial(name, ageInMonths, targetEnclosureName, finalHealth, finalDiet);
                    break;
            }

            Area.Enclosure targetEnclosure = recintosDelZoo.FirstOrDefault(r => r.Name == targetEnclosureName);

            if (targetEnclosure != null && newAnimal != null)
            {
                if (targetEnclosure.AddAnimal(newAnimal))
                {
                    Console.WriteLine($"\nAnimal {newAnimal.Name} agregado con éxito a {targetEnclosure.Name}.");
                }
            }
            else
            {
                Console.WriteLine("Error: No se pudo encontrar el recinto o crear el animal.");
            }
        }

        private void HandleRemoveAnimal()
        {
            Console.WriteLine("\n--- REMOVER ANIMAL ---");
            var recintoSeleccionado = GetSelectedEnclosure();

            if (recintoSeleccionado != null)
            {
                recintoSeleccionado.ListAnimals();

                Console.Write("Introduce el Nombre del animal a remover: ");
                string animalName = Console.ReadLine();
                if (!recintoSeleccionado.RemoveAnimal(animalName))
                {
                    Console.WriteLine($"Error: No se encontró a {animalName} en el recinto.");
                }
            }
        }

        private void HandleListAnimals()
        {
            var recintoSeleccionado = GetSelectedEnclosure();
            recintoSeleccionado?.ListAnimals();
        }
    }
}