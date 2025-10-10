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
            AddInitialAnimals();
        }

        private void InitializeEnclosures()
        {
            int nextId = 1;
            var acuarioPrincipal = new Area.Aquarium(nextId++, "Acuario Principal", 5, SalinityLevel.Saltwater);

            var aviarioCentral = new Area.Aviary(nextId++, "Aviario Tropical", 3, 30.0, false);
            var sabanaAfricana = new Area.Savanna(nextId++, "Sabana de Fauna Mayor", 2, true);

            recintosDelZoo.Add(acuarioPrincipal);
            recintosDelZoo.Add(aviarioCentral);
            recintosDelZoo.Add(sabanaAfricana);
        }

        private void AddInitialAnimals()
        {
            Console.WriteLine("\n--- Adding Initial Animals ---");
            var fish = new Fish("Pez Payaso", "Nemo", 18, "Acuario Principal", SalinityLevel.Saltwater, HealthStatus.Optima, DietType.Omnivore);
            recintosDelZoo.First(r => r.Name == "Acuario Principal").AddAnimal(fish);
            Console.WriteLine($"[INFO] Added {fish.Name} to Acuario Principal.");
            var bird = new Bird("Loro Gris", "Coco", 36, "Aviario Tropical", HealthStatus.Good, DietType.Herbivore, "Gris");
            recintosDelZoo.First(r => r.Name == "Aviario Tropical").AddAnimal(bird);
            Console.WriteLine($"[INFO] Added {bird.Name} to Aviario Tropical.");
            var terrestrial = new Terrestrial("Jirafa", "Melman", 60, "Sabana de Fauna Mayor", HealthStatus.Optima, DietType.Herbivore);
            recintosDelZoo.First(r => r.Name == "Sabana de Fauna Mayor").AddAnimal(terrestrial);
            Console.WriteLine($"[INFO] Added {terrestrial.Name} to Sabana de Fauna Mayor.");
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
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.WriteLine("Execution finished. Goodbye!");
        }
        private Enclosure GetSelectedEnclosure()
        {
            Console.WriteLine("\n--- SELECT ENCLOSURE ---");
            Console.WriteLine("Available enclosures:");
            for (int i = 0; i < recintosDelZoo.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recintosDelZoo[i].Name} (ID: {recintosDelZoo[i].Id})");
            }
            Console.Write("Select the enclosure number: ");
            string selection = Console.ReadLine();

            if (int.TryParse(selection, out int index) && index > 0 && index <= recintosDelZoo.Count)
            {
                return recintosDelZoo[index - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection!");
                return null;
            }
        }

        private void HandleAddAnimal()
        {
            Console.WriteLine("\n--- ADD ANIMAL ---");
            Console.WriteLine("Which type of **behavior** do you want to add?");
            Console.WriteLine("1. Swimmer (Aquatic) 🐟");
            Console.WriteLine("2. Flyer (Aerial) 🦅");
            Console.WriteLine("3. Terrestrial (Savanna) 🦒");
            Console.Write("Enter your choice: ");
            string behaviorChoice = Console.ReadLine();

            if (behaviorChoice != "1" && behaviorChoice != "2" && behaviorChoice != "3")
            {
                Console.WriteLine("Unrecognized behavior option. Cancelling.");
                return;
            }

            Console.Write("Enter the Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the Species: ");
            string species = Console.ReadLine();
            int dia, mes, anio;
            int edadEnMeses;
            do
            {
                Console.WriteLine("\n--- ENTER DATE OF BIRTH ---");
                Console.Write("Enter the DAY of birth: ");
                dia = ReadIntFromConsole();

                Console.Write("Enter the MONTH of birth: ");
                mes = ReadIntFromConsole();

                Console.Write("Enter the YEAR of birth (YYYY): ");
                anio = ReadIntFromConsole();

                if (IsValidDate(dia, mes, anio))
                {
                    edadEnMeses = CalculateAgeInMonths(dia, mes, anio);
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease try again.");
                }
            } while (true);

            Console.WriteLine("Health Levels: [1] Optima, [2] Good, [3] Critical");
            Console.Write("Enter health status (1, 2, or 3): ");
            HealthStatus finalHealth;
            if (int.TryParse(Console.ReadLine(), out int healthVal) && healthVal >= 1 && healthVal <= 3)
            {
                finalHealth = (HealthStatus)healthVal;
            }
            else
            {
                Console.WriteLine("Invalid health selection. Assuming Optima.");
                finalHealth = HealthStatus.Optima;
            }

            Console.WriteLine("Diet Type: [1] Carnivore, [2] Herbivore, [3] Omnivore");
            Console.Write("Enter the diet (1, 2, or 3): ");
            DietType finalDiet;
            if (int.TryParse(Console.ReadLine(), out int dietVal) && dietVal >= 1 && dietVal <= 3)
            {
                finalDiet = (DietType)dietVal;
            }
            else
            {
                Console.WriteLine("Invalid diet selection. Assuming Omnivore.");
                finalDiet = DietType.Omnivore;
            }

            Zoologico.Animal.Animal newAnimal = null;
            string targetEnclosureName = string.Empty;

            switch (behaviorChoice)
            {
                case "1":
                    targetEnclosureName = "Acuario Principal";

                    SalinityLevel finalSalinity;
                    int waterChoiceInt;
                    do
                    {
                        Console.WriteLine("Water Type: [1] Freshwater, [2] Saltwater");
                        Console.Write("Enter water type (1 or 2): ");
                        waterChoiceInt = ReadIntFromConsole();

                        if (waterChoiceInt == 1)
                        {
                            finalSalinity = SalinityLevel.Freshwater;
                            break;
                        }
                        else if (waterChoiceInt == 2)
                        {
                            finalSalinity = SalinityLevel.Saltwater;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid water type selection. Please enter 1 or 2.");
                        }
                    } while (true);

                    newAnimal = new Fish(species, name, edadEnMeses, targetEnclosureName, finalSalinity, finalHealth, finalDiet);
                    break;

                case "2":
                    targetEnclosureName = "Aviario Tropical";
                    newAnimal = new Bird(species, name, edadEnMeses, targetEnclosureName, finalHealth, finalDiet, "Gris");
                    break;

                case "3":
                    targetEnclosureName = "Sabana de Fauna Mayor";
                    newAnimal = new Terrestrial(species, name, edadEnMeses, targetEnclosureName, finalHealth, finalDiet);
                    break;
            }

            Area.Enclosure targetEnclosure = recintosDelZoo.FirstOrDefault(r => r.Name == targetEnclosureName);

            if (targetEnclosure != null && newAnimal != null)
            {
                if (targetEnclosure.AddAnimal(newAnimal))
                {
                    Console.WriteLine($"\nAnimal {newAnimal.Name} successfully added to {targetEnclosure.Name}.");
                }
            }
            else
            {
                Console.WriteLine("Error: Could not find the enclosure or create the animal.");
            }
        }
        private void HandleRemoveAnimal()
        {
            Console.WriteLine("\n--- REMOVE ANIMAL ---");
            var recintoSeleccionado = GetSelectedEnclosure();

            if (recintoSeleccionado != null)
            {
                recintoSeleccionado.ListAnimals();

                Console.Write("Enter the Name of the animal to remove: ");
                string animalName = Console.ReadLine();
                if (!recintoSeleccionado.RemoveAnimal(animalName))
                {
                    Console.WriteLine($"Error: {animalName} was not found in the enclosure.");
                }
            }
        }

        private void HandleListAnimals()
        {
            var recintoSeleccionado = GetSelectedEnclosure();
            recintoSeleccionado?.ListAnimals();
        }

        private int ReadIntFromConsole()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Input Error. Expected an integer number.");
            return -1;
        }

        private bool IsValidDate(int day, int month, int year)
        {
            if (day == -1 || month == -1 || year == -1) return false;

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Error: The month must be between 1 and 12.");
                return false;
            }

            if (year > DateTime.Now.Year)
            {
                Console.WriteLine($"Error: The year of birth cannot be after the current year ({DateTime.Now.Year}).");
                return false;
            }

            try
            {
                int daysInMonth = DateTime.DaysInMonth(year, month);
                if (day < 1 || day > daysInMonth)
                {
                    Console.WriteLine($"Error: The day must be between 1 and {daysInMonth} for month {month}.");
                    return false;
                }

                DateTime dateToCheck = new DateTime(year, month, day);
                if (dateToCheck > DateTime.Now)
                {
                    Console.WriteLine("Error: The date of birth cannot be in the future.");
                    return false;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error: Invalid combined date.");
                return false;
            }

            return true;
        }
        private int CalculateAgeInMonths(int day, int month, int year)
        {
            var birthDate = new DateTime(year, month, day);
            var today = DateTime.Now;

            int months = ((today.Year - birthDate.Year) * 12) + today.Month - birthDate.Month;

            if (today.Day < birthDate.Day)
            {
                months--;
            }

            return Math.Max(0, months);
        }
    }
}