/* =============================================================================
 * Dice Roller
 * =============================================================================
 * 
 * Niji System - Wamo / ワーモ
 * 
 */

using System;
using System.IO;
using System.Runtime.InteropServices;

using Niji.Convenience;

namespace DiceRoller {
    class MainProgram {
        static void Main() {
            var convenience = new Convenience();
            // Ask the user for their name
            string user = "\u3000";
            Console.Write("What name do you go by? (Preferred name, no deadnames please) ");
            user = Console.ReadLine();
            // Retrieve date and time
            DateTime time = DateTime.Now;
            string dateTimeFileFormat = "yyyyMMdd-HHmmss";
            string dateTimeGreetFormat = "HH:mm:ss yyyy/MM/dd";
            string fileTime = time.ToString(dateTimeFileFormat);
            string timeGreeting = time.ToString(dateTimeGreetFormat);
            // Create output file
            string path = convenience.CreateFile("DiceRoller", "Rolls", "txt");
            // RNG initialisation
            var rng = new Random();
            int d6 = rng.Next(1, 7); // genNum == 1 <= x < 7
            int d20 = rng.Next(1, 21); // genNum == 1 <= x < 21
            // START!
            Console.WriteLine($"Welcome! The current date and time is {timeGreeting}!");
            // Open the file stream
            TextWriter rngOutput = new StreamWriter(outPath, true);
            // Ask which dice to roll
            int rollCount;
            int dice;
            Console.WriteLine("Which dice do you want to roll?");
            Console.WriteLine("1. d6" + "\t" + "2. d20");
            dice = Convert.ToInt32(Console.ReadLine());
            switch (dice) {
                case 1:
                    rngOutput.WriteLine($"{user} wants to roll a d6.");
                    // Ask how many times to roll the die
                    Console.WriteLine("How many times do you want to roll?");
                    rollCount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{user} rolls {rollCount}d6!");
                    rngOutput.WriteLine($"{user} rolls {rollCount}d6!");
                    // Rolls the die
                    for (int i = 1; i <= rollCount; i++) {
                        Console.Write($"{d6}, ");
                        rngOutput.WriteLine($"Your number is {d6}!");
                        d6 = rng.Next(1, 7);
                    }
                    Console.Write("\n");
                    break;
                case 2:
                    rngOutput.WriteLine($"{user} wants to roll a d20.");
                    // Ask how many times to roll the die
                    Console.WriteLine("How many times do you want to roll?");
                    rollCount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{user} rolls {rollCount}d20!");
                    rngOutput.WriteLine($"{user} rolls {rollCount}d20!");
                    // Rolls the die
                    for (int i = 1; i <= rollCount; i++) {
                        Console.Write($"{d20}, ");
                        rngOutput.WriteLine($"Your number is {d20}!");
                        d20 = rng.Next(1, 21);
                    }
                    Console.Write("\n");
                    break;
                // End of switch block
            }
            /* The exit routine */
            // Close the file stream
            rngOutput.WriteLine($"Hope to see you again soon, {user}!");
            rngOutput.Close();
            // Send the user on their way
            Console.WriteLine($@"Your generated numbers can be found in {outPath}");
            Console.WriteLine($"Have a nice day, {user}!");
            Console.WriteLine("Please press any key to exit...");
            Console.ReadKey();
        }
    }
}
