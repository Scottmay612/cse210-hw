using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Here are you options: ");
        Console.WriteLine("1. 5 Crowns");
        Console.WriteLine("2. Golf");
        Console.WriteLine("3. Skull King");
        Console.WriteLine("4. Skyjo");
        Console.WriteLine("5. Kanasta");
        Console.WriteLine("6. Fruit Salad");
        Console.WriteLine("7. Load Previous Game");
        Console.WriteLine("8. Quit");
        Console.Write("Which game would you like to play? ");
        string gameChoice = Console.ReadLine();

        switch(gameChoice) {
            case "1": {
                // Begin 5 Crowns.
                FiveCrowns fiveCrowns = new FiveCrowns();
                fiveCrowns.RunGame();
                break;
            }
            case "2": {
                // Begin Golf.
                break;
            }
            case "3": {
                // Begin Skull King.
                break;
            }
            case "4": {
                // Begin Skyjo.

                break;
            }
            case "5": {
                // Begin Kanasta
                break;
            }
            case "6": {
                // Begin Fruit Salad.
                break;
            }
            case "7": {
                // Load previous game.
                Console.WriteLine("What is the file name? ");
                string fileName = Console.ReadLine();
                    string[] fileLines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in fileLines)
                    {
                        // Split each parts at the | characters.
                        string[] parts = line.Split("|");

                        // Get the goal type of each goal.
                        string playerName = parts[0];
                    }
                
                break;
            }
            case "8": {
                // End the program.
                break;
            }
        }
    
    }
}