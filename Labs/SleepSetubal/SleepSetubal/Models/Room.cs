namespace SleepSetubal.Models
{
    public class Room
    {
        public string name { get; set; }

        public string type { get; set; }

        public List<string> beds { get; set; }

        public int price { get; set; }

        public bool available { get; set; }

        public Room()
        {

        }

        public override string ToString()
        {
            string str = "";

            str += "Name:  " + name + "- Type: " + type + "- Beds: ";

            foreach (var bed in beds)
                str += ", " + bed;

            str += "- Price: " + price + "- Available: ";

            if (available)
                str += "yes";
            else
                str += "no";

            return str;
        }
    }
}
