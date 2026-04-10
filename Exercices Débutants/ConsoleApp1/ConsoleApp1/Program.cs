// See https://aka.ms/new-console-template for more information
Console.WriteLine("What is your name ? ");
string userName = Console.ReadLine();

int age = 24;
float maTaille = 105f;
//Console.WriteLine("1er Nombre");
//int a = int.Parse(Console.ReadLine());
//Console.WriteLine("2eme Nombre");
//int b = int.Parse(Console.ReadLine());
//Console.WriteLine("Selectionne une longueur (en CM)");
//float Longueur = float.Parse(Console.ReadLine());
//Console.WriteLine("Selectionne une largeur (en CM)");
//float Largeur = float.Parse(Console.ReadLine());
//Console.WriteLine("entrez les degrés celcius, pour les convertir en Farenheit");
//float celcius = float.Parse(Console.ReadLine());
Console.WriteLine("entrez les degrés Farenheit, pour les convertir en Celsius");
float farenheit = float.Parse(Console.ReadLine());
Console.Clear();


Console.WriteLine("Bonjour je m'appelle " + userName + " j'ai " + age + " ans et je mesure " + maTaille + "CM");
//Console.WriteLine($"la somme de {a}  et de {b} fait {a + b}");
//Console.WriteLine($"la division de {a}  et de {b} fait {a / b}");
//Console.WriteLine($"la multiplication de {a}  et de {b} fait {a * b}");
//Console.WriteLine($"la soustraction de {a}  et de {b} fait {a - b}");
// add, soust,mult et division.
//Console.WriteLine($"L'aire du rectangle de {Longueur}CM sur {Largeur} est de {Longueur * Largeur}");
//Console.WriteLine($"{celcius} ° celcius fait {celcius*9/5+32} ° Farenheit"); 
Console.WriteLine($"{farenheit} °F fait {(farenheit-32)*5/9} °C");




