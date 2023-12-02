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
        Console.WriteLine("5. Cover Your Assets");
        Console.WriteLine("6. Phase 10");
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
                // Begin Cover Your Assets.
                CoverYourAssets coverYourAssets = new CoverYourAssets();
                coverYourAssets.SetInfo();
                int endingLimit = coverYourAssets.GetEndingLimit();
                coverYourAssets.RunGame(endingLimit);
                break;
            }
            case "6": {
                // Begin Phase 10.
                PhaseTen phaseTen = new PhaseTen();
                phaseTen.SetInfo();
                int endingLimit = phaseTen.GetEndingLimit();
                phaseTen.RunGame(endingLimit);
                break;
            }
            case "7": {
                // Load previous game.
                Console.Write("What is the file name? ");
                string fileName = Console.ReadLine();
                LoadFile(fileName);
                break;
            }
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
            case "Cover Your Assets": {
                CoverYourAssets coverYourAssets = new CoverYourAssets(roundNumber, gameName, endingLimit, players);
                coverYourAssets.RunGame(endingLimit);
                break;
            }
            case "Phase 10": {
                PhaseTen phaseTen = new PhaseTen(roundNumber, gameName, endingLimit, players);
                phaseTen.RunGame(endingLimit);
                break;
            }
        }
    }
    // static void LoadFile(string fileName) {
    //     string[] fileLines = System.IO.File.ReadAllLines(fileName);
    //     string gameInfo = fileLines[0];
    //     string[] splitGameInfo = gameInfo.Split("|");
    //     int roundNumber = int.Parse(splitGameInfo[1]);
    //     string gameName = splitGameInfo[2];
    //     int endingLimit = int.Parse(splitGameInfo[3]);
    //     // Console.WriteLine(gameInfo);
    //     List<Player> playersList = new List<Player>();
    //     for (int i = 1; i < fileLines.Length; i++)
    //     {
    //         string[] parts = fileLines[i].Split("|");
    //         Player player = new Player(parts);
    //         playersList.Add(player);
    //     }
    //     CreateGame(roundNumber, gameName, endingLimit, playersList);
    // }
    static void LoadFile(string fileName) {
        // Read all lines from the specified file.
        string[] fileLines = System.IO.File.ReadAllLines(fileName);

        // Extract game information from the first line.
        string gameInfo = fileLines[0];
        string[] splitGameInfo = gameInfo.Split("|");

        // Parse and store game information.
        int roundNumber = int.Parse(splitGameInfo[1]);
        string gameName = splitGameInfo[2];
        int endingLimit = int.Parse(splitGameInfo[3]);

        // Initialize an empty list to store players.
        List<Player> playersList = new List<Player>();

        // Iterate through each line from the second line onwards.
        for (int i = 1; i < fileLines.Length; i++)
        {
            // Split the current line into individual pieces of information.
            string[] parts = fileLines[i].Split("|");

            // Create a Player object using the extracted information.
            Player player = new Player(parts);

            // Add the newly created Player object to the list.
            playersList.Add(player);
        }

        // Create the game based on the extracted information and player data.
        CreateGame(roundNumber, gameName, endingLimit, playersList);
    }
}
