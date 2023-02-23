namespace ESTGym.Services
{
    public class LongToday : IToday
    {
        public string Time => DateTime.Now.ToLongTimeString();

        public string Date => DateTime.Now.ToLongDateString();
    }
}
