namespace Zoologico.Area
{
    internal class Enclosure
    {
        public Enclosure(string name, int capacity, string v)
        {
            Name = name;
            Capacity = capacity;
            V = v;
        }

        public string Name { get; }
        public int Capacity { get; }
        public string V { get; }
    }
}