using System;

class Program
{
    static void Main(string[] args)
    
    {
        Random random = new Random();
        int magic_number = random.Next(100);
        int guess = 10000000;

        // //Asking for the magic number
        // Console.Write("What is the magic number? ");
        // string str_number = Console.ReadLine();
        // int magic_number = int.Parse(str_number);
        
        while (guess != magic_number)
        {
            //Asking for their guess
            Console.Write("What is your guess? ");
            string str_guess = Console.ReadLine();
            guess = int.Parse(str_guess);

            //print response
            if (guess > magic_number)
            {
                Console.WriteLine("Too high.");
            }
            else if (guess < magic_number)
            {
                Console.WriteLine("Too low.");
            }
        }
            Console.WriteLine("You guessed it!");
    }
}