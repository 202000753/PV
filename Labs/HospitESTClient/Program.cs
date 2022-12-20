using HospitEST.Models;
using HospitESTClient;
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

    /*
    implementar aqui os metodos assincronos: 
    - static async Task<Hospital> GetHospitalAsync(string path)
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

        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todos os hospitais");
            Console.WriteLine("[ 2 ] Consultar um hospital por id");
            Console.WriteLine("[ 3 ] Adicionar hospital");
            Console.WriteLine("[ 4 ] Alterar hospital");
            Console.WriteLine("[ 5 ] Apagar hospital");
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

                    /*  completar neste espaço  */

                    if (hospital != null)
                        Console.WriteLine("Hospital: {0}", hospital.Name);
                    break;
                case 3:
                    hospital = new Hospital();
                    Console.Write("Localização do hospital =");
                    hospital.Name = Console.ReadLine();

                    /*  completar neste espaço  */

                    // Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Localização antiga: ");
                    string newLocation = Console.ReadLine();
                    Console.Write("Localização nova  : ");
                    string oldLocation = Console.ReadLine();

                    /*     completar neste espaço   */


                    break;
                case 5:
                    Console.Write("Apagar hospital Id=");
                    id = Guid.Parse(Console.ReadLine());

                    /*     completar neste espaço   */

                    break;
                default:
                    break;
            }

        }
        while (option != 0);
    }
}