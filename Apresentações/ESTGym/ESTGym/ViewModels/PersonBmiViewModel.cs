namespace ESTGym.ViewModels
{
    public class PersonBmiViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi => Weight / ((Height/100) * (Height / 100));
    }
}
