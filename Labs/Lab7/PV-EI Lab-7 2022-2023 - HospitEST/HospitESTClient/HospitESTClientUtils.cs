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
        //Desafio
        public static string DoctorList(this List<Doctor> doctors)
        {
            StringBuilder stb = new StringBuilder("{");
            string comma = "";
            foreach (Doctor doctor in doctors)
            {
                stb.Append(comma);
                stb.Append(doctor.Id);
                stb.Append("-");
                stb.Append(doctor.Name);
                stb.Append("-");
                stb.Append(doctor.Practice + "(" + doctor.PracticeYears + ")");
                comma = (comma == "") ? ", " : comma;
            }
            stb.Append("}");
            return stb.ToString();
        }

        public static string PatientList(this List<Patient> patients)
        {
            StringBuilder stb = new StringBuilder("{");
            string comma = "";
            foreach (Patient patient in patients)
            {
                stb.Append(comma);
                stb.Append(patient.Id);
                stb.Append("-");
                stb.Append(patient.Name);
                stb.Append("-");
                stb.Append(patient.Pathology);
                stb.Append("-");
                stb.Append(patient.DateOfBirth.Date.ToString());
                comma = (comma == "") ? ", " : comma;
            }
            stb.Append("}");
            return stb.ToString();
        }
    }
}
