using Zoologico.Area;
namespace Zoologico.Animal
{
    public interface IAcuatic
    {
        SalinityLevel SalinityPreference { get; }

        void Swim();
    }
}