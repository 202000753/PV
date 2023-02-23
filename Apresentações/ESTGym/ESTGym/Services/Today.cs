namespace ESTGym.Services
{
    public class Today : IToday
    {
        public string Time => DateTime.Now.ToShortTimeString();

        public string Date => DateTime.Now.ToShortDateString();

    }
}
