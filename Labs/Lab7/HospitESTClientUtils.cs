using HospitEST.Models;
using System.Text;


namespace HospitESTClient
{
    public static class HospitESTClientUtils
    {

        public static string HospitalList(this List<Hospital> hospitals)
        {
            StringBuilder stb = new StringBuilder("{");
            string comma = "";
            foreach (Hospital hospital in hospitals)
            {
                stb.Append(comma);
                stb.Append(hospital.Id);
                stb.Append("-");
                stb.Append(hospital.Name);
                stb.Append("-");
                stb.Append(hospital.Localization);
                comma = (comma == "") ? ", " : comma;
            }
            stb.Append("}");
            return stb.ToString();
        }
    }
}
