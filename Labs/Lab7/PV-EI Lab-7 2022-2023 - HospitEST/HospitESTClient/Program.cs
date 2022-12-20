using HospitEST.Models;
using HospitESTClient;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;

class Program
{
    static HttpClient client = new HttpClient();

    //Nivel 2
    static async Task<List<Hospital>> GetHospitalsAsync(string path)
    {
        List<Hospital> hospitals = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            hospitals = await response.Content.ReadAsAsync<List<Hospital>>();
        }

        return hospitals;
    }
    
    //Nivel 3
    static async Task<Hospital> GetHospitalAsync(string path)
    {
        Hospital hospital = null;
        HttpResponseMessage response = await client.GetAsync(path);

        if (response.IsSuccessStatusCode)
        {
            hospital = await response.Content.ReadAsAsync<Hospital>();
        }
        return hospital;
    }

    //Nivel 4
    static async Task<HttpStatusCode> CreateHospitalAsync(Hospital hospital)
    {

        HttpResponseMessage response = await client.PostAsJsonAsync("api/HospitalsApi",hospital);
        
        // return URI of the created resource.
        return response.StatusCode;
    }

    static async Task<HttpStatusCode> UpdateHospitalAsync(Hospital hospital)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(
            $"api/HospitalsApi/{hospital.Id}", hospital);

        return response.StatusCode;
    }

    static async Task<HttpStatusCode> DeleteHospitalAsync(Guid id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"api/HospitalsApi/{id}");
        return response.StatusCode;
    }

    
    public static void Main(string[] args)
    {
        // coloque o porto utilizado no seu projecto 
        // ver na barra de endereço do browser ou dentro de launchSettings.json
        client.BaseAddress = new Uri("https://localhost:7275/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        Hospital hospital;
        List<Hospital> hospitals;
        Guid id;
        int option;
        HttpStatusCode result;

        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todos os hospitais");
            Console.WriteLine("[ 2 ] Consultar um hospital por id");
            Console.WriteLine("[ 3 ] Adicionar hospital");
            Console.WriteLine("[ 4 ] Alterar o nome do hospital");
            Console.WriteLine("[ 5 ] Apagar hospital");
            Console.WriteLine("[ 6 ] Consultar Médicos de um Hospital");
            Console.WriteLine("[ 0 ] Sair do Programa");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    hospitals = GetHospitalsAsync($"api/HospitalsApi").GetAwaiter().GetResult();
                    if (hospitals != null)
                        Console.WriteLine("Hospitais: {0}", hospitals.HospitalList());
                    break;
                case 2:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    hospital = GetHospitalAsync($"api/HospitalsApi/"+id).GetAwaiter().GetResult();

                    if (hospital != null)
                        Console.WriteLine("Hospital: {0}", hospital.Name);
                    break;
                case 3:
                    hospital = new Hospital();
                    hospital.Id = Guid.NewGuid();
                    Console.Write("Nome do hospital = ");
                    hospital.Name = Console.ReadLine();

                    Console.Write("Localização do hospital = ");
                    hospital.Localization = Console.ReadLine();

                    result = CreateHospitalAsync(hospital).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Nome antigo: ");
                    string oldName = Console.ReadLine();
                    Console.Write("Nome novo  : ");
                    string newName = Console.ReadLine();

                    hospitals = GetHospitalsAsync($"api/HospitalsApi").GetAwaiter().GetResult();
                    hospital = hospitals.FirstOrDefault(m => m.Name.Contains(oldName));
                    if (hospital != null)
                    {
                        hospital.Name = newName;
                        result = UpdateHospitalAsync(hospital).GetAwaiter().GetResult();
                        Console.WriteLine("status: {0}", result);
                    }
                    else
                        Console.WriteLine("O hospital {0} não existe", oldName);


                    break;
                case 5:
                    Console.Write("Apagar hospital Id=");
                    id = Guid.Parse(Console.ReadLine());
                    
                    result = DeleteHospitalAsync(id).GetAwaiter().GetResult();
                    Console.WriteLine("status: {0}", result);

                    break;
                //Nivel 5
                case 6:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    hospital = GetHospitalAsync($"api/HospitalsApi/HospitalDoctors/{id}").GetAwaiter().GetResult();

                    if (hospital != null)
                    {
                        Console.WriteLine($"Hospital: {hospital.Id} - {hospital.Name}");
                        if (hospital.Doctors != null)
                        {
                            foreach (var doctor in hospital.Doctors)
                            {
                                Console.WriteLine($"\t{doctor.Name} ({doctor.Practice})");
                            }
                        }
                    }

                    break;
                default:
                    break;
            }

        }
        while (option != 0);
    }


    // Desafio
    /*
    #region Doctor CRUD
    static async Task<List<Doctor>> GetDoctorsAsync(string path)
    {
        List<Doctor> doctors = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            doctors = await response.Content.ReadAsAsync<List<Doctor>>();
        }

        return doctors;
    }

    static async Task<Doctor> GetDoctorAsync(string path)
    {
        Doctor doctor = null;
        HttpResponseMessage response = await client.GetAsync(path);

        if (response.IsSuccessStatusCode)
        {
            doctor = await response.Content.ReadAsAsync<Doctor>();
        }
        return doctor;
    }

    static async Task<HttpStatusCode> CreateDoctorAsync(Doctor doctor)
    {

        HttpResponseMessage response = await client.PostAsJsonAsync("api/DoctorsApi", doctor);

        // return URI of the created resource.
        return response.StatusCode;
    }

    static async Task<HttpStatusCode> UpdateDoctorAsync(Doctor doctor)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(
            $"api/DoctorsApi/{doctor.Id}", doctor);

        return response.StatusCode;
    }

    static async Task<HttpStatusCode> DeleteDoctorAsync(Guid id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"api/DoctorsApi/{id}");
        return response.StatusCode;
    }
    #endregion
    //Patients
    #region Patients CRUD
    static async Task<List<Patient>> GetPatientsAsync(string path)
    {
        List<Patient> patients = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            patients = await response.Content.ReadAsAsync<List<Patient>>();
        }

        return patients;
    }

    static async Task<Patient> GetPatientAsync(string path)
    {
        Patient patient = null;
        HttpResponseMessage response = await client.GetAsync(path);

        if (response.IsSuccessStatusCode)
        {
            patient = await response.Content.ReadAsAsync<Patient>();
        }
        return patient;
    }

    static async Task<HttpStatusCode> CreatePatientAsync(Patient patient)
    {

        HttpResponseMessage response = await client.PostAsJsonAsync("api/PatientsApi", patient);

        // return URI of the created resource.
        return response.StatusCode;
    }

    static async Task<HttpStatusCode> UpdatePatientAsync(Patient patient)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(
            $"api/PatientsApi/{patient.Id}", patient);

        return response.StatusCode;
    }

    static async Task<HttpStatusCode> DeletePatientAsync(Guid id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"api/PatientssApi/{id}");
        return response.StatusCode;
    }
    #endregion

    #region Menus
    public static void MainMenu()
    {
        int option;
        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Gerir hospitais");
            Console.WriteLine("[ 2 ] Gerir médicos");
            Console.WriteLine("[ 3 ] Gerir pacientes");
            Console.WriteLine("[ 0 ] Sair do Programa");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    HospitalMenu();
                    break;
                case 2:
                    DoctorMenu();
                    break;
                case 3:
                    PatientMenu();
                    break;
                default:
                    break;
            }
        }
        while (option != 0);
    }
    public static void HospitalMenu()
    {

        Hospital hospital;
        List<Hospital> hospitals;
        Guid id;
        int option;
        HttpStatusCode result;

        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todos os hospitais");
            Console.WriteLine("[ 2 ] Consultar um hospital por id");
            Console.WriteLine("[ 3 ] Adicionar hospital");
            Console.WriteLine("[ 4 ] Alterar o nome do hospital");
            Console.WriteLine("[ 5 ] Apagar hospital");
            Console.WriteLine("[ 6 ] Consultar Médicos de um Hospital");
            Console.WriteLine("[ 0 ] Voltar ao menu inicial");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    hospitals = GetHospitalsAsync($"api/HospitalsApi").GetAwaiter().GetResult();
                    if (hospitals != null)
                        Console.WriteLine("Hospitais: {0}", hospitals.HospitalList());
                    break;
                case 2:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    hospital = GetHospitalAsync($"api/HospitalsApi/" + id).GetAwaiter().GetResult();

                    if (hospital != null)
                        Console.WriteLine("Hospital: {0}", hospital.Name);
                    break;
                case 3:
                    hospital = new Hospital();
                    hospital.Id = Guid.NewGuid();
                    Console.Write("Nome do hospital = ");
                    hospital.Name = Console.ReadLine();

                    Console.Write("Localização do hospital = ");
                    hospital.Localization = Console.ReadLine();

                    result = CreateHospitalAsync(hospital).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Nome antigo: ");
                    string oldName = Console.ReadLine();
                    Console.Write("Nome novo  : ");
                    string newName = Console.ReadLine();

                    hospitals = GetHospitalsAsync($"api/HospitalsApi").GetAwaiter().GetResult();
                    hospital = hospitals.FirstOrDefault(m => m.Name.Contains(oldName));
                    if (hospital != null)
                    {
                        hospital.Name = newName;
                        result = UpdateHospitalAsync(hospital).GetAwaiter().GetResult();
                        Console.WriteLine("status: {0}", result);
                    }
                    else
                        Console.WriteLine("O hospital {0} não existe", oldName);


                    break;
                case 5:
                    Console.Write("Apagar hospital Id=");
                    id = Guid.Parse(Console.ReadLine());

                    result = DeleteHospitalAsync(id).GetAwaiter().GetResult();
                    Console.WriteLine("status: {0}", result);

                    break;
                //Nivel 5
                case 6:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    hospital = GetHospitalAsync($"api/HospitalsApi/HospitalDoctors/{id}").GetAwaiter().GetResult();

                    if (hospital != null)
                    {
                        Console.WriteLine($"Hospital: {hospital.Id} - {hospital.Name}");
                        if (hospital.Doctors != null)
                        {
                            foreach (var doctor in hospital.Doctors)
                            {
                                Console.WriteLine($"\t{doctor.Name} ({doctor.Practice})");
                            }
                        }
                    }

                    break;
                default:
                    break;
            }
        } while (option != 0);
    }

    public static void DoctorMenu()
    {

        Doctor doctor;
        List<Doctor> doctors;
        Guid id;
        int option;
        HttpStatusCode result;

        do
        {

            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todos os médicos");
            Console.WriteLine("[ 2 ] Consultar um médico por id");
            Console.WriteLine("[ 3 ] Adicionar médico");
            Console.WriteLine("[ 4 ] Alterar dados de um médico");
            Console.WriteLine("[ 5 ] Apagar médico");
            Console.WriteLine("[ 0 ] Voltar ao menu inicial");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    doctors = GetDoctorsAsync($"api/DoctorsApi").GetAwaiter().GetResult();
                    if (doctors != null)
                        Console.WriteLine("Médicos: {0}", doctors.DoctorList());
                    break;
                case 2:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    doctor = GetDoctorAsync($"api/DoctorsApi/" + id).GetAwaiter().GetResult();

                    if (doctor != null)
                        Console.WriteLine("Médico: {0} - {1}({2})", doctor.Name, doctor.Practice, doctor.PracticeYears);
                    break;
                case 3:
                    doctor = new Doctor();
                    doctor.Id = Guid.NewGuid();
                    Console.Write("Nome do médico = ");
                    doctor.Name = Console.ReadLine();

                    Console.Write("Área do médico = ");
                    doctor.Practice = Console.ReadLine();

                    Console.Write("Anos de prática = ");
                    doctor.PracticeYears = Int32.Parse(Console.ReadLine());

                    Console.Write("Id do hospital associado = ");
                    doctor.HospitalId = Guid.Parse(Console.ReadLine());

                    result = CreateDoctorAsync(doctor).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Id do médico = ");
                    id = Guid.Parse(Console.ReadLine());

                    Console.Write("Nome novo  : ");
                    string newName = Console.ReadLine();

                    Console.Write("Nova área de prática: ");
                    string practice = Console.ReadLine();

                    Console.Write("anos de prática: ");
                    int years = Int32.Parse(Console.ReadLine());


                    doctors = GetDoctorsAsync($"api/DoctorsApi").GetAwaiter().GetResult();
                    doctor = doctors.FirstOrDefault(d => Guid.Equals(d.Id, id));
                    if (doctor != null)
                    {
                        doctor.Name = newName;
                        doctor.Practice = practice;
                        doctor.PracticeYears = years;
                        result = UpdateDoctorAsync(doctor).GetAwaiter().GetResult();
                        Console.WriteLine("status: {0}", result);
                    }
                    else
                        Console.WriteLine("O médico com o id {0} não existe", id);


                    break;
                case 5:
                    Console.Write("Apagar médico Id=");
                    id = Guid.Parse(Console.ReadLine());

                    result = DeleteDoctorAsync(id).GetAwaiter().GetResult();
                    Console.WriteLine("status: {0}", result);

                    break;
                default:
                    break;
            }
        } while (option != 0);
    }

    public static void PatientMenu()
    {

        Patient patient;
        List<Patient> patients;
        Guid id;
        int option;
        HttpStatusCode result;

        do
        {

            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todos os pacientes");
            Console.WriteLine("[ 2 ] Consultar um paciente por id");
            Console.WriteLine("[ 3 ] Adicionar paciente");
            Console.WriteLine("[ 4 ] Alterar dados de um paciente");
            Console.WriteLine("[ 5 ] Apagar paciente");
            Console.WriteLine("[ 0 ] Voltar ao menu inicial");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    patients = GetPatientsAsync($"api/PatientsApi").GetAwaiter().GetResult();
                    if (patients != null)
                        Console.WriteLine("Pacientes: {0}", patients.PatientList());
                    break;
                case 2:
                    Console.Write("Id=");
                    id = Guid.Parse(Console.ReadLine());

                    patient = GetPatientAsync($"api/PatientsApi/" + id).GetAwaiter().GetResult();

                    if (patient != null)
                        Console.WriteLine("Hospital: {0}", patient.Name);
                    break;
                case 3:
                    patient = new Patient();
                    patient.Id = Guid.NewGuid();
                    Console.Write("Nome do paciente = ");
                    patient.Name = Console.ReadLine();

                    Console.Write("Data de nascimento(dd/mm/aaaa) = ");
                    patient.DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/mm/aaaa", CultureInfo.InvariantCulture);

                    Console.Write("Id do médico associado = ");
                    patient.DoctorId = Guid.Parse(Console.ReadLine());

                    result = CreatePatientAsync(patient).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Id do paciente: ");
                    id = Guid.Parse(Console.ReadLine());

                    Console.Write("Nome novo  : ");
                    string newName = Console.ReadLine();

                    Console.Write("Novo id médico associado: ");
                    Guid doctorId = Guid.Parse(Console.ReadLine());

                    Console.Write("Patologia: ");
                    string pathology = Console.ReadLine();


                    patients = GetPatientsAsync($"api/PatientsApi").GetAwaiter().GetResult();
                    patient = patients.FirstOrDefault(p => Guid.Equals(p.Id, id));
                    if (patient != null)
                    {
                        patient.Name = newName;
                        patient.DoctorId = doctorId;
                        patient.Pathology = pathology;
                        result = UpdatePatientAsync(patient).GetAwaiter().GetResult();
                        Console.WriteLine("status: {0}", result);
                    }
                    else
                        Console.WriteLine("O paciente com Id {0} não existe", id);


                    break;
                case 5:
                    Console.Write("Apagar paciente Id=");
                    id = Guid.Parse(Console.ReadLine());

                    result = DeletePatientAsync(id).GetAwaiter().GetResult();
                    Console.WriteLine("status: {0}", result);

                    break;
                default:
                    break;
            }
        } while (option != 0);
    }
    #endregion

    public static void Main(string[] args)
    {
        // coloque o porto utilizado no seu projecto 
        // ver na barra de endereço do browser ou dentro de launchSettings.json
        client.BaseAddress = new Uri("https://localhost:7275/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        MainMenu();
    }*/
}