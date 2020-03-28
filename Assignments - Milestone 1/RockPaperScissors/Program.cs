using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            string playAgain = "n";
            int computerAnswer = 0;
            int computerChoice()
            {
                return computerAnswer = randomizer.Next(4);
            }

            do
            {
                int totalWins = 0;
                int totalTies = 0;
                int totalLosses = 0;
                Console.WriteLine("Let's play Rock, Paper, Scissors! How many rounds would you like to play? ");
                string input = Console.ReadLine();
                int.TryParse(input, out int totalRounds);
                if (totalRounds > 10 || totalRounds < 1)
                {
                    Console.WriteLine("ERROR! Number of rounds must be between 1 and 10.");
                    System.Environment.Exit(1);
                }

                int currentRound = 1;
                while (totalRounds > 0)
                {
                    Console.WriteLine("Round " + currentRound + ": Rock[1], Paper[2], or Scissors[3]?");
                    input = Console.ReadLine();
                    int.TryParse(input, out int userChoice);
                    computerChoice();
                    switch (userChoice, computerAnswer)
                    {
                        case (1, 2):
                        case (2, 3):
                        case (3, 1):
                            Console.WriteLine("You lost that round...");
                            totalLosses++;
                            break;
                        case (1, 3):
                        case (2, 1):
                        case (3, 2):
                            Console.WriteLine("Congratulations! You won that round!");
                            totalWins++;
                            break;
                        default:
                            Console.WriteLine("Its a Tie.");
                            totalTies++;
                            break;
                    }
                    currentRound++;
                    totalRounds--;
                }
                Console.WriteLine("What a great game! Here are the stats:\n");
                Console.WriteLine("You won: " + totalWins + " rounds");
                Console.WriteLine("You lost: " + totalLosses + " rounds");
                Console.WriteLine("We tied: " + totalTies + " rounds");
                Console.WriteLine("And the winner is...\n");
                if (totalWins > totalLosses)
                {
                    Console.WriteLine("YOU!! Congratulations!!\n");
                } if (totalWins < totalLosses)
                {
                    Console.WriteLine("Me! Better luck next time!\n");
                } if (totalWins == totalLosses)
                {
                    Console.WriteLine("No one! It's a tie.\n");
                }

                Console.Write("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine();

            } while (playAgain.Equals("y")) ;
            Console.WriteLine("Maybe next time. Thanks for playing!");
        }
    }
}
