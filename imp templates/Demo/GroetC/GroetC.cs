using System;

Console.Write("Wat is je naam? ");
string naam;
naam = Console.ReadLine();
Console.WriteLine($"Hallo {naam}!");
Console.WriteLine($"Je naam heeft {naam.Length} letters.");