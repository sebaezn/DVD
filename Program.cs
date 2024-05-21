using System;

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
                Console.WriteLine("Are you a (1) Staff or (2) Member? Enter '0' to close the application.");
                string userType = Console.ReadLine();
                if (userType.ToLower() == "0")
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
        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
        static void AuthenticateStaff()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (username == "staff" && password == "1")
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
        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
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

        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
    static void AddMovie()
    {
        Console.WriteLine("Enter movie title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter number of copies:");
        int copies;
        while (!int.TryParse(Console.ReadLine(), out copies))
        {
            Console.WriteLine("Invalid input. Please enter a number for the copies.");
        }

        Movie existingMovie = movieCollection.GetMovie(title);
        if (existingMovie != null)
        {
            existingMovie.AddCopies(copies);
            Console.WriteLine("Additional copies added successfully.");
            return;
        }

        Console.WriteLine("Choose genre:");
        Console.WriteLine("1: Drama");
        Console.WriteLine("2: Adventure");
        Console.WriteLine("3: Family");
        Console.WriteLine("4: Action");
        Console.WriteLine("5: Sci-fi");
        Console.WriteLine("6: Comedy");
        Console.WriteLine("7: Animated");
        Console.WriteLine("8: Thriller");
        Console.WriteLine("9: Other");
        string genre = Console.ReadLine();
        switch (genre)
        {
            case "1": genre = "Drama"; break;
            case "2": genre = "Adventure"; break;
            case "3": genre = "Family"; break;
            case "4": genre = "Action"; break;
            case "5": genre = "Sci-fi"; break;
            case "6": genre = "Comedy"; break;
            case "7": genre = "Animated"; break;
            case "8": genre = "Thriller"; break;
            case "9": genre = "Other"; break;
            default: genre = "Other"; break;
        }

        Console.WriteLine("Choose classification:");
        Console.WriteLine("1: General (G)");
        Console.WriteLine("2: Parental Guidance (PG)");
        Console.WriteLine("3: Mature (M15+)");
        Console.WriteLine("4: Mature Accompanied (MA15+)");
        string classificationChoice = Console.ReadLine();
        string classification = classificationChoice switch
        {
            "1" => "G",
            "2" => "PG",
            "3" => "M15+",
            "4" => "MA15+",
            _ => "G",
        };

        Console.WriteLine("Enter duration in minutes:");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Invalid input. Please enter a number for the duration.");
        }

        Movie movie = new Movie(title, genre, classification, duration, copies);
        movieCollection.AddMovie(movie);
        Console.WriteLine("Movie added successfully.");
    }

        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
        static void RemoveMovie()
        {
            Console.WriteLine("Enter movie title to remove:");
            string title = Console.ReadLine();

            movieCollection.RemoveMovie(title);
            Console.WriteLine("Movie removed successfully if it existed.");
        }

        static void RegisterMember() 
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter contact number:");
            string contactNumber = Console.ReadLine();
            Console.WriteLine("Set a 4-digit password:");
            string password = Console.ReadLine();

            Member member = new Member(firstName, lastName, contactNumber, password);
            memberCollection.AddMember(member);

            Console.WriteLine("Member registered successfully.");
        }

        static void RemoveMember()
        {
            Console.WriteLine("Enter first name of member to remove:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name of member to remove:");
            string lastName = Console.ReadLine();

            memberCollection.RemoveMember(firstName, lastName);
            Console.WriteLine("Member removed successfully if they existed and had no borrowed DVDs.");
        }

        static void FindMemberContact()
        {
            Console.WriteLine("Enter first name of the member:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name of the member:");
            string lastName = Console.ReadLine();

            Member member = memberCollection.FindMember(firstName, lastName);
            if (member != null)
            {
                Console.WriteLine($"Contact number for {firstName} {lastName} is {member.ContactNumber}");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        static void DisplayAllMovies()
        {
            movieCollection.DisplayAllMovies();
        }

        static void ViewMovieDetails()
        {
            Console.WriteLine("Enter movie title to view details:");
            string title = Console.ReadLine();

            Movie movie = movieCollection.GetMovie(title);
            if (movie != null)
            {
                movie.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }

        static void BorrowMovie(Member member)
        {
            Console.WriteLine("Enter title of the movie to borrow:");
            string title = Console.ReadLine();

            Movie movie = movieCollection.GetMovie(title);
            if (movie != null)
            {
                member.BorrowMovie(title);
                Console.WriteLine("Movie borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Movie not available.");
            }
        }
        static void ReturnMovie(Member member)
        {
            Console.WriteLine("Enter title of the movie to return:");
            string title = Console.ReadLine();

            member.ReturnMovie(title);
            Console.WriteLine("Movie returned successfully.");
        }
        static void ListBorrowedMovies(Member member)
        {
            Console.WriteLine("Movies currently borrowed:");
            member.ListBorrowedMovies();
        }

    }


    // Classes for Movie, MovieCollection, Member, and MemberCollection --------------------------------- Classes for Movie and Member
    public class Movie
    {
        // Properties for movie details
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public string Classification { get; private set; }
        public int Duration { get; private set; }
        public int Copies { get; private set; }

        // Constructor to initialize a new movie
        public Movie(string title, string genre, string classification, int duration, int copies)
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            Copies = copies;
        }

        public void AddCopies(int additionalCopies)
        {
            Copies += additionalCopies;
        }
        // Method to display movie information
        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Classification: {Classification}");
            Console.WriteLine($"Duration: {Duration} minutes");
            Console.WriteLine($"Copies available: {Copies}");
        }
    }            
    public class MovieCollection
    {
        private MovieNode[][] movies; // Using an array of arrays for buckets
        private int capacity = 1000;

        public MovieCollection()
        {
            movies = new MovieNode[capacity][];
            for (int i = 0; i < capacity; i++)
            {
                movies[i] = null; // Start with no chains
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
            if (movies[index] == null)
            {
                movies[index] = new MovieNode[1]; // Start with an initial size
                movies[index][0] = new MovieNode(movie);
            }
            else
            {
                // Check if the movie exists, if not add a new node
                for (int i = 0; i < movies[index].Length; i++)
                {
                    if (movies[index][i].Movie.Title == movie.Title)
                    {
                        return; // Movie already exists
                    }
                }
                int newSize = movies[index].Length + 1;
                MovieNode[] newBucket = new MovieNode[newSize];
                Array.Copy(movies[index], newBucket, movies[index].Length);
                newBucket[newSize - 1] = new MovieNode(movie);
                movies[index] = newBucket;
            }
        }

        public void RemoveMovie(string title)
        {
            int index = HashFunction(title);
            if (movies[index] != null)
            {
                int newSize = movies[index].Length - 1;
                MovieNode[] newBucket = new MovieNode[newSize];
                int j = 0;
                for (int i = 0; i < movies[index].Length; i++)
                {
                    if (movies[index][i].Movie.Title != title)
                    {
                        newBucket[j++] = movies[index][i];
                    }
                }
                if (j == newSize)
                    movies[index] = newBucket;
                else
                    movies[index] = null; // If no movies left, set to null
            }
        }

        public Movie GetMovie(string title)
        {
            int index = HashFunction(title);
            if (movies[index] != null)
            {
                foreach (var node in movies[index])
                {
                    if (node.Movie.Title == title)
                    {
                        return node.Movie;
                    }
                }
            }
            return null; // Movie not found
        }

        public void DisplayAllMovies()
        {
            foreach (var bucket in movies)
            {
                if (bucket != null)
                {
                    foreach (var movieNode in bucket)
                    {
                        movieNode.Movie.DisplayInfo();
                        Console.WriteLine(); // For better formatting
                    }
                }
            }
        }

        private class MovieNode
        {
            public Movie Movie { get; private set; }

            public MovieNode(Movie movie)
            {
                this.Movie = movie;
            }
        }
    }

    public class Member
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactNumber { get; private set; }
        public string Password { get; private set; }  // Ensure this property is present if used for authentication
        private List<string> borrowedMovies;

        public Member(string firstName, string lastName, string contactNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Password = password;
            borrowedMovies = new List<string>();
        }

        public void BorrowMovie(string title)
        {
            if (!borrowedMovies.Contains(title) && borrowedMovies.Count < 5)
            {
                borrowedMovies.Add(title);
            }
        }

        public void ReturnMovie(string title)
        {
            borrowedMovies.Remove(title);
        }

        public void ListBorrowedMovies()
        {
            foreach (var movie in borrowedMovies)
            {
                Console.WriteLine(movie);
            }
        }
    }

    public class MemberCollection
    {
        private List<Member> members = new List<Member>();

        public void AddMember(Member member)
        {
            if (!members.Any(m => m.FirstName == member.FirstName && m.LastName == member.LastName))
            {
                members.Add(member);
            }
        }

        public void RemoveMember(string firstName, string lastName)
        {
            members.RemoveAll(m => m.FirstName == firstName && m.LastName == lastName);
        }

        public Member FindMember(string firstName, string lastName)
        {
            return members.FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);
        }

        public void DisplayAllMembers()
        {
            foreach (var member in members)
            {
                Console.WriteLine($"Name: {member.FirstName} {member.LastName}, Contact: {member.ContactNumber}");
            }
        }
    }
}

