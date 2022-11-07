// See https://aka.ms/new-console-template for more information

using BikeStore;

List<Bike> bikes = Bikes.Get();

Console.WriteLine("Lista de bicicletas: \n");
foreach (Bike bike in bikes)
{
    Console.WriteLine(bike);
}
Console.ReadKey();

// Testes LINQ

//Nivel 1:
Console.Clear();
Console.WriteLine("\n NIVEL 1 ------- Lista de bicicletas do ano 2016");
var bikes2016 = from bike in bikes where bike.ModelYear == 2016 orderby bike.Brand select bike;

foreach (var bike in bikes2016)
{
    Console.WriteLine(bike);
}

Console.WriteLine("\n NIVEL 1 ------- Bicicletas para raparigas");
var bikes4Girls = from bike in bikes where bike.Name.ToLower().ContainsAny("girl", "women", "ladies") select bike;
foreach (var bike in bikes4Girls)
{
    Console.WriteLine(bike);
}

Console.WriteLine("\n NIVEL 1 ------- Bicicletas da Electra para raparigas");
var electraBikes4Girls = from bike in bikes4Girls
                         where bike.Brand == "Electra"
                         orderby bike.Name
                         select bike.Name;

foreach (var bike in electraBikes4Girls)
{
    Console.WriteLine(bike);
}

Console.ReadKey();

//Nivel 2:
Console.Clear();
Console.WriteLine("\n NIVEL 2 ------- Bicicletas Trek de montanha lançadas depois de 2018 ");
var trekMountainBikesAfter2018 = from bike in bikes
                                 where bike.Brand == "Trek" && bike.Category == "Mountain Bikes" && bike.ModelYear >= 2018
                                 orderby bike.ModelYear descending
                                 select bike;

foreach (var bike in trekMountainBikesAfter2018)
{
    Console.WriteLine("> " + bike);
}

//airports.Add(new Airport
//{
//    AirportId = 46,
//    AirportICAO = "EGCC",
//    Country = "United Kingdom",
//    City = "MANCHESTER",
//    IsSchengen = false,
//    DailyFlightAverage = 20000
//});

bikes.Add(new Bike
{
    BikeId = 400,
    Name = "Fuel Exe 9.9 XX1 AXS",
    Brand = "Trek",
    ModelYear = 2023,
    Category = "Mountain Bikes",
    Price = 15_599.0m
});

bikes.Add(new Bike
{
    BikeId = 401,
    Name = "Supercaliber 9.9 XX1 AXS",
    Brand = "Trek",
    ModelYear = 2023,
    Category = "Mountain Bikes",
    Price = 12_999.0m
});

Console.WriteLine("\n NIVEL 2 ------- Bicicletas Trek de montanha lançadas depois de 2018 (repetição)");
foreach (var bike in trekMountainBikesAfter2018)
{
    Console.WriteLine("> " + bike);
}

Console.WriteLine("\n NIVEL 2 ------- Bicicleta mais barata");
decimal cheapestBikePrice = (from bike in bikes select bike.Price).Min();
Bike cheapestBike = (from bike in bikes where bike.Price == cheapestBikePrice select bike).FirstOrDefault();

Console.WriteLine($"> {cheapestBike}");

Console.ReadKey();


// Nivel 3
Console.Clear();
Console.WriteLine("\n NIVEL 3 ------- Média dos preços das bicicletas por marca");
var bikesByBrand = (from bike in bikes group bike by bike.Brand);

var bikeAveragePriceByBrand = (from value in bikesByBrand
                               select new
                               {
                                   Brand = value.Key,
                                   AveragePrive = value.Average(b => b.Price)
                               });



foreach (var bike in bikeAveragePriceByBrand)
{
    Console.WriteLine($"{bike.Brand} - Average Price: {bike.AveragePrive:0.00}");
}

Console.WriteLine("\n NIVEL 3 ------- Marca com o preço médio das biciletas mais alto");
var brandsPriceAverage = from bike in bikeAveragePriceByBrand select bike.AveragePrive;
var maxPriceAverage = from bike in bikeAveragePriceByBrand where bike.AveragePrive == brandsPriceAverage.Max() select bike;

