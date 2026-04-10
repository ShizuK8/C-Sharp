// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

Console.WriteLine("Quel est votre Username ?");
string userName = Console.ReadLine().ToUpper();
string fichierSauvegarde = "MaToDoList.json";
bool toDoList = true;
List<string> TachesAFaire = new List<string>();
List<string> TachesTerminées = new List<string>();

void Menu()
{
    Console.Clear();
    Console.WriteLine("===== TO DO LIST DE " + userName + "=====");
    Console.WriteLine("1 - Ajouter une tâche");
    Console.WriteLine("2 - Voir les tâches");
    Console.WriteLine("3 - Supprimer une tâche");
    Console.WriteLine("4 - Marquer une tâche comme terminée");
    Console.WriteLine("5 - Quitter");
    Console.WriteLine("Votre choix :");
}
void SauvegarderDonnees()
{
    // On crée un petit dictionnaire pour sauvegarder les deux listes d'un coup
    var donnees = new { A_Faire = TachesAFaire, Terminees = TachesTerminées };

    // On transforme l'objet en texte JSON
    string jsonString = JsonSerializer.Serialize(donnees);

    // On écrit le texte dans le fichier
    File.WriteAllText(fichierSauvegarde, jsonString);
}

void ChargerDonnees()
{
    if (File.Exists(fichierSauvegarde))
    {
        string jsonString = File.ReadAllText(fichierSauvegarde);

        // On décode le JSON (on utilise un "JsonDocument" pour la simplicité ici)
        using (JsonDocument doc = JsonDocument.Parse(jsonString))
        {
            var root = doc.RootElement;

            // On recharge la liste A Faire
            foreach (var item in root.GetProperty("A_Faire").EnumerateArray())
                TachesAFaire.Add(item.GetString());

            // On recharge la liste Terminées
            foreach (var item in root.GetProperty("Terminees").EnumerateArray())
                TachesTerminées.Add(item.GetString());
        }
    }
}

ChargerDonnees();

while (toDoList)
{
    Menu();
    if (!int.TryParse(Console.ReadLine(), out int choix))
    {
        Console.WriteLine("Veuillez entrer un chiffre valide !");
        Thread.Sleep(1000);
        continue;
    }

        if (choix == 5)
        Environment.Exit(0);
    if (choix == 1)
    {
        Console.Clear();
        Console.WriteLine("indiquez le nom de la tache à ajouter :");
        TachesAFaire.Add(Console.ReadLine().ToLower());
        Console.Clear();
        Console.WriteLine("Votre liste à été mise à jour :");
        TachesAFaire.ForEach(t => Console.WriteLine(t));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press a key to back to the main menu");
        Console.ReadKey();
        SauvegarderDonnees();


    }
    if (choix == 2)
    {
        Console.Clear();
        Console.WriteLine("Liste de vos tâches à faire :");
        TachesAFaire.ForEach((t) => Console.WriteLine(t));
        Console.WriteLine();
        Console.WriteLine("Liste de tâches terminées : ");
        TachesTerminées.ForEach(t => Console.WriteLine(t));
        Console.WriteLine();
        Console.WriteLine("Press a key to back to the main menu");
        Console.ReadKey();
    }
    if (choix == 3)
    {
        Console.Clear();
        Console.WriteLine("Quel tâche souhaitez vous supprimer ?");
        TachesAFaire.ForEach((t) => Console.WriteLine(t));
        Console.WriteLine();
        Console.WriteLine("Press any key to go back to the main menu");
        TachesAFaire.Remove(Console.ReadLine().ToLower());
        Console.Clear();
        Console.WriteLine("Votre liste a été mise à jour");
        TachesAFaire.ForEach((t) => Console.WriteLine(t));
        Console.WriteLine("Press a key to back to the main menu");
        Console.ReadKey();
        SauvegarderDonnees();
    }
    if (choix == 4)
    {
        Console.Clear();
        Console.WriteLine("--- QUELLE TÂCHE AVEZ-VOUS TERMINÉE ? ---");

        if (TachesAFaire.Count == 0)
        {
            Console.WriteLine("Aucune tâche à terminer.");
        }
        else
        {
            // On affiche la liste avec des numéros (index)
            for (int i = 0; i < TachesAFaire.Count; i++)
            {
                Console.WriteLine($"{i} - {TachesAFaire[i]}");
            }

            Console.WriteLine("\nEntrez le numéro de la tâche faite :");

            // On vérifie que la saisie est bien un nombre et qu'il existe dans la liste
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < TachesAFaire.Count)
            {
                string tacheFinie = TachesAFaire[index]; // On récupère la tâche

                TachesTerminées.Add(tacheFinie);         // On l'ajoute aux terminées
                TachesAFaire.RemoveAt(index);            // On l'enlève des "A faire"

                Console.WriteLine($"\nSuper ! La tâche '{tacheFinie}' est terminée.");
            }
            else
            {
                Console.WriteLine("Numéro invalide.");
            }
            SauvegarderDonnees();
        }

        Console.WriteLine("\nPress a key to back to the main menu");
        Console.ReadKey();
    }
}





