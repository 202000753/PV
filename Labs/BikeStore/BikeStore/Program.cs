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