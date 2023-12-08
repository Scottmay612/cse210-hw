using System;

class Program
{
    static void Main(string[] args)
    {
        // Display menu options.
        Console.WriteLine("Here are your options: ");
        Console.WriteLine("1. 5 Crowns");
        Console.WriteLine("2. Golf");
        Console.WriteLine("3. Skull King");
        Console.WriteLine("4. Skyjo");
        Console.WriteLine("5. Cover Your Assets");
        Console.WriteLine("6. Phase 10");
        Console.WriteLine("7. Load Previous Game");
        Console.WriteLine("8. Quit");
        Console.Write("What would you like to do? ");
        string gameChoice = Console.ReadLine();

        switch(gameChoice) {
            case "1": {
                // Begin Five Crowns.
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
static void CreateGame(int roundNumber, string gameName, int endingLimit, List<Player> players)
{
    // Switch based on the game name to create and run the corresponding game instance.
    switch (gameName)
    {
        case "Five Crowns":
            // Create a new instance of the FiveCrowns game.
            FiveCrowns fiveCrowns = new FiveCrowns(roundNumber, gameName, endingLimit, players);

            // Run the FiveCrowns game.
            fiveCrowns.RunGame(endingLimit);

            // Break out of the switch statement.
            break;

        case "Golf":
            // Create a new instance of the Golf game.
            Golf golf = new Golf(roundNumber, gameName, endingLimit, players);

            // Run the Golf game.
            golf.RunGame(endingLimit);

            // Break out of the switch statement.
            break;

        case "Skull King":
            // Create a new instance of the SkullKing game.
            SkullKing skullKing = new SkullKing(roundNumber, gameName, endingLimit, players);

            // Run the SkullKing game.
            skullKing.RunGame(endingLimit);

            // Break out of the switch statement.
            break;

        case "Skyjo":
            // Create a new instance of the Skyjo game.
            Skyjo skyjo = new Skyjo(roundNumber, gameName, endingLimit, players);

            // Run the Skyjo game.
            skyjo.RunGame(endingLimit);

            // Break out of the switch statement.
            break;

        case "Cover Your Assets":
            // Create a new instance of the CoverYourAssets game.
            CoverYourAssets coverYourAssets = new CoverYourAssets(roundNumber, gameName, endingLimit, players);

            // Run the CoverYourAssets game.
            coverYourAssets.RunGame(endingLimit);

            // Break out of the switch statement.
            break;

        case "Phase 10":
            // Create a new instance of the PhaseTen game.
            PhaseTen phaseTen = new PhaseTen(roundNumber, gameName, endingLimit, players);

            // Run the PhaseTen game.
            phaseTen.RunGame(endingLimit);

            // Break out of the switch statement.
            break;
    }
}

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
