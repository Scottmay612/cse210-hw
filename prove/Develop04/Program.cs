using System;

class Program
{
    // To exceed requirements, I added a "read responses" feature to the listing
    // activity. At the end of the activity, the user is able to choose if they 
    // want to see what they wrote during the activity. If they say yes, it will 
    // display a numbered list of their responses. Then, they have to press 
    // enter to continue.
    static void Main(string[] args)
    {
        // Continue until the user chooses quit.
        int answerPicked = 0;
        while (answerPicked != 4)
        {
            // Clear the console before the menu.
            Console.Clear();

            // Display menu to the user.
            Console.WriteLine("Hello! Welcome to the mindfulness program.");
            Console.WriteLine();
            Console.WriteLine("Which activity would you like to do? (pick a number)");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            // Get the user's response.
            answerPicked = int.Parse(Console.ReadLine());

            // Clear the console after the menu.
            Console.Clear();

            // Go into the option that the user picked.
            switch (answerPicked)
            {
                case 1:
                    // Start Breathing Activity.
                    BreathingActivity breathingActivity = new BreathingActivity();

                    // Display opening message.
                    Console.WriteLine(breathingActivity._OpeningMsg);

                    // Display description.
                    Console.WriteLine();
                    Console.WriteLine(breathingActivity._Description);

                    // Ask how long the activity will run for.
                    Console.WriteLine();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    breathingActivity._Duration = Console.ReadLine();

                    // Display ready message with spinner.
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    breathingActivity.DisplaySpinner(3);
                    Console.WriteLine();

                    // Display countdown timer.
                    breathingActivity.BreatheInCountdown();
                    
                    Console.WriteLine("Well done!");
                    breathingActivity.DisplaySpinner(3);
                    Console.WriteLine();

                    // Update the closing message in the constructor and display it.
                    breathingActivity.UpdateClosingMsg();
                    breathingActivity.DisplayClosingMsg();

                    // Display spinner.
                    breathingActivity.DisplaySpinner(3);
                    break;
                case 2:
                    // Start Reflecting Activity.
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    Console.WriteLine(reflectingActivity._OpeningMsg);

                    // Display description.
                    Console.WriteLine();
                    Console.WriteLine(reflectingActivity._Description);
                    
                    // Prompt for duration time.
                    Console.WriteLine();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    reflectingActivity._Duration = Console.ReadLine();

                    // Display ready message with spinner.
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    reflectingActivity.DisplaySpinner(3);
                    Console.WriteLine();

                    // Show prompt to user.
                    Console.WriteLine("Consider the following prompt:");
                    Console.WriteLine();
                    Console.WriteLine($"--- {reflectingActivity.RandomPromptGenerator()} ---");
                    Console.WriteLine();

                    // Prompt user to press enter when they are ready. If they 
                    // type something else, the instruction will be shown to 
                    // them again.
                    string response = " ";
                    while (response != "") {
                        Console.WriteLine("When you have something in mind, press enter to continue.");
                        response = Console.ReadLine();
                    }

                    // Instruct user to ponder questions and display a 
                    // countdown until the activity starts.
                    Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
                    Console.Write("You may begin in: ");
                    reflectingActivity.DisplayCountdown(5);
                    Console.Clear();

                    // List questions for pondering every few seconds.
                    reflectingActivity.DoReflectingActivity();
                    Console.WriteLine();

                    Console.WriteLine("Well done!!");
                    Console.WriteLine();

                    // Update closing message in constructor and display it.
                    reflectingActivity.UpdateClosingMsg();
                    reflectingActivity.DisplayClosingMsg();
                    reflectingActivity.DisplaySpinner(3);
                    break;
                case 3:
                    // Start Listing Activity.
                    ListingActivity listingActivity = new ListingActivity();
                    Console.WriteLine(listingActivity._OpeningMsg);

                    // Display description.
                    Console.WriteLine();
                    Console.WriteLine(listingActivity._Description);

                    // Ask how long the activity will run for.
                    Console.WriteLine();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    listingActivity._Duration = Console.ReadLine();

                    // Display ready message with spinner.
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    listingActivity.DisplaySpinner(3);
                    Console.WriteLine();
                    
                    // Explain instructions and display prompt.
                    Console.WriteLine("List as many responses as you can to the following prompt:");
                    Console.WriteLine($"--- {listingActivity.RandomPromptGenerator()} ---");

                    // Show countdown until the activity starts.
                    Console.Write("You may begin in: ");
                    listingActivity.DisplayCountdown(5);
                    Console.WriteLine();

                    // Start the listing activity. The user will respond until the time runs out.
                    listingActivity.DoListingActivity();
                    listingActivity.DisplaySpinner(3);
                    Console.WriteLine();

                    // Update closing message in the constructor and display it.
                    listingActivity.UpdateClosingMsg();
                    listingActivity.DisplayClosingMsg();

                    // Display spinner.
                    listingActivity.DisplaySpinner(3);
                    Console.WriteLine();
                    
                    string readResponses = "";
                    while (readResponses != "y" && readResponses != "n") 
                    {
                        // Ask the user if they want to read their responses.
                        Console.WriteLine("Would you like to read your responses? (y/n)");
                        readResponses = Console.ReadLine();
                    }

                    // Display all responses in a numbered list.
                    if(readResponses == "y") {
                        Console.Clear();
                        Console.WriteLine("Here are your responses:");
                        Thread.Sleep(500);
                        listingActivity.ReadResponses();
                    }
                    break;
                case 4:
                    // Quit the program.
                    break;
                default:
                    // Handle the case where they choose an invalid option.
                    Console.WriteLine("Invalid menu choice. Please try again.");
                    break;
            }   
        }
        Console.WriteLine("Come again soon!");
    }
}