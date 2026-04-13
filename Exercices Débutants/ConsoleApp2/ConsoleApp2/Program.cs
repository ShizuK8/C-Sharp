using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Quel est votre nom ? ");
        string userName = ReadNonEmptyString();

        int age = ReadInt("Quel âge avez-vous ?", defaultValue: 24);
        double tailleCm = ReadDouble("Entrez votre taille en cm", defaultValue: 105.0);

        double fahrenheit = ReadDouble("Entrez les degrés Fahrenheit à convertir en Celsius");

        Console.Clear();
        Console.WriteLine($"Bonjour, je m'appelle {userName}, j'ai {age} ans et je mesure {tailleCm:F1} cm.");
        Console.WriteLine($"{fahrenheit:F2} °F fait {FahrenheitToCelsius(fahrenheit):F2} °C");
        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey(intercept: true);
    }

    static string ReadNonEmptyString()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            Console.Write("Veuillez saisir une valeur non vide : ");
        }
    }

    static int ReadInt(string prompt, int? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{prompt}{(defaultValue.HasValue ? $" (vide = {defaultValue})" : "")}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                if (defaultValue.HasValue) return defaultValue.Value;
                Console.WriteLine("Valeur requise.");
                continue;
            }

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.CurrentCulture, out int value) ||
                int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }

            Console.WriteLine("Format entier invalide, réessayez.");
        }
    }

    static double ReadDouble(string prompt, double? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{prompt}{(defaultValue.HasValue ? $" (vide = {defaultValue})" : "")}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                if (defaultValue.HasValue) return defaultValue.Value;
                Console.WriteLine("Valeur requise.");
                continue;
            }

            // Essayer avec la culture courante puis Invariant (autorise ',' et '.')
            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double d) ||
                double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out d))
            {
                return d;
            }

            // Tentative supplémentaire: remplacer virgule par point (au cas où)
            var normalized = input.Replace(',', '.');
            if (double.TryParse(normalized, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out d))
                return d;

            Console.WriteLine("Format numérique invalide, réessayez (ex: 12.34 ou 12,34).");
        }
    }

    static double FahrenheitToCelsius(double f) => (f - 32.0) * 5.0 / 9.0;
}
