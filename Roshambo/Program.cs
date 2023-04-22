using System;

namespace Roshambo
{
    internal class Program
    {
        enum Selections
        {
            Rock, Paper, Scissors, Nothing
        }
        static void Main(string[] args)
        {
            Console.Write("Enter player1 name: ");
            Player player1 = new Player(Console.ReadLine(), false);

            Console.Write("\nEnter player2 name: ");
            Player player2 = new Player(Console.ReadLine(), true);
            Start(player1, player2);
            Console.ReadKey();
        }
        private static void Start(Player player1, Player player2)
        {
            if (player1.Choice == Selections.Nothing && player2.Choice == Selections.Nothing) Console.WriteLine("Both {0} and {1} has selected {2}! Tie!", player1.Name, player2.Name, player1.Choice);
            else if (player1.Choice == Selections.Nothing) Console.WriteLine("{0} has selected {1}! Tie!", player1.Name, player1.Choice);
            else if (player2.Choice == Selections.Nothing) Console.WriteLine("{0} has selected {1}! Tie!", player2.Name, player2.Choice);
            else if (player1.Choice == player2.Choice) Console.WriteLine("{0} and {1} have selected the same thing: {2}! Tie!", player1.Name, player2.Name, player1.Choice);
            else if (player1.Choice == Selections.Rock && player2.Choice == Selections.Scissors || player1.Choice == Selections.Paper && player2.Choice == Selections.Rock ||
                player1.Choice == Selections.Scissors && player2.Choice == Selections.Paper)
            {
                Console.WriteLine("{0} beats {1}!", player1.Name, player2.Name);
                player1.Score++;
            }
            else
            {
                Console.WriteLine("{1} beats {0}!", player1.Name, player2.Name);
                player2.Score++;
            }
        }
        private struct Player
        {
            public string Name;
            public int Score = 0;
            public Selections Choice;
            public Player(string name, bool isAI) : this()
            {
                Random random = new Random();
                if (string.IsNullOrWhiteSpace(name)) name = "Player" + random.Next(0, 1000);
                Name = name;
                if (!isAI)
                {
                    Console.WriteLine("Only one of these is allowed to be selected: R, P, S"); //message
                    string selection = Console.ReadLine(); //getting selection as string

                    switch (selection) // player's choice
                    {
                        case "r":
                        case "R":
                            Choice = Selections.Rock;
                            break;
                        case "s":
                        case "S":
                            Choice = Selections.Scissors;
                            break;
                        case "p":
                        case "P":
                            Choice = Selections.Paper;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            Choice = Selections.Nothing;
                            break;
                    }
                    Console.WriteLine("{0} has selected the {1}!", Name, Choice); // print the player's choice
                }
                else
                {
                    Choice = (Selections)random.Next(/*Enum.GetValues(typeof(Selections*/3)/*).Length)*/; // that will return 3

                    Console.WriteLine("{0} has selected the {1}",Name , Choice);
                }
            }
        }
    }
}