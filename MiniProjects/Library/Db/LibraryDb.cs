namespace MiniProjects.Library.Db;

public class LibraryDb
{
    private readonly List<Book> books = new List<Book>();


    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void DisplayAllBooks()
    {
        foreach (var book in books)
        {
            DisplayBook(book);
        }
    }

    public void SearchBook(string title)
    {
        var book = books.FirstOrDefault(b => b.Title == title);

        DisplayBook(book);

    }
    public void DisplayBook(Book book)
    {
        Console.WriteLine($"Book Title: {book.Title} \nAuthor: {book.Author} \nPublished: {book.Year}");
    }
}
