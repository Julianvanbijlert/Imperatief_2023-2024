using System;
using System.Text;

Console.Write("Wat is je naam? ");
string naam = Console.ReadLine();
string naamInHoofdletters = naam.ToUpper();
Console.WriteLine($"{naamInHoofdletters}!!!");

Console.Write("Wat is je geboortedag? ");
string ingetikteDag = Console.ReadLine();
int dag = int.Parse(ingetikteDag);
Console.Write("in welke maand? ");
int maand = int.Parse(Console.ReadLine());
Console.Write("in welk jaar? ");
int jaar = int.Parse(Console.ReadLine());

DateTime datum = new DateTime(jaar, maand, dag);
Console.WriteLine($"Dat was op een {datum.DayOfWeek}");
DateTime vandaag = DateTime.Now;
Console.WriteLine($"Vandaag is een {vandaag.DayOfWeek}");
Console.WriteLine($"Het jaar is {vandaag.Year}");

Console.Write("Geef een lengte: ");
double lengte = double.Parse(Console.ReadLine());
Console.Write("Geef een breedte: ");
double breedte = double.Parse(Console.ReadLine());
double diagonaal = Math.Sqrt(lengte*lengte + breedte*breedte);
Console.WriteLine($"De diagonaal is {diagonaal}");

Console.Write("Geef een hoek in graden: ");
double hoekGraden = double.Parse(Console.ReadLine());
double hoekRadialen = hoekGraden * Math.PI / 180;
Console.WriteLine($"Sinus is: {Math.Sin(hoekRadialen)} Cosinus is: {Math.Cos(hoekRadialen)}");

Console.Write("Geef een aantal dagen: ");
int aantal  = int.Parse(Console.ReadLine());
int weken   = aantal / 7;
int restant = aantal % 7;
Console.WriteLine($"Dat is {weken} weken en {restant} dagen");

string afscheid = new StringBuilder().Insert(0, "doei! ", 10).ToString();
Console.WriteLine(afscheid);