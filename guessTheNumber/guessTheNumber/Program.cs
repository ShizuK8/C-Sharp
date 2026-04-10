// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool isBusyGuessing = true;
int downLimit = 0;
int upLimit = 100;
int currentGuess = 0;

while (isBusyGuessing)
{
    int researchZone = upLimit - downLimit;
    int center = Convert.ToInt32(researchZone * 0.5f);
    currentGuess = downLimit + center;

    Console.WriteLine("My guess " +  currentGuess);
    Console.WriteLine("Is it highter, lower, or equal ?");
    string answer = Console.ReadLine();

    if (answer == "highter")
    {
        downLimit = currentGuess;
    }else if (answer == "lower")
    { 
            upLimit = currentGuess;
    }
    else
    {
        Console.WriteLine("Your number is" + currentGuess);
        isBusyGuessing=false;

    }
    Console.WriteLine("Voulez vous rejouer ?");
    string answerEndGame = Console.ReadLine().ToLower();
    if (answerEndGame == "yes")
        isBusyGuessing = true;
    else if (answerEndGame == "no")
        Environment.Exit(0);
}



