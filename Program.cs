using System;
using System.Collections.Generic;
namespace CommunityLibraryDVD
{
    class Program
    {
        static MovieCollection movieCollection = new MovieCollection();
        static MemberCollection memberCollection = new MemberCollection();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Community Library DVD Management System!");
                Console.WriteLine("Are you a (1) Staff or (2) Member? Enter 'exit' to close the application.");
                string userType = Console.ReadLine();
                if (userType.ToLower() == "exit")
                {
                    break;
                }

                switch (userType)
                {
                    case "1":
                        AuthenticateStaff();
                        break;
                    case "2":
                        AuthenticateMember();
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose 1 for Staff or 2 for Member.");
                        break;
                }
            }
        }

        static void AuthenticateStaff()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (username == "staff" && password == "today123")
            {
                StaffMenu();
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }

        static void AuthenticateMember()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            Member member = memberCollection.FindMember(firstName, lastName);
            if (member != null && member.Password == password)
            {
                MemberMenu(member);
            }
            else
            {
                Console.WriteLine("Authentication failed or member not found.");
            }
        }

        static void StaffMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nStaff Menu:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Remove Movie");
                Console.WriteLine("3. Register Member");
                Console.WriteLine("4. Remove Member");
                Console.WriteLine("5. Find Member Contact");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddMovie();
                        break;
                    case "2":
                        RemoveMovie();
                        break;
                    case "3":
                        RegisterMember();
                        break;
                    case "4":
                        RemoveMember();
                        break;
                    case "5":
                        FindMemberContact();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void MemberMenu(Member member)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMember Menu:");
                Console.WriteLine("1. View All Movies");
                Console.WriteLine("2. View Movie Details");
                Console.WriteLine("3. Borrow Movie");
                Console.WriteLine("4. Return Movie");
                Console.WriteLine("5. List My Borrowed Movies");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllMovies();
                        break;
                    case "2":
                        ViewMovieDetails();
                        break;
                    case "3":
                        BorrowMovie(member);
                        break;
                    case "4":
                        ReturnMovie(member);
                        break;
                    case "5":
                        ListBorrowedMovies(member);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // Placeholder methods for actions in the menu
        static void AddMovie() { /* Implementation here */ }
        static void RemoveMovie() { /* Implementation here */ }
        static void RegisterMember() { /* Implementation here */ }
        static void RemoveMember() { /* Implementation here */ }
        static void FindMemberContact() { /* Implementation here */ }
        static void DisplayAllMovies() { /* Implementation here */ }
        static void ViewMovieDetails() { /* Implementation here */ }
        static void BorrowMovie(Member member) { /* Implementation here */ }
        static void ReturnMovie(Member member) { /* Implementation here */ }
        static void ListBorrowedMovies(Member member) { /* Implementation here */ }
    }
    
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
    public class MovieCollection
    {
        private List<Movie>[] movies;
        private int capacity = 1000;

        public MovieCollection()
        {
            movies = new List<Movie>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                movies[i] = new List<Movie>();
            }
        }

        private int HashFunction(string title)
        {
            int hash = 0;
            foreach (char c in title)
            {
                hash = (hash * 31 + c) % capacity;
            }
            return hash;
        }

        public void AddMovie(Movie movie)
        {
            int index = HashFunction(movie.Title);
            var bucket = movies[index];
            foreach (var m in bucket)
            {
                if (m.Title == movie.Title)
                {
                    // Update existing movie details if needed
                    return;
                }
            }
            bucket.Add(movie);
        }

        public void RemoveMovie(string title)
        {
            int index = HashFunction(title);
            var bucket = movies[index];
            bucket.RemoveAll(m => m.Title == title);
        }

        public Movie GetMovie(string title)
        {
            int index = HashFunction(title);
            foreach (var movie in movies[index])
            {
                if (movie.Title == title)
                {
                    return movie;
                }
            }
            return null; // Movie not found
        }

        public void DisplayAllMovies()
        {
            foreach (var bucket in movies)
            {
                foreach (var movie in bucket)
                {
                    movie.DisplayInfo();
                    Console.WriteLine(); // For better formatting
                }
            }
        }
    }
}

