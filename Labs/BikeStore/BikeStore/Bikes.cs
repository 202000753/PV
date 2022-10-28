using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public static class Bikes
    {
        public static List<Bike> Get()
        {
            string bikesJson = File.ReadAllText(@"..\..\..\bikes.json");

            return JsonConvert.DeserializeObject<List<Bike>>(bikesJson);
        }
    }
}