var mostExpensiveBrand = maxPriceAverage.FirstOrDefault();
Console.WriteLine($"{mostExpensiveBrand.Brand} - Average Price: {mostExpensiveBrand.AveragePrive:0.00}");

Console.WriteLine("\n NIVEL 3 ------- Marca com o preço médio das biciletas mais baixo");
var minPriceAverage = from bike in bikeAveragePriceByBrand where bike.AveragePrive == brandsPriceAverage.Min() select bike;

var cheapestBrand = minPriceAverage.FirstOrDefault();
Console.WriteLine($"{cheapestBrand.Brand} - Average Price: {cheapestBrand.AveragePrive:0.00}");

Console.ReadKey();

//Nivel 4
Console.Clear();
Console.WriteLine("\n NIVEL 4 ------- Bicicletas ordenadas pelo preço");
List<Bike> bikesByPrice = bikes.OrderBy(bike => bike.Price).ToList();
foreach (var bike in bikesByPrice)
{
    Console.WriteLine(bike);
}

Console.ReadKey();
Console.Clear();

Console.WriteLine("\n NIVEL 4 ------- Categorias de bicicletas");
List<string> categories = bikes.Select(bike => bike.Category).Distinct().ToList();

foreach (var category in categories)
{
    Console.WriteLine("> " + category);
}

Console.WriteLine("\n NIVEL 4 ------- Bicicletas de 2017");
bool bikesFrom2017lessThan1000 = bikes.Any(bike => bike.Price < 5000);
Console.WriteLine((bikesFrom2017lessThan1000 ? "E" : "Não e") + "xistem bicicletas de 2017 com um preço inferior a 1000");

Console.WriteLine("\n NIVEL 4 ------- Preço médio de uma bicicleta");
var averageBikePrice = bikes.Average(bike => bike.Price);
Console.WriteLine($"{averageBikePrice:0.00}");

Console.ReadKey();

// Nivel 5
Console.Clear();

Console.WriteLine("\n NIVEL 5 ------- Biciletas mais baratas da Electra (1º a 5º)");
List<Bike> cheaperElectraBikesFirstFive = bikes
     .Where(bike => bike.Brand == "Electra")
     .OrderBy(bike => bike.Price)
     .Take(5)
     .ToList();
foreach (var bike in cheaperElectraBikesFirstFive)
{
    Console.WriteLine("> " + bike);
}


Console.WriteLine("\n NIVEL 5 ------- Biciletas mais baratas da Electra (6º a 10º)");
List<Bike> cheaperElectraBikesSecondFive = bikes
     .Where(bike => bike.Brand == "Electra")
     .OrderBy(bike => bike.Price)
     .Skip(5)
     .Take(5)
     .ToList();
foreach (var product in cheaperElectraBikesSecondFive)
{
    Console.WriteLine("> " + product);
}

Console.WriteLine("\n NIVEL 5 ------- Lista de bicicletas de crianças de 2017 ordenadas pela marca e depois pelo preço");
List<Bike> children2017BikesOrderedByBrandThenByPrice = bikes
    .Where(bike => bike.Category == "Children Bicycles" && bike.ModelYear == 2017)
    .OrderBy(bike => bike.Brand)
    .ThenBy(bike => bike.Price)
    .ToList();

foreach (var bike in children2017BikesOrderedByBrandThenByPrice)
    Console.WriteLine("> " + bike);

Console.ReadKey();

Console.Clear();
Console.WriteLine("\n Desafio ------- Bicicletas de 2018 agrupadas por Categoria");
var bikesFrom2018groupedByCategory = bikes.Where(bike => bike.ModelYear == 2018).GroupBy(bike => bike.Category);
foreach (var category in bikesFrom2018groupedByCategory)
{
    Console.WriteLine(category.Key);
    foreach (var bike in category)
    {
        Console.WriteLine($"\t{bike.BikeId:00} - {bike.Name} \t {bike.Brand} \t {bike.Price}");
    }
}

Console.ReadLine();