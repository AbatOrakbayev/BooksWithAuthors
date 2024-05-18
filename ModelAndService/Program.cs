namespace ModelAndService
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title {  get; set; }
        public int AuthorId { get; set; }
        public Book(int Id,string? Title,int AuthorId)
        {
            this.Id = Id;
            this.Title = Title;
            this.AuthorId = AuthorId;
        }
    }
    public class  Author
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public Author(int Id,string? FullName)
        {
            this.Id= Id;
            this.FullName = FullName;
        }
    }
    internal class Program
    {
        public static void Jarayon(List<Book> books,List<Author> authors)
        {
            while (true)
            {
                Console.WriteLine("add book - 1");
                Console.WriteLine("add author - 2");
                Console.WriteLine("all book list - 3");
                Console.WriteLine("all author list - 4");
                Console.WriteLine("author written books list - 5");
                int command = Convert.ToInt32(Console.ReadLine());
                if (1<=command && command<=5)
                {
                    Create(command, authors, books);
                    Read(command, authors, books);
                }
                else
                {
                    Console.WriteLine("Bunday buyruq mavjud emas.");
                }
                yana:
                Console.WriteLine("Davom ettirilsinmi? +/-: ");
                string? c = Console.ReadLine();
                if (c == "+")
                {
                    continue;
                }
                else if(c == "-")
                {
                    Console.WriteLine("Yakunlandi.");
                    break;
                }
                else
                {
                    goto yana;
                }
            }
        }
        public static void Read(int command,List<Author> authors,List<Book> books)
        {
            if (command == 3)
            {
                if (!(books.Count == 0))
                {
                    Console.WriteLine("Id\tTitle\tAuthorId");
                    foreach (Book book in books)
                    {
                        Console.WriteLine($"{book.Id}\t{book.Title}\t{book.AuthorId}");
                    }
                }
                else
                {
                    Console.WriteLine("Ro'yxatda kitob mavjud emas!");
                }
            }
            else if(command == 4)
            {
                if (!(authors.Count == 0))
                {
                    Console.WriteLine("Id\tFullName");
                    foreach (Author author in authors)
                    {
                        Console.WriteLine($"{author.Id}\t{author.FullName}");
                    }
                }
                else
                {
                    Console.WriteLine("Ro'yxatda author mavjud emas!");
                }
            }
            else if(command == 5)
            {
                Console.WriteLine("Sizda mavjud Authors ro'yxati:");
                Console.WriteLine("Id\tFullName");
                foreach (Author author in authors)
                {
                    Console.WriteLine($"{author.Id}\t{author.FullName}");
                }
                Console.WriteLine("Siz qaysi author kitoblarini ko'rmoqchisiz? AuthorId: ");
                int authorId = Convert.ToInt32(Console.ReadLine());
                int a = 0;
                foreach (Author author in authors)
                {
                    if (authorId == author.Id)
                    {
                        Console.WriteLine($"{author.FullName} ning kitoblar ro'yxati.");
                        break;
                    }
                }
                Console.WriteLine("Id\tTitle\tAuthorId");
                foreach (Book book in books)
                {
                    if (authorId == book.AuthorId)
                    {
                        Console.WriteLine($"{book.Id}\t{book.Title}\t{book.AuthorId}");
                        a++;
                    }
                }
                if (a == 0)
                {
                    Console.WriteLine("Bu avtorning kitoblari mavjud emas.");
                }
            }
        }
        public static void Create(int command,List<Author> authors,List<Book> books)
        {
            if (command == 1)
            {
                Console.WriteLine("Qo'shmoqchi bo'lgan kitob ma'lumotlari?: ");
                Console.Write("Id?: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Title?: ");
                string? title = Console.ReadLine();
                Console.Write("AuthorId?: ");
                int authorId = Convert.ToInt32(Console.ReadLine());
                Book book = new Book(id, title,authorId);
                if (!books.Contains(book))
                {
                    books.Add(book);
                    Console.WriteLine("Kitob muvaffaqiyatli qo'shildi!");
                }
                else
                {
                    Console.WriteLine("Bu kitob avvaldan mavjud.");
                }
            }
            else if(command == 2)
            {
                Console.WriteLine("Qo'shmoqchi bo'lgan author ma'lumotlari?: ");
                Console.Write("Id?: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("FullName?: ");
                string? fullName = Console.ReadLine();
                Author author = new Author(id,fullName);
                if (!authors.Contains(author))
                {
                    authors.Add(author);
                    Console.WriteLine("Author muvaffaqiyatli qo'shildi.");
                }
                else
                {
                    Console.WriteLine("Bu author avvaldan mavjud.");
                }
            }
        }
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Author> authors = new List<Author>();
            Console.WriteLine("Assalomu Alaykum!");
            Jarayon(books,authors);
            Console.ReadKey();
        }
    }
}
