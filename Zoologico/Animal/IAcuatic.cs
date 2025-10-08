using Zoologico.Area;

public interface IAcuatic
{
    SalinityLevel WaterType { get; set; }
    void Swim();
}