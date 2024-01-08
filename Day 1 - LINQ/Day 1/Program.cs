using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using static Day_1.SampleData;
namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Question 1 - Display book title and its ISBN.
            Console.WriteLine("Book title and its ISBN.");
            var bookTitleWithISBN = Books.Select(b => new { bookTitle = b.Title, bookISBN = b.Isbn });
            foreach (var item in bookTitleWithISBN)
                Console.WriteLine(item);
            Console.WriteLine("===========================");

            // Question 2 -	Display the first 3 books with price more than 25
            Console.WriteLine("The first 3 books with price more than 25");
            var booksWithSpecificPrice = Books.Where(b => b.Price > 25).Take(3);
            foreach (var item in booksWithSpecificPrice)
                Console.WriteLine(item);
            Console.WriteLine("===========================");

            // Question 3 - Display Book title along with its publisher name. (Using 2 methods).
            Console.WriteLine("First Method To Display Book title along with its publisher name");
            // Using Fluent LINQ Operators 
            var bookTitleWithPublisher = Books.Select(b => new { bookTitle = b.Title, PublisherName = b.Publisher.Name });
            foreach(var item in bookTitleWithPublisher)
                Console.WriteLine(item);

            Console.WriteLine("Second Method To Display Book title along with its publisher name");
            // Using Query Expression 
            bookTitleWithPublisher = from b in Books
                                     //from p in Publishers
                                     //where b.Publisher == p
                                     select new { bookTitle = b.Title, PublisherName = b.Publisher.Name };
            foreach (var item in bookTitleWithPublisher)
                Console.WriteLine(item);
            Console.WriteLine("===========================");


            // Question 4 - Find the number of books which cost more than 20.
            Console.WriteLine("Number of books which cost more than 20");
            var booksCountWithSpecificPrice = Books.Where(b => b.Price > 20).Count();
            Console.WriteLine(booksCountWithSpecificPrice);
            Console.WriteLine("===========================");

            // Question 5 - Display book title, price and subject name sorted by its subject name ascending
            // and by its price descending.
            Console.WriteLine("Book title, price and subject name sorted by its subject name ascending and by its price descending.");
            var orderingBooks = Books.Select(b => new { bookTitle = b.Title, b.Price, b.Subject })
                                     .OrderBy(b => b.Subject.Name)
                                     .ThenByDescending(b => b.Price);
            foreach(var item in orderingBooks)
                Console.WriteLine(item);
            Console.WriteLine("===========================");

            // Question 6 - Display all subjects with books related to this subject. (Using 2 methods).
            Console.WriteLine("All subjects with books related to this subject with first method");
            // Using Flunt Syntax
            var bookWithSubject = Books.Select(b => new { BookName = b, BookSubject = b.Subject.Name });
            foreach (var item in bookWithSubject)
                Console.WriteLine(item);
            Console.WriteLine("Display all subjects with books related to this subject with Second method");
            // Using Query syntax
            bookWithSubject = from b in Books
                              select new { BookName = b, BookSubject = b.Subject.Name };
            foreach (var item in bookWithSubject)
                Console.WriteLine(item);
            Console.WriteLine("===========================");

            // Question 7-	Try to display book title & price (from book objects) returned from GetBooks Function.
            Console.WriteLine("Book title & price (from book objects) returned from GetBooks Function");
            var bookTitleAndPrice = from b in GetBooks().OfType<Book>()
                                    select new { BookTitle = b.Title, BookPrice = b.Price };
            foreach (var item in bookTitleAndPrice)
                Console.WriteLine(item);
            Console.WriteLine("===========================");

            // Question 8 - Display books grouped by publisher & Subject.
            Console.WriteLine("Books grouped by publisher & Subject.");
            // Group books by Publisher
            var booksByPublisher = Books.GroupBy(book => book.Publisher.Name);
            // Group books by subject
            var booksBySubject =Books.GroupBy(book => book.Subject.Name);
            // Display books grouped by Publisher
            foreach (var group in booksByPublisher)
            {
                Console.WriteLine($"Publisher: {group.Key}");
                foreach (var book in group)
                {
                    Console.WriteLine($"- {book.Title}");
                }
                Console.WriteLine();
            }

            // Display books grouped by subject
            Console.WriteLine("Books grouped by subject:");
            foreach (var group in booksBySubject)
            {
                Console.WriteLine($"Subject: {group.Key}");
                foreach (var book in group)
                {
                    Console.WriteLine($"- {book.Title}");
                }
                Console.WriteLine();
            }



        }
    }
}