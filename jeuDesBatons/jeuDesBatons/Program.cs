// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

Console.WriteLine("Jeu des 25 bâtonnets");
Console.WriteLine("Chaque joueur peut prendre 1, 2 ou 3 bâtonnets.");
Console.WriteLine("Celui qui prend le dernier perd.");

int batonnets = 25;
int joueur = 1;



Console.WriteLine("il y a " + batonnets + " batonnets");
while (batonnets > 0)
{
    Console.WriteLine("Tour du joueur " + joueur);
    Console.WriteLine("Combien de batonnets prends tu ? (1-3)");
    int choix = int.Parse(Console.ReadLine());
    batonnets -= choix;

    Console.WriteLine("Il reste " + batonnets + " bâtonnets.");
  

    if (batonnets <= 0)
    {
        Console.WriteLine("Le joueur " + joueur + " perd !");
    }
    int ia = (batonnets - 1) % 4;
    if (ia == 0)
    {
        ia = 1;
    }

    Console.WriteLine("L'ordinateur prend " + ia + " bâtonnets.");

    batonnets -= ia;
    Console.WriteLine("il reste " + batonnets + " batonnets");
    for (int i = 0; i < batonnets; i++)
    {
        Console.Write("| ");
    }
    Console.WriteLine();
}






