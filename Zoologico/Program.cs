
using Zoologico.Animal;
namespace Zoologico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Welcome to the Zoo Management System!");
            Console.WriteLine("Creating enclosures...");
            List<Area.Enclosure> recintosDelZoo = new List<Area.Enclosure>();
            var acuarioPrincipal = new Area.Aquarium("Acuario Principal", 50, SalinityType.Saltwater);
            var aviarioCentral = new Area.Aviary("Aviario Tropical", 100, 30.0);
            var sabanaAfricana = new Area.Savanna("Sabana de Fauna Mayor", 200, true);
            recintosDelZoo.Add(acuarioPrincipal);
            recintosDelZoo.Add(aviarioCentral);
            recintosDelZoo.Add(sabanaAfricana);
            Console.WriteLine("Enclosures ready!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. Remove Animal");
                Console.WriteLine("3. List Animals in Enclosure");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleAddAnimal(recintosDelZoo);
                        break;
                    case "2":
                        HandleRemoveAnimal(recintosDelZoo);
                        break;
                    case "3":
                        HandleListAnimals(recintosDelZoo);
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
        private static Area.Enclosure GetSelectedEnclosure(List<Area.Enclosure> recintos)
        {
            Console.WriteLine("\n--- SELECCIONAR RECINTO ---");
            Console.WriteLine("Recintos disponibles:");
            for (int i = 0; i < recintos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recintos[i].Name}");
            }
            Console.Write("Selecciona el número del recinto: ");
            string selection = Console.ReadLine();
            if (int.TryParse(selection, out int index) && index > 0 && index <= recintos.Count)
            {
                return recintos[index - 1];
            }
            else
            {
                Console.WriteLine("¡Selección inválida!");
                return null;
            }
        }
        private static void HandleAddAnimal(List<Area.Enclosure> recintos)
        {
            Console.WriteLine("\n--- AGREGAR ANIMAL ---");
            Console.WriteLine("¿Qué tipo de animal quieres agregar?");
            Console.WriteLine("1. Fish (Pez)");
            Console.WriteLine("2. Bird (Pájaro)");
            Console.Write("Enter your choice: ");
            string animalType = Console.ReadLine();
            if (animalType != "1" && animalType != "2")
            {
                Console.WriteLine("Tipo de animal no reconocido. Cancelando.");
                return;
            }
            Console.Write("Introduce el Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Introduce la Edad (número): ");

            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Edad inválida. Cancelando operación.");
                return;
            }

            Animal newAnimal = null;
            Area.Enclosure targetEnclosure = null;

            if (animalType == "1") 
            {
                Console.WriteLine("Asignando al Acuario Principal.");
                newAnimal = new Fish("Pez Común", name, age, "Acuario Principal", SalinityLevel.Saltwater);
                targetEnclosure = recintos.FirstOrDefault(r => r.Name == "Acuario Principal");
            }
            else if (animalType == "2") 
            {
                Console.WriteLine("Asignando al Aviario Tropical.");
                newAnimal = new Bird("Pájaro", name, age, "Aviario Tropical", "Amarillo");
                targetEnclosure = recintos.FirstOrDefault(r => r.Name == "Aviario Tropical");
            }
            if (targetEnclosure != null && newAnimal != null)
            {
                if (targetEnclosure.AddAnimal(newAnimal))
                {
                    Console.WriteLine($"\n Animal {newAnimal.Name} agregado con éxito.");
                }
            }
            else
            {
                Console.WriteLine("Error: No se pudo encontrar el recinto o crear el animal.");
            }
        }
        private static void HandleRemoveAnimal(List<Area.Enclosure> recintos)
        {
            Console.WriteLine("\n--- REMOVER ANIMAL ---");
            var recintoSeleccionado = GetSelectedEnclosure(recintos);

            if (recintoSeleccionado != null)
            {
                recintoSeleccionado.ListAnimals();

                Console.Write("Introduce el Nombre del animal a remover: ");
                string animalName = Console.ReadLine();
                if (recintoSeleccionado.RemoveAnimal(animalName))
                {
                    Console.WriteLine($"{animalName} ha sido retirado con éxito de {recintoSeleccionado.Name}.");
                }
                else
                {
                    Console.WriteLine($"Error: No se encontró a {animalName} en el recinto.");
                }
            }
        }
        private static void HandleListAnimals(List<Area.Enclosure> recintos)
        {
            var recintoSeleccionado = GetSelectedEnclosure(recintos);

            if (recintoSeleccionado != null)
            {
                recintoSeleccionado.ListAnimals();
            }
        }
    }
}
