using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ESTeSoccer.Data;
using ESTeSoccerClient;
using ESTeSoccerMVC.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ESTeSoccerTest
{
    // Desafio
    public class ApiTest
    {

        public ApiTest()
        {
            ESTeSoccerClientUtils.SetClient();
        }

        [Fact]
        public void GetLeagues_ReturnLeaguesList()
        {
            var apiResult = ESTeSoccerClientUtils.GetLeaguesAsync($"api/LeaguesApi").GetAwaiter().GetResult();

            var viewResult = Assert.IsType<List<League>>(apiResult);

            Assert.Equal(2, viewResult.Count());

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void GetLeague_ReturnLeague()
        {
            var apiResult = ESTeSoccerClientUtils.GetLeagueAsync($"api/LeaguesApi/{1}").GetAwaiter().GetResult();

            var viewResult = Assert.IsType<League>(apiResult);

            Assert.Equal(1, viewResult.LeagueId);

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void GetLeague_ReturnLeague_WhenLeagueIdDoesntExist()
        {
            var apiResult = ESTeSoccerClientUtils.GetLeagueAsync($"api/LeaguesApi/{0}").GetAwaiter().GetResult();

            Assert.Null(apiResult);

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void GetTeamsInLeague_ReturnTeamsList()
        {
            var apiResult = ESTeSoccerClientUtils.GetLeagueAsync($"api/LeaguesApi/LeagueAndTeams/{1}").GetAwaiter().GetResult();

            var viewResult = Assert.IsType<League>(apiResult);

            Assert.Equal(3, viewResult.Teams.Count());

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void GetTeamsInLeague_ReturnTeamsList_WhenLeagueIdDoesntExist()
        {
            var apiResult = ESTeSoccerClientUtils.GetLeagueAsync($"api/LeaguesApi/LeagueAndTeams/{0}").GetAwaiter().GetResult();

            Assert.Null(apiResult);

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void PostLeague_ReturnHttpStatusCode()
        {
            var league = new League { Name = "Liga SABSEG", Country = "Portugal" };
            var apiResult = ESTeSoccerClientUtils.CreateLeagueAsync(league).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);

            Assert.Equal(HttpStatusCode.Created, viewResult);

            //Clean up
            var leagues = ESTeSoccerClientUtils.GetLeaguesAsync($"api/LeaguesApi").GetAwaiter().GetResult();
            var leagueDelete = leagues.Where(l => l.Name == league.Name).FirstOrDefault();
            var clean = ESTeSoccerClientUtils.DeleteLeagueAsync(leagueDelete.LeagueId).GetAwaiter().GetResult();

            ESTeSoccerClientUtils.Dispose();
        }
        
        [Fact]
        public void PostLeague_ReturnHttpStatusCode_WhenLeagueHasId()
        {
            var league = new League { LeagueId = 1, Name = "Liga SABSEG", Country = "Portugal" };
            var apiResult = ESTeSoccerClientUtils.CreateLeagueAsync(league).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);

            Assert.Equal(HttpStatusCode.InternalServerError, viewResult);

            ESTeSoccerClientUtils.Dispose();
        }
        
        [Fact]
        public void PutLeagues_ReturnHttpStatusCode()
        {
            var league = new League { Name = "Liga SABSEG", Country = "Portugal" };
            var apiAdded = ESTeSoccerClientUtils.CreateLeagueAsync(league).GetAwaiter().GetResult();

            var leagues = ESTeSoccerClientUtils.GetLeaguesAsync($"api/LeaguesApi").GetAwaiter().GetResult();
            var leagueUpdate = leagues.Where(l => l.Name == league.Name).FirstOrDefault();
            leagueUpdate.Name = "Segunda Liga";
            var apiResult = ESTeSoccerClientUtils.UpdateLeagueAsync(leagueUpdate).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);
            Assert.Equal(HttpStatusCode.NoContent, viewResult);

            //Clean up
            var clean = ESTeSoccerClientUtils.DeleteLeagueAsync(leagueUpdate.LeagueId).GetAwaiter().GetResult();

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void PutLeagues_ReturnHttpStatusCode_WhenLeagueDoesntExist()
        {
            var league = new League { LeagueId = 3, Name = "Liga SABSEG", Country = "Portugal" };
            var apiResult = ESTeSoccerClientUtils.UpdateLeagueAsync(league).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);
            Assert.Equal(HttpStatusCode.NotFound, viewResult);

            ESTeSoccerClientUtils.Dispose();

        }
        
        [Fact]
        public void DeleteLeagues_ReturnHttpStatusCode()
        {
            var league = new League { Name = "Liga SABSEG", Country = "Portugal" };
            var apiAdded = ESTeSoccerClientUtils.CreateLeagueAsync(league).GetAwaiter().GetResult();

            var leagues = ESTeSoccerClientUtils.GetLeaguesAsync($"api/LeaguesApi").GetAwaiter().GetResult();
            var leagueDelete = leagues.Where(l => l.Name == league.Name).FirstOrDefault();
            var apiResult = ESTeSoccerClientUtils.DeleteLeagueAsync(leagueDelete.LeagueId).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);
            Assert.Equal(HttpStatusCode.NoContent, viewResult);

            ESTeSoccerClientUtils.Dispose();
        }

        [Fact]
        public void DeleteLeagues_ReturnHttpStatusCode_WhenIdDoesntExist()
        {
            var apiResult = ESTeSoccerClientUtils.DeleteLeagueAsync(0).GetAwaiter().GetResult();

            var viewResult = Assert.IsType<HttpStatusCode>(apiResult);
            Assert.Equal(HttpStatusCode.NotFound, viewResult);

            ESTeSoccerClientUtils.Dispose();
        }
    }
}
