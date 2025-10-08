namespace Zoologico.Animal
{
    public interface ITerrestrial
    {
        void Run();
        void Walk();
        int NumberOfLegs { get; }
    }
} 