using MiniProjects.Library.Db;

namespace MiniProjects.Library;

public class LibraryProgram
{
    private readonly LibraryDb _db = new LibraryDb();
    bool runProgram = true;
    public void StartLibrary()
    {
        while (runProgram)
        {
            Console.Clear();
            int choice = 0;
            Console.WriteLine("Welcome to the Library Management System!\r\nChoose an option:\r\n1. Add a Book\r\n2. Display All Books\r\n3. Search for a Book by Title\r\n4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();
            LibraryManagement(choice);
        }
    }

    public void LibraryManagement(int choice)
    {
        switch (choice)
        {
            case 1:
                CreateBook();
                Console.ReadKey();
                break;
            case 2:
                _db.DisplayAllBooks();
                Console.ReadKey();
                break;
            case 3:
                SearchBook();
                Console.ReadKey();
                break;
            default:
                runProgram = false;
                break;

        }
    }

    public void CreateBook()
    {
        Console.Write("Name of book: ");
        string title = Console.ReadLine();
        Console.Write("Name of author: ");
        string author = Console.ReadLine();
        Console.Write("Year published: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("ISBN number: ");
        string isbn = Console.ReadLine();

        Book book = new Book { Title = title, Author = author, Year = year, ISBN = isbn };

        _db.AddBook(book);
        Console.WriteLine("Book added!");
    }

    public void SearchBook()
    {
        Console.Write("Title of the book: ");
        string title = Console.ReadLine();
        _db.SearchBook(title);
    }
}
