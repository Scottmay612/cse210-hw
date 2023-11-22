using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Here are your options: ");
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
                fiveCrowns.SetInfo();
                int endingLimit = fiveCrowns.GetEndingLimit();
                fiveCrowns.RunGame(endingLimit);
                break;
            }
            case "2": {
                // Begin Golf.
                Golf golf = new Golf();
                golf.SetInfo();
                int endingLimit = golf.GetEndingLimit();
                golf.RunGame(endingLimit);
                break;
            }
            case "3": {
                // Begin Skull King.
                SkullKing skullKing = new SkullKing();
                skullKing.SetInfo();
                int endingLimit = skullKing.GetEndingLimit();
                skullKing.RunGame(endingLimit);
                break;
            }
            case "4": {
                // Begin Skyjo.
                Skyjo skyjo = new Skyjo();
                skyjo.SetInfo();
                int endingLimit = skyjo.GetEndingLimit();
                skyjo.RunGame(endingLimit);
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
                    string gameInfo = fileLines[0];
                    string[] splitGameInfo = gameInfo.Split("|");
                    int roundNumber = int.Parse(splitGameInfo[1]);
                    string gameName = splitGameInfo[2];
                    int endingLimit = int.Parse(splitGameInfo[3]);
                    Console.WriteLine(gameInfo);
                    List<Player> playersList = new List<Player>();
                    for (int i = 1; i < fileLines.Length; i++)
                    {
                        string[] parts = fileLines[i].Split("|");
                        // string playerName = parts[1];
                        // int playerScore = int.Parse(parts[2]); 
                        Player player = new Player(parts);
                        playersList.Add(player);
                    }
                    CreateGame(roundNumber, gameName, endingLimit, playersList);
                    }
                
                break;
            // }
            case "8": {
                // End the program.
                break;
            }
        }
    
    }
    static void CreateGame( int roundNumber, string gameName, int endingLimit, List<Player> players) {
        switch(gameName) {
            case "5 Crowns": {
                FiveCrowns fiveCrowns = new FiveCrowns(roundNumber, gameName, endingLimit, players);
                fiveCrowns.RunGame(endingLimit);
                break;
            }
            case "Golf": {
                Golf golf = new Golf(roundNumber, gameName, endingLimit, players);
                golf.RunGame(endingLimit);
                break;
            }
            case "Skull King": {
                SkullKing skullKing = new SkullKing(roundNumber, gameName, endingLimit, players);
                skullKing.RunGame(endingLimit);
                break;
            }
            case "Skyjo": {
                Skyjo skyjo = new Skyjo(roundNumber, gameName, endingLimit, players);
                skyjo.RunGame(endingLimit);
                break;
            }
            case "Kanasta": {
                Kanasta kanasta = new Kanasta(roundNumber, gameName, endingLimit, players);
            }

        }
    }
}
