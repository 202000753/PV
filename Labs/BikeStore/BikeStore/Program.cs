// See https://aka.ms/new-console-template for more information

using BikeStore;
using System.Linq;
using System.Security.Cryptography;

List<Bike> bikes = Bikes.Get();

/*
Console.WriteLine("Lista de bicicletas: \n");
foreach (Bike bike in bikes)
{
    Console.WriteLine(bike);
}
//Console.ReadKey();
Console.WriteLine("\n\n");
*/

// Testes LINQ
//Nivel 1
Console.WriteLine("--------------------------------NIVEL 1--------------------------------");
Console.WriteLine("Lista de bicicletas produzidas no ano 2016 por ordem alfabética do seu nome:");
var bpa = from b in bikes where b.ModelYear == 2016 orderby b.Brand select b;
foreach (var b in bpa)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nLista de bicicletas que tenham uma das palavras Ladies, Girl ou Women no nome:");
var bc = from b in bikes where b.Name.Contains("Ladies") || b.Name.Contains("Girl") || b.Name.Contains("Women") select b;
foreach (var b in bc)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nLista de bicicletas para raparigas da marca Electra:");
var be = from b in bc where b.Brand.Contains("Electra") select b.Name;
foreach (var b in be)
    Console.WriteLine("> " + b);

//Nivel 2
Console.WriteLine("\n\n--------------------------------NIVEL 2--------------------------------");
Console.WriteLine("Lista de bicicletas de montanha que a marca Trek lançou depois de 2018:");
var bmt = from b in bikes where b.ModelYear >= 2018 && b.Brand == "Trek" && b.Category == "Mountain Bikes" orderby b.Brand select b;
foreach (var b in bmt)
    Console.WriteLine("> " + b);

bikes.Add(new Bike{ BikeId = 400, Name = "Fuel Exe 9.9 XX1 AXS", Brand = "Trek", ModelYear = 2023, Category = "Mountain Bikes", Price = 155599.0m});
bikes.Add(new Bike{ BikeId = 401, Name = "Supercaliber 9.9 XX1 AXS", Brand = "Trek", ModelYear = 2023, Category = "Mountain Bikes", Price = 129999});
Console.WriteLine("\n\nDepois da adição");
foreach (var b in bmt)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nLista de bicicletas de montanha que a marca Trek lançou depois de 2018:");

decimal cheapestBikePrice = (from bike in bikes select bike.Price).Min();
Bike cheapestBike = (from bike in bikes where bike.Price == cheapestBikePrice select bike).FirstOrDefault();
Console.WriteLine($"> {cheapestBike}");

//Nivel 3
Console.WriteLine("\n\n--------------------------------NIVEL 3--------------------------------");
var bikesByBrand = from bike in bikes group bike by bike.Brand;
var bikeAveragePriceByBrand = from v in bikesByBrand select new { Brand = v.Key, AveragePrive = v.Average(b => b.Price) }; 

foreach (var bike in bikeAveragePriceByBrand)
{
    Console.WriteLine($"{bike.Brand} - Average Price: {bike.AveragePrive:0.00}");
}

decimal maxPriceAverage = (from brand in bikeAveragePriceByBrand select brand.AveragePrive).Max();
decimal minPriceAverage = (from brand in bikeAveragePriceByBrand select brand.AveragePrive).Min();

var mostExpensiveBrand = (from brand in bikeAveragePriceByBrand where brand.AveragePrive == maxPriceAverage select brand).FirstOrDefault();
var leastExpensiveBrand = (from brand in bikeAveragePriceByBrand where brand.AveragePrive == minPriceAverage select brand).FirstOrDefault();

Console.WriteLine($"\n\n Most Expensive {mostExpensiveBrand.Brand} - Average Price: {mostExpensiveBrand.AveragePrive:0.00}");
Console.WriteLine($"Least Expensive {leastExpensiveBrand.Brand} - Average Price: {leastExpensiveBrand.AveragePrive:0.00}");


//Nivel 4
Console.WriteLine("\n\n--------------------------------NIVEL 4--------------------------------");
Console.WriteLine("\n\nLista de bicicletas ordenadas pelo preço:");
var bpp = (from b in bikes select b).OrderBy(b => b.Price);
foreach (var b in bpp)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nLista de categorias sem repetição");
var categories = (from bike in bikes select bike.Category).Distinct();
foreach (var b in categories)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nLista de bicicletas de 2017 com um preço inferior a 1000:");
var bikespi = (from b in bikes select b).Any(b => b.ModelYear == 2017 && b.Price < 1000);
if (bikespi)
    Console.WriteLine("Exists");
else
    Console.WriteLine("Dosen't exists");

Console.WriteLine("\n\nA média de preço de todas as bicicletas: ");
var averageBikesPrice = bikes.Average(bike => bike.Price);
Console.WriteLine($"{averageBikesPrice:0.00}");

//Nivel 5
Console.WriteLine("\n\n--------------------------------NIVEL 5--------------------------------");
Console.WriteLine("\n\nAs 5 bicicletas mais baratas da Electra ordenadas pelo preço:");
var cheaperElectraBikesFirstFive = bikes.Where(bike => bike.Brand == "Electra").OrderBy(bike => bike.Price).Take(5).ToList();
foreach (var b in cheaperElectraBikesFirstFive)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nOs 5 primeiros aeroportos que aparecem a seguir aos do ponto anterior:");
var cheaperElectraBikesSecondFive = bikes.Where(bike => bike.Brand == "Electra").OrderBy(bike => bike.Price).Take(5).Skip(5).ToList();
foreach (var b in cheaperElectraBikesSecondFive)
    Console.WriteLine("> " + b);

Console.WriteLine("\n\nA lista de bicicletas de crianças de 2017 ordenadas pela marca e depois pelo preço:");
var children2017BikesOrderedByBrandThenByPrice = bikes.Where(bike => bike.Category == "Children Bicycles" && bike.ModelYear == 2017).OrderBy(bike => bike.Brand).ThenBy(bike => bike.Price).ToList();
foreach (var b in children2017BikesOrderedByBrandThenByPrice)
    Console.WriteLine("> " + b);