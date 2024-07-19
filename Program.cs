using System.Threading.Channels;
using MovieApplication.Models;
namespace MovieApplication
{
    internal class Program
    {
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            DisplayMovieMenu();
        }

        static void DisplayMovieMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Movie Application\n" +
                    "What do you wish to do ?\n" +
                    "1 . Add new Movie \n" +
                    "2 . Display All Movies \n" +
                    "3 . Find Movie By Id \n" +
                    "4 . Remove Movie by Name \n" +
                    "5 . Clear All Movies \n" +
                    "6 . Exit");

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }

        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewMovie();
                    break;

                case 2:
                    if (movies.Count == 0)
                        Console.WriteLine("Nothing to Display as there are no movies in List !!!");
                    else
                        movies.ForEach(movie => Console.WriteLine(movie));
                    break;

                case 3:
                    Movie findMovie = FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Movie does not exist in the List");
                    break;

                case 4:
                    RemoveMovieByName();
                    break;

                case 5:
                    if (movies.Count == 0)
                        Console.WriteLine("Nothing to Clear as there are no movies in List !!!");
                    else
                    {
                        movies.Clear();
                        Console.WriteLine("Cleared all movies successfully");
                    }
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice");
                    break ;
            }
        }

        static Movie AddNewMovie()
        {
            if (movies.Count > 5)
            {
                Console.WriteLine("Capacity exceeded ! Cant add movies");
                return null;
            }
            else
            {
                Console.WriteLine("Enter your Movie Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Movie Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your Movie Genre ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter the year of release");
                int year = Convert.ToInt32(Console.ReadLine());

                Movie newMovie = Movie.CreateNewMovieEntry(id, name, genre, year);
                movies.Add(newMovie);
                Console.WriteLine("MOVIE ADDED SUCCESSFULLY !!!");
                return newMovie;
            }
        }

        static Movie FindMovieById()
        {
            Movie findMovie = null;
            Console.WriteLine("Enter your Movie Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            findMovie = movies.Where(item => item.Id==id).FirstOrDefault();
            return findMovie;
        }

        static Movie FindMovieByName()
        {
            Movie findMovie = null;
            Console.WriteLine("Enter your Movie Name:");
            string name = Console.ReadLine();
            findMovie = movies.Where(item => item.Name == name).FirstOrDefault();
            return findMovie;
        }

        static void RemoveMovieByName()
        {
            Movie findMovie = FindMovieByName();
            if(findMovie==null)
                Console.WriteLine("Movie does not exist");
            else
            {
                movies.Remove(findMovie);
                Console.WriteLine("Movie Removed Successfully");
            }
        }


    }
}
