namespace SleepSetubal.Models
{
    //Nivel 2
    public class Room
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Beds { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }

    }
}
