using System.Reflection;

namespace task_3 
{
    public class Book
    {
        public string Title;
        public string Author;
        public string TSBN;
        public bool Isavalable;


        public Book(string title, string author, string tSBN, bool isavalable)
        {
            Title = title;
            Author = author;
            TSBN = tSBN;
            Isavalable = true;
        }
    }
    public class Library
    {
        public List<Book> Books = new List<Book>();



        public void Addbook(Book book)
        {
            Books.Add(book);

        }



        public bool Searchbook(string title, string author)
        {
            bool exist = true;
            for (int i = 0; i < Books.Count; i++)

                if (Books[i].Title == title || Books[i].Author == author)
                {
                    return exist;

                }
            return !exist;

        }
        public void BorrowBook(string title)
        {
            for (int i = 0; i < Books.Count; i++)

                if (Books[i].Title == title)
                {
                    if (Books[i].Isavalable)
                    {
                        Books[i].Isavalable = false;
                        Console.WriteLine("Borrowed successful ");
                    }
                    else
                    {
                        Console.WriteLine("it  is already Borrow");
                    }
                }


            Console.WriteLine("Book not found");


        }
        public void ReturnBook(string title)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Title == title)
                {


                    Books[i].Isavalable = true;

                    Console.WriteLine("Book return successful");

                }

            }

            Console.WriteLine("Book not found");

        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("c++", "Ahmed", "dhgt", true);
            Book book2 = new Book("c#", "ascss", "mkjut", true);
            Book book3 = new Book("java", "addd", "nhygt", true);
            Book book4 = new Book("python", "ayyy", "mkjnt", true);

            Library library = new Library();
            int choice;
            string title;
            string author;


            do
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Title: ");
                    title = Console.ReadLine();

                    Console.Write("Author: ");
                    author = Console.ReadLine();

                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();


                    library.Addbook(book1);
                    library.Addbook(book2);
                    library.Addbook(book3);
                    library.Addbook(book4);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Title or Author: ");

                    title = Console.ReadLine();
                    author = Console.ReadLine();


                    library.Searchbook(title, author);
                }
                else if (choice == 3)
                {
                    Console.Write("Enter book title to borrow: ");
                    title = Console.ReadLine();
                    library.BorrowBook(title);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter book title to return: ");
                    title = Console.ReadLine();
                    library.ReturnBook(title);
                }

            } while (choice != 5);

            Console.WriteLine("Program Ended.");

        }


    }
}
