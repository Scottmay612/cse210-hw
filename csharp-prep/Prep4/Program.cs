using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        //Create list
        List<int> numbers = new List<int>();

        //Declare variables
        int sum = 0;
        int max = 0;

        //Ask for numbers
        Console.Write("Enter a list of numbers, type 0 when finished: ");
        int number = int.Parse(Console.ReadLine());

        //while loop
        while (number != 0)
        {
            numbers.Add(number);
            number = int.Parse(Console.ReadLine());
        }

        //count the sum and identify max
        foreach (int item in numbers)
        {
            sum += item;
            if (item > max)
            {
                max = item;
            }
        }

        //number calculations
        int size = numbers.Count;
        float average = (float)sum / size;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The max is: {max}");





        //foreach (string word in words)

        // for (int i = 0; i < words.Count; i++)
            // Console.WriteLine(words[i])
    }
}