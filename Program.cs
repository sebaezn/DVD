using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }   
    using System;

public class Movie
{
    // Properties for movie details
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public string Classification { get; private set; }
    public int Duration { get; private set; }

    // Constructor to initialize a new movie
    public Movie(string title, string genre, string classification, int duration)
    {
        Title = title;
        Genre = genre;
        Classification = classification;
        Duration = duration;
    }

    // Method to display movie information
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Classification: {Classification}");
        Console.WriteLine($"Duration: {Duration} minutes");
    }
}

}
