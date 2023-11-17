using System;
using System.IO;

// Exceeding requirements:
// To exceed the requirements, I added a "Delete Goal" option to the main menu. 
// When they pick that option, the menu displays the user's goals and the user 
// can pick which one to remove from the list.
class Program
{
    // Declare the member variable for the total points.
    static float _totalPoints = 0;

    static void Main(string[] args)
    {
        // Declare menu choice answer.
        string menuChoice = "";

        // Declare goalsList to store the user's goals.
        List<Goal> goalsList = new List<Goal>();

        // Continue looping until the user chooses quit.
        while(menuChoice != "7") {

            // Display menu to the user.
            Console.WriteLine();
            DisplayPoints();
            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Delete Goal");
            Console.WriteLine("7. Quit");

            // Get user's menu choice.
            Console.Write("Select a choice from the menu: ");
            menuChoice = Console.ReadLine();

            switch(menuChoice) {
                case "1": {
                    // Create a new goal.

                    // Display the goal menu.
                    Console.WriteLine();
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");

                    // Get the user's choice of goal. 
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();

                    switch(goalType) {
                        case "1":{
                            // Create a Simple Goal.
                            SimpleGoal simpleGoal = new SimpleGoal();

                            // Get name, description, and points amount from user.
                            Console.WriteLine();
                            simpleGoal.PromptUser();

                            // Add the goal to the list of goals.
                            goalsList.Add(simpleGoal);

                            break;
                        }
                        case "2": {
                            // Create an Eternal Goal.
                            EternalGoal eternalGoal = new EternalGoal();

                            // Get name, description, and points amount from user.
                            Console.WriteLine();
                            eternalGoal.PromptUser();
                            
                            // Add the goal to the list of goals.
                            goalsList.Add(eternalGoal);

                            break;
                        }
                        case "3": {
                            // Create a Checklist Goal.
                            ChecklistGoal checklistGoal = new ChecklistGoal();

                            // Get name, description, and points amount from user.
                            Console.WriteLine();
                            checklistGoal.PromptUser();

                            // Add the goal to the list of goals.
                            goalsList.Add(checklistGoal);
                            break;
                        }
                        default: {
                            // Handle an invalid input.
                            Console.WriteLine("Sorry, your response was invalid.");
                            break;
                        }
                    }
                    break;
                }
                case "2": {
                    // List Goals.
                    
                    Console.WriteLine();
                    Console.WriteLine("The goals are: ");
                    DisplayGoals(goalsList);

                    break;
                }
                case "3": {
                    // Save Goals.

                    // Get file name from the user?
                    Console.Write("What is the file name? ");
                    string fileName = Console.ReadLine();

                    // Declare a list of the goals strings to be saved to a file.
                    List<string> goalsStrings = new List<string>();

                    // Add the total points to the file before iterating through each goal.
                    goalsStrings.Add(_totalPoints.ToString());

                    // Turn each goal into a string and add it to the list.
                    foreach(Goal goal in goalsList) {
                        string text = goal.ToString();
                        goalsStrings.Add(text);
                    }

                    // Save each goal string to the user's file.
                    SaveGoals(fileName, goalsStrings);
                    break;
                }
                case "4": {
                    // Load Goals.

                    // Get the file name from the user.
                    Console.Write("What is the file name? ");
                    string fileName = Console.ReadLine();

                    // Read all lines from the user's file.
                    string[] fileLines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in fileLines)
                    {
                        // Split each parts at the | characters.
                        string[] parts = line.Split("|");

                        // Get the goal type of each goal.
                        string goalType = parts[0];

                        if (goalType == "simple") {
                            // Re-create the goal and add it to the goals list.
                            SimpleGoal simpleGoal = new SimpleGoal(parts);
                            goalsList.Add(simpleGoal);
                        }
                        else if (goalType == "eternal") {
                            // Re-create the goal and add it to the goals list.
                            EternalGoal eternalGoal = new EternalGoal(parts);
                            goalsList.Add(eternalGoal);
                        }
                        else if (goalType == "checklist") {
                            // Re-create the goal and add it to the goals list.
                            ChecklistGoal checklistlGoal = new ChecklistGoal(parts);
                            goalsList.Add(checklistlGoal);
                        }
                        else {
                            // Update the total points with the points written in the file.
                            _totalPoints = int.Parse(goalType);
                        }
                    }
                    break;
                }
                case "5": {
                    // Record Event.

                    // Display all the goals to the user.
                    Console.WriteLine();
                    Console.WriteLine("The goals are:");
                    DisplayGoals(goalsList);

                    // Ask the user which goal they have accomplished.
                    Console.Write("Which goal would you like to record? ");

                    // Save user response as an integer.
                    int goalChoice = int.Parse(Console.ReadLine());

                    // Get the reward points and add it to the total points.
                    float pointsToAdd = goalsList[goalChoice - 1].GetPoints();
                    _totalPoints += pointsToAdd;

                    // Record the user's goal completion.
                    goalsList[goalChoice - 1].RecordEvent();

                    break;
                }
                case "6": {

                    // Display all of the goals.
                    Console.WriteLine();
                    Console.WriteLine("The goals are:");
                    DisplayGoals(goalsList);

                    // Prompt the user for which goal they would like to delete.
                    Console.Write("Which goal would you like to delete? ");
                    int deleteGoal = int.Parse(Console.ReadLine());

                    // Remove the goal at that index.
                    goalsList.Remove(goalsList[deleteGoal - 1]);

                    // Display deletion confirmation message.
                    Console.WriteLine();
                    Console.WriteLine("The goal has been deleted.");
                    break;
                }
                case "7": {
                    // Quit.
                    break;
                }
                default: {
                    // Handle an invalid input.
                    Console.WriteLine("Sorry, your response was invalid.");
                    break;
                }
            }

        }
    }
    static void DisplayGoals(List<Goal> goalsList) {
        // Declare counter variable for foreach loop.
        int counter = 1;

        // Display each goal in the goals list.
        foreach(Goal goal in goalsList) {

            Console.Write($"{counter}. ");
            goal.DisplayGoal();
            Console.WriteLine();

            // Increment the counter by 1.
            counter ++;
        }

    }
    static void SaveGoals(string filename, List<string> strings) {
        // Write the user's goals to a file.
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            
            // Write each goal string individually.
            foreach(string line in strings) {
                outputFile.WriteLine(line);
            }
        }
    }
        public static void DisplayPoints() {
        // Display the user's total points.
        Console.WriteLine($"You have {_totalPoints} points!");
    }
}