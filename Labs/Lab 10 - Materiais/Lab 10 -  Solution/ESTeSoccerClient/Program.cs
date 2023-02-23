﻿using ESTeSoccerMVC.Models;
using System.Net;
using System.Net.Http.Headers;

namespace ESTeSoccerClient;
public class Program
{
    static readonly HttpClient client = new();
    private const string ApiUri = "api/LeaguesApi";

    static async Task<List<League>?> GetLeaguesAsync(string path)
    {
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<List<League>>();
        }
        return null;
    }

    static async Task<League?> GetLeagueAsync(string path)
    {
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<League>();
        }

        return null;
    }

    static async Task<HttpStatusCode> CreateLeagueAsync(League league)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            ApiUri, league);

        // return URI of the created resource.
        return response.StatusCode;
    }

    static async Task<HttpStatusCode> UpdateLeagueAsync(League league)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(
            $"{ApiUri}/{league.LeagueId}", league);

        return response.StatusCode;
    }

    static async Task<HttpStatusCode> DeleteLeagueAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync(
            $"{ApiUri}/{id}");
        return response.StatusCode;
    }


    /*
    implementar aqui os metodos assincronos: 
    - static async Task<League> GetLeagueAsync(string path)
    - static async Task<HttpStatusCode> CreateLeagueAsync(League League)
    - static async Task<HttpStatusCode> UpdateLeagueAsync(League League)
    - static async Task<HttpStatusCode> DeleteLeagueAsync(int id)
    */


    public static async Task Main(string[] args)
    {
        await Run();
    }

    private static async Task Run()
    {
        // coloque o porto utilizado no seu projecto 
        // ver na barra de endereço do browser ou dentro de launchSettings.json
        client.BaseAddress = new Uri("http://localhost:5041/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        League? league = null;
        List<League>? leagues;
        int id;
        int option;

        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1 ] Consultar todas as ligas");
            Console.WriteLine("[ 2 ] Consultar uma liga por id");
            Console.WriteLine("[ 3 ] Adicionar liga");
            Console.WriteLine("[ 4 ] Alterar liga");
            Console.WriteLine("[ 5 ] Apagar liga");
            Console.WriteLine("[ 6 ] Consultar clubes de uma liga");
            Console.WriteLine("[ 0 ] Sair do Programa");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            _ = int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    leagues = await GetLeaguesAsync(ApiUri);
                    if (leagues != null)
                        Console.WriteLine("Ligas: {0}", leagues.LeaguesList());
                    break;
                case 2:
                    Console.Write("Id=");
                    _ = int.TryParse(Console.ReadLine(), out id);

                    /*  completar neste espaço  */
                    // Nivel 3
                    league = await GetLeagueAsync($"{ApiUri}/{id}");

                    if (league != null)
                        Console.WriteLine("Liga: {0}", league.Name);
                    break;
                case 3:
                    league = new League();
                    Console.Write("Nome da liga=");
                    league.Name = ReadLineWithDefaultEmpty();
                    Console.Write("Nome do país=");
                    league.Country = ReadLineWithDefaultEmpty();
                    //league.Teams = new List<Team>();

                    /*  completar neste espaço  */
                    // Nivel 4
                    var result = CreateLeagueAsync(league).GetAwaiter().GetResult();

                    Console.WriteLine("status: {0}", result);
                    break;
                case 4:
                    Console.Write("Nome antigo: ");
                    string nomeAntigo = ReadLineWithDefaultEmpty();
                    Console.Write("Nome novo  : ");
                    string nomeNovo = ReadLineWithDefaultEmpty();

                    /*     completar neste espaço   */
                    // Nivel 4

                    leagues = await GetLeaguesAsync(ApiUri);
                    league = leagues.FirstOrDefault(m => m.Name.Contains(nomeAntigo));
                    if (league != null)
                    {
                        league.Name = nomeNovo;
                        league.Teams = new List<Team>();
                        var status2 = UpdateLeagueAsync(league).GetAwaiter().GetResult();
                        Console.WriteLine("status: {0}", status2);
                    }
                    else
                        Console.WriteLine("A liga {0} não existe", nomeAntigo);


                    break;

                case 5:
                    Console.Write("Apagar liga Id=");
                    _ = int.TryParse(Console.ReadLine(), out id);

                    /*     completar neste espaço   */
                    // Nivel 4
                    var status = DeleteLeagueAsync(id).GetAwaiter().GetResult();
                    Console.WriteLine("status: {0}", status);

                    break;

                // Nivel 5
                case 6:
                    Console.Write("Id=");
                    _ = int.TryParse(Console.ReadLine(), out id);

                    league = await GetLeagueAsync($"{ApiUri}/LeagueAndTeams/{id}");

                    if (league != null)
                    {
                        Console.WriteLine($"Liga: {league.LeagueId} - {league.Name}");
                        if (league.Teams != null)
                        {
                            foreach (var team in league.Teams)
                            {
                                Console.WriteLine($"\t{team.Name} ({team.Initials})");
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

    private static string ReadLineWithDefaultEmpty() => Console.ReadLine() ?? "";

}