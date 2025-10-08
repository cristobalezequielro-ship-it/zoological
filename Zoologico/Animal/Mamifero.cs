
namespace Zoologico.Animal
{
    public abstract class Mamifero : Vertebrado
    {
        public bool HasFur { get; set; }
        public int GestationPeriodDays { get; set; }
        public Mamifero(string species, string name, int age, string enclosure, bool hasFur, int gestationDays)
            : base(species, name, age, enclosure)
        {
            this.Diet = DietType.Undefined;
            this.HasFur = hasFur;
            this.GestationPeriodDays = gestationDays;
        }
        public virtual void NurseYoung()
        {
            Console.WriteLine($"{this.Name} está amamantando a sus crías.");
        }
        public virtual void RegulateTemperature()
        {
            Console.WriteLine($"{this.Name} está regulando su temperatura corporal (homeotermia).");
        }
    }
}