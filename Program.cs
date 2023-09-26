using System.Security.Cryptography;

using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zahlenraten Spiel");
            bool playAgain = true;

            while (playAgain)
            {
                int minRange = 1;
                int maxRange = 100;
                int maxAttempts = 10;
                TimeSpan timeLimit;

                Console.Write("Schwierigkeit wählen (");
               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("easy");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/normal");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("/hard): ");
                Console.ResetColor();

                string antwort = Console.ReadLine();

                if (antwort == "easy")
                {
                    maxRange = 50;
                    maxAttempts = 15;
                    timeLimit = TimeSpan.FromSeconds(60); 
                }
                else if (antwort == "normal")
                {
                    timeLimit = TimeSpan.FromSeconds(45); 
                }
                else if (antwort == "hard")
                {
                    minRange = 1;
                    maxRange = 200;
                    maxAttempts = 8;
                    timeLimit = TimeSpan.FromSeconds(20); 
                }
                else
                {
                    Console.WriteLine("Ungültige Schwierigkeit. Bitte wählen Sie aus easy, normal, or hard.");
                    continue;
                }

                Random zufall = new Random();
                int nummer = zufall.Next(minRange, maxRange);

                int guess = 0;
                int attempts = 1;
                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                Console.WriteLine("Sie haben " + maxAttempts + " Versuche und " + timeLimit + ", um die Zahl zu erraten.");
                Console.Write("Zahl:");

                while (int.TryParse(Console.ReadLine(), out guess))
                {
                    if (guess < nummer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("zu niedrig");
                        attempts++;
                    }
                    else if (guess > nummer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("zu hoch");
                        attempts++;
                    }
                    else if (guess == nummer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du hast die Zahl in " + attempts + " Versuche erraten");
                        break;
                    }

                    if (attempts >= maxAttempts)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Keine Versuche mehr. Die richtige Zahl war " + nummer);
                        break;
                    }

                    if (stopwatch.Elapsed >= timeLimit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Die Zeit ist um! Die richtige Zahl war " + nummer);
                        break;
                    }

                    Console.Write("Zahl:");
                }

                stopwatch.Stop();

                Console.WriteLine("Wieder spielen? ");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("(yes");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write("/no)");
                Console.ResetColor();


                string response = Console.ReadLine().ToLower();

                if (response == "no")
                {
                    playAgain = false;
                }

                if (response == "yes")
                {
                    playAgain = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe");
                    return;
                }
            }
        }
    }
}
