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
                Console.Clear(); // Clear the console
                Console.ForegroundColor = ConsoleColor.Yellow; // Change the text color to Yellow
                Console.WriteLine("                         ___________");
                Console.WriteLine("                        /           ),");
                Console.WriteLine("                       /    DVDS   /,");
                Console.WriteLine("                      /           //");
                Console.WriteLine("                     /__________ //");
                Console.WriteLine("                    (___________(/");
                Console.ResetColor(); // Reset the color to default
                Console.ForegroundColor = ConsoleColor.Cyan; // Change the text color to Cyan
                Console.WriteLine("#############################################################");
                Console.WriteLine("## Welcome to the Community Library DVD Management System! ##");
                Console.WriteLine("#############################################################");
                Console.ResetColor(); // Reset the color to default
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Staff Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice ===> ");
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

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option, please choose 1 for Staff or 2 for Member.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
        static void AuthenticateStaff()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (username == "staff" && password == "1") // IMPORTANT CHANGE LATER =============================== HERE3
            {
                StaffMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Authentication failed. Please try again.");
                Console.ResetColor();
                Thread.Sleep(2000);

            }
        }

        static void AuthenticateMember()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Member member = memberCollection.FindMember(firstName, lastName);
            if (member != null && member.Password == password)
            {
                MemberMenu(member);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Authentication failed or member not found.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }
        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
        static void StaffMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear(); // Clear the console
                Console.ForegroundColor = ConsoleColor.Blue; // Change the text color to Green
                Console.WriteLine("     ####################");
                Console.WriteLine("     #    Staff Menu    #");
                Console.WriteLine("     ###################");
                Console.WriteLine("=============================");
                Console.ResetColor(); // Reset the color to default
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Remove Movie");
                Console.WriteLine("3. Register Member");
                Console.WriteLine("4. Remove Member");
                Console.WriteLine("5. Find Member Contact");
                Console.WriteLine("6. List Borrowers of a Movie"); // New option
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice ===> ");
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
                        ListBorrowersOfMovie();
                        break;
                    case "7":
                        running = false;
                        break;
                    case "00":
                        DisplayAllMovies();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option, please try again.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                }
            }
        }


        static void MemberMenu(Member member)
        {
            bool running = true;
            while (running)
            {
                Console.Clear(); // Clear the console
                Console.ForegroundColor = ConsoleColor.Blue; // Change the text color to Green
                Console.WriteLine("     #####################");
                Console.WriteLine("     #    Member Menu    #");
                Console.WriteLine("     #####################");
                Console.WriteLine("=============================");
                Console.ResetColor(); // Reset the color to default
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option, please try again.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
    static void AddMovie()
    {   
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("     #####################");
        Console.WriteLine("     #     Add Movie    #");
        Console.WriteLine("     #####################");
        Console.ResetColor();
        Console.WriteLine("=============================");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter movie title: ");
        Console.ResetColor();
        string title = Console.ReadLine();
        if (string.IsNullOrEmpty(title))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title cannot be empty.");
            Console.ResetColor();
            Thread.Sleep(1000);
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter number of copies: ");
        Console.ResetColor();
        int copies;
        while (!int.TryParse(Console.ReadLine(), out copies) || copies < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a non-negative number for the copies.");
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        if (copies == 0)
        {   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cannot add a movie with zero copies.");
            Console.ResetColor();
            Thread.Sleep(2000);
            return;
        }

        Movie existingMovie = movieCollection.GetMovie(title);
        if (existingMovie != null)
        {
            
            existingMovie.AddCopies(copies); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Additional copies added successfully."); 
            Console.ResetColor();
            Thread.Sleep(2000);
            return;
        }
        string genre;
        while (true)
        {   Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose genre:");
            Console.ResetColor();
            Console.WriteLine("1: Drama");
            Console.WriteLine("2: Adventure");
            Console.WriteLine("3: Family");
            Console.WriteLine("4: Action");
            Console.WriteLine("5: Sci-fi");
            Console.WriteLine("6: Comedy");
            Console.WriteLine("7: Animated");
            Console.WriteLine("8: Thriller");
            Console.WriteLine("9: Other");
            Console.Write("Enter your choice ===> ");
            string genreChoice = Console.ReadLine();
            switch (genreChoice)
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
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please select a valid genre.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
            }
            break;
        }

        string classification;
        while (true)
        {   
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose classification:");
            Console.ResetColor();
            Console.WriteLine("1: General (G)");
            Console.WriteLine("2: Parental Guidance (PG)");
            Console.WriteLine("3: Mature (M15+)");
            Console.WriteLine("4: Mature Accompanied (MA15+)");
            Console.Write("Enter your choice ===> ");
            string classificationChoice = Console.ReadLine();
            switch (classificationChoice)
            {
                case "1": classification = "G"; break;
                case "2": classification = "PG"; break;
                case "3": classification = "M15+"; break;
                case "4": classification = "MA15+"; break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option, please try again.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    continue;
            }
            break;
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter duration in minutes: ");
        Console.ResetColor();
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Invalid input. Please enter a number for the duration.");
        }

        Movie movie = new Movie(title, genre, classification, duration, copies);
        movieCollection.AddMovie(movie);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Movie added successfully.");
        Console.ResetColor();
        Thread.Sleep(2000);

    }

        // Placeholder methods for actions in the menu ------------------------------------------------------ Methods for StaffMenu
       static void RemoveMovie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #    Remove Movie    #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter movie title to remove: ");
            Console.ResetColor();
            string title = Console.ReadLine();
            
            Movie movie = movieCollection.GetMovie(title);
            if (movie == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie not found.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Current number of copies: {movie.Copies}");
            Console.Write("Enter the number of copies to remove: ");
            Console.ResetColor();
            
            
            int copiesToRemove;
            while (!int.TryParse(Console.ReadLine(), out copiesToRemove) || copiesToRemove <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number for the copies.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }

            if (copiesToRemove > movie.Copies)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot remove more copies than available.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            movie.AddCopies(-copiesToRemove); // Subtracting copies

            if (movie.Copies == 0)
            {
                movieCollection.RemoveMovie(title);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("All copies REMOVED. Movie information deleted from the system. Please wait until the next update.");
                Console.ResetColor();
                Thread.Sleep(4000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Remaining number of copies: {movie.Copies}");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }



       static void RegisterMember() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #  Register Member  #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter first name: ");
            Console.ResetColor();
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter last name: ");
            Console.ResetColor();
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Last name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            // Check if the member already exists
            if (memberCollection.FindMember(firstName, lastName) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Member already exists.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            string contactNumber;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter contact number: ");
                Console.ResetColor();
                contactNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(contactNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Contact number cannot be empty.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                else if (contactNumber.Length != 1 || !contactNumber.All(char.IsDigit)) // IMPORTANT CHANGE LATER =============================== HERE 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid contact number. Please enter a 10-digit numeric contact number.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                else
                {
                    break;
                }
            }

            string password;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Set a 4-digit password: ");
                Console.ResetColor();
                password = Console.ReadLine();
                if (password.Length == 4 && int.TryParse(password, out _))
                {
                    break;
                }
                else
                {   Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid password. Please enter a 4-digit numeric password.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }

            Member member = new Member(firstName, lastName, contactNumber, password);
            memberCollection.AddMember(member);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Member registered successfully.");
            Console.ResetColor();
            Thread.Sleep(2000);
        }


        static void RemoveMember()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #    Remove Member    #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");
            
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter first name of member to remove: ");
            Console.ResetColor();
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter last name of member to remove: ");
            Console.ResetColor();
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Last name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Member member = memberCollection.FindMember(firstName, lastName);

            if (member != null)
            {
                if (member.GetBorrowedMovies().Length == 0)
                {
        
                    memberCollection.RemoveMember(firstName, lastName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Member removed successfully.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot remove member. They have borrowed DVDs.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Member not found.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }


        static void FindMemberContact()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #Find Member Contact#");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter first name of the member: ");
            Console.ResetColor();
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter last name of the member: ");
            Console.ResetColor();
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Last name cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Member member = memberCollection.FindMember(firstName, lastName);
            if (member != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Contact number for {firstName} {lastName} is {member.ContactNumber}");
                Console.Write("Press Enter to continue...");  // Prompt the user to press Enter
                Console.ReadLine();  // Waits for the user to press Enter
                
            }
            else
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Member not found.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }

        static void DisplayAllMovies()
        {   
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #  All Movies List  #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");
            movieCollection.DisplayAllMovies();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        static void ViewMovieDetails()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #  Movies Details   #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter movie title to view details: ");
            Console.ResetColor();
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Title cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Movie movie = movieCollection.GetMovie(title);
            if (movie != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                movie.DisplayInfo();
                Console.ResetColor();
                Console.Write("Press Enter to continue...");  
                Console.ReadLine();  

            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }
         static void ListBorrowedMovies(Member member)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #  Borrowed Movies  #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");
            
            Console.WriteLine("Movies currently borrowed:");
            Console.ForegroundColor = ConsoleColor.Blue;
            member.ListBorrowedMovies();
            Console.ResetColor();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        static void ListBorrowersOfMovie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #  List Borrowers   #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter movie title to list borrowers: ");
            Console.ResetColor();
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Title cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Movie movie = movieCollection.GetMovie(title);
            if (movie == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie not found.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine($"Listing borrowers of the movie: {title}");
            bool borrowersFound = false;

            foreach (var member in memberCollection.GetAllMembers())
            {
                if (member.HasBorrowedMovie(title))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{member.FirstName} {member.LastName}");
                    Console.ResetColor();
                    Console.Write("Press Enter to continue...");  // Prompt the user to press Enter
                    Console.ReadLine();  // Waits for the user to press Enter
                    borrowersFound = true;
                }

            }

            if (!borrowersFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No members are currently borrowing this movie.");
                Console.ResetColor();
                Thread.Sleep(4000);
            }

        }

       static void BorrowMovie(Member member)
        {
            if (member.GetBorrowedMovies().Length >= 5)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cannot borrow more than 5 movies at a time.");
                Console.ResetColor();
                Thread.Sleep(3000);
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####################");
            Console.WriteLine("     #   Borrow a Movie  #");
            Console.WriteLine("     #####################");
            Console.ResetColor();
            Console.WriteLine("=============================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter title of the movie to borrow:");
            Console.ResetColor();
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Title cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Movie movie = movieCollection.GetMovie(title);

            if (movie != null)
            {
                if (movie.Copies > 0)
                {
                    if (!member.HasBorrowedMovie(title))
                    {
                        member.BorrowMovie(title);
                        movie.AddCopies(-1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Movie borrowed successfully.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have already borrowed this movie.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot borrow the movie. There are no available copies.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie not available.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }


        static void ReturnMovie(Member member)
        {
            Console.WriteLine("Enter title of the movie to return:");
            string title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Title cannot be empty.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            Movie movie = movieCollection.GetMovie(title);

            if (movie != null)
            {
                if (member.HasBorrowedMovie(title))
                {
                    member.ReturnMovie(title);
                    movie.AddCopies(1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Movie returned successfully.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You haven't borrowed this movie.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Movie not found in the collection.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
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
                bool movieFound = false;

                for (int i = 0; i < movies[index].Length; i++)
                {
                    if (movies[index][i].Movie.Title != title)
                    {
                        newBucket[j++] = movies[index][i];
                    }
                    else
                    {
                        movieFound = true;
                    }
                }

                if (movieFound && j == 0)
                {
                    movies[index] = null; // If no movies left, set to null
                }
                else if (movieFound)
                {
                    movies[index] = newBucket;
                }

                Console.WriteLine("Movie removed successfully if it existed.");
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
        public string Password { get; private set; }
        private string[] borrowedMovies;
        private int movieCount;

        public Member(string firstName, string lastName, string contactNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Password = password;
            borrowedMovies = new string[5];  // Maximum of 5 borrowed movies as per previous logic
            movieCount = 0;
        }

        public void BorrowMovie(string title)
        {
            if (movieCount < borrowedMovies.Length && !HasMovie(title))
            {
                borrowedMovies[movieCount++] = title;
            }
        }

        public string[] GetBorrowedMovies()
        {
            return borrowedMovies.Take(movieCount).ToArray();
        }

        public bool HasBorrowedMovie(string title)
        {
            return borrowedMovies.Contains(title);
        }


        private bool HasMovie(string title)
        {
            for (int i = 0; i < movieCount; i++)
            {
                if (borrowedMovies[i] == title)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReturnMovie(string title)
        {
            for (int i = 0; i < movieCount; i++)
            {
                if (borrowedMovies[i] == title)
                {
                    for (int j = i; j < movieCount - 1; j++)
                    {
                        borrowedMovies[j] = borrowedMovies[j + 1];
                    }
                    borrowedMovies[--movieCount] = null;  // Clear the last element and reduce count
                    break;
                }
            }
        }

        public void ListBorrowedMovies()
        {
            for (int i = 0; i < movieCount; i++)
            {
                Console.WriteLine(borrowedMovies[i]);
            }
        }
    }


    public class MemberCollection
    {
        private Member[] members;
        private int count;

        public MemberCollection()
        {
            members = new Member[10]; // Starting with an initial capacity
            count = 0;
        }

        public void AddMember(Member member)
        {
            if (FindMemberIndex(member.FirstName, member.LastName) == -1)
            {
                if (count == members.Length)
                {
                    Resize(); // Resize the array if the capacity is reached
                }
                members[count++] = member;
            }
        }

        private void Resize()
        {
            Member[] newMembers = new Member[members.Length * 2];
            Array.Copy(members, newMembers, members.Length);
            members = newMembers;
        }

        public void RemoveMember(string firstName, string lastName)
        {
            int index = FindMemberIndex(firstName, lastName);
            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    members[i] = members[i + 1];
                }
                members[--count] = null; // Decrease count and remove the last element
            }
        }

        private int FindMemberIndex(string firstName, string lastName)
        {
            for (int i = 0; i < count; i++)
            {
                if (members[i].FirstName == firstName && members[i].LastName == lastName)
                {
                    return i;
                }
            }
            return -1;
        }

        public Member FindMember(string firstName, string lastName)
        {
            int index = FindMemberIndex(firstName, lastName);
            if (index != -1)
            {
                return members[index];
            }
            return null;
        }

        public void DisplayAllMembers()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Name: {members[i].FirstName} {members[i].LastName}, Contact: {members[i].ContactNumber}");
            }
        }
        public Member[] GetAllMembers()
        {
            return members.Take(count).ToArray(); // Return only the active members
        }

    }
}

