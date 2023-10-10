using System;

Console.Write("Bedrag: ");
double bedrag = double.Parse(Console.ReadLine());
Console.Write("Rentepercentage: ");
double rente = double.Parse(Console.ReadLine());

int jaar = 0;
while (jaar<=10)
{   Console.WriteLine($"Na {jaar} jaar: {bedrag}");
    bedrag *= (1 + 0.01*rente);
    jaar++;
}