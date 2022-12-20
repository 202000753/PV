using HospitEST.Models;
using HospitESTClient;
using System.Net;
using System.Net.Http.Headers;

class Program
{
    static HttpClient client = new HttpClient();

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

    static async Task<HttpStatusCode> CreateHospitalAsync(Hospital hospital)
    {
        HttpResponseMessage statusCode = await client.PostAsJsonAsync($"api/HospitalsApi", hospital);
        return statusCode.StatusCode;
    }

    static async Task<HttpStatusCode> UpdateHospitalAsync(Hospital hospital)
    {
        HttpResponseMessage statusCode = await client.PutAsJsonAsync($"api/HospitalsApi/{hospital.Id}", hospital);
        return statusCode.StatusCode;
    }

    static async Task<HttpStatusCode> DeleteHospitalAsync(Guid id)
    {
        HttpResponseMessage statusCode = await client.DeleteAsync($"api/HospitalsApi/{id}");
        return statusCode.StatusCode;
    }


    /*CreateHospitalAsync, UpdateHospitalAsync e DeleteHospitalAsync
    implementar aqui os metodos assincronos: 
    - static async Task<HttpStatusCode> CreateHospitalAsync(Hospital hospital)
    - static async Task<HttpStatusCode> UpdateHospitalAsync(Hospital hospital)
    - static async Task<HttpStatusCode> DeleteHospitalAsync(int id)
    */

    public static void Main(string[] args)
    {
        // coloque o porto utilizado no seu projecto 
        // ver na barra de endereço do browser ou dentro de launchSettings.json
        client.BaseAddress = new Uri("https://localhost:7275/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        Hospital hospital = null;
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
            Console.WriteLine("[ 4 ] Alterar hospital");
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
                    Console.Write("Id = ");
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
                    Console.Write("Nome novo: ");
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
                    Console.Write("Apagar hospital Id = ");
                    id = Guid.Parse(Console.ReadLine());

                    result = DeleteHospitalAsync(id).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 6:
                    Console.Write("Id = ");
                    id = Guid.Parse(Console.ReadLine());

                    hospital = GetHospitalAsync($"api/HospitalsApi/HospitalDoctors/{id}").GetAwaiter().GetResult();

                    if(hospital != null)
                    {
                        Console.WriteLine($"Hospital: {hospital.Id} - {hospital.Name}");

                        if(hospital.Doctors != null)
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
}