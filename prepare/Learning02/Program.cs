using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startyear = 2020;
        job1._endyear = 2023;

        Job job2 = new();
        job2._jobTitle = "Computer Engineer";
        job2._company = "Apple";
        job2._startyear = 2013;
        job2._endyear = 2020;

        Resume myResume = new Resume();
        myResume._personName = "Scott May";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}