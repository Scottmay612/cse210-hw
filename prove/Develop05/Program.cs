using System;
using System.IO;

class Program
{
    // Questions: 
    // 1. Made variables protected

    static void Main(string[] args)
    {
        string menuChoice = "";
        List<Goal> goalsList = new List<Goal>();
        while(menuChoice != "6") {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            menuChoice = Console.ReadLine();

            switch(menuChoice) {
                case "1": {
                    // Create a new goal.
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();
                    switch(goalType) {
                        case "1":{
                            // Make a Simple Goal.
                            SimpleGoal simpleGoal = new SimpleGoal();
                            simpleGoal.PromptUser();
                            goalsList.Add(simpleGoal);
                            break;
                        }
                        case "2": {
                            // Create an Eternal Goal.
                            EternalGoal eternalGoal = new EternalGoal();
                            eternalGoal.PromptUser();
                            goalsList.Add(eternalGoal);
                            break;
                        }
                        case "3": {
                            // Create a Checklist Goal.
                            ChecklistGoal checklistGoal = new ChecklistGoal();
                            checklistGoal.PromptUser();
                            goalsList.Add(checklistGoal);
                            break;
                        }
                    }
                    break;
                }
                case "2": {
                    // List Goals.
                    int counter = 1;
                    foreach(Goal goal in goalsList) {
                        Console.Write($"{counter}. ");
                        goal.DisplayGoal();
                        Console.WriteLine();
                        counter ++;
                    }
                    Console.WriteLine();
                    break;
                }
                case "3": {
                    // Save Goals.
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    foreach(Goal goal in goalsList) {
                        goal.SaveGoal(filename);
                        goal.testWrite(filename);
                    }
                    
                    break;
                }
                case "4": {
                    // Load Goals.
                    break;
                }
                case "5": {
                    // Record Event.
                    break;
                }
                case "6": {
                    // Quit.
                    break;
                }
            }

        }
    }
}