using System;
using LibrarySystem.Core;
using LibrarySystem.Services;

class Program
{
    static void Main()
    {
        var service = new BookService();

        while (true)
        {
            Console.WriteLine("1. Adaugă carte");
            Console.WriteLine("2. Șterge carte");
            Console.WriteLine("3. Caută carte după titlu");
            Console.WriteLine("4. Împrumută carte");
            Console.WriteLine("5. Returnează carte");
            Console.WriteLine("6. Ieșire");
            Console.Write("Alege opțiunea: ");
            var opt = Console.ReadLine();

            try
            {
                switch (opt)
                {
                    case "1":
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Titlu: ");
                        string title = Console.ReadLine();
                        Console.Write("Autor: ");
                        string author = Console.ReadLine();
                        Console.Write("Cantitate: ");
                        int quantity = int.Parse(Console.ReadLine());

                        var book = new Book(id, title, author, quantity);
                        service.AddBook(book);
                        Console.WriteLine("Carte adăugată cu succes.");
                        break;

                    case "2":
                        Console.Write("Id carte de șters: ");
                        id = int.Parse(Console.ReadLine());
                        service.DeleteBook(id);
                        Console.WriteLine("Carte ștearsă cu succes.");
                        break;

                    case "3":
                        Console.Write("Caută după titlu: ");
                        title = Console.ReadLine();
                        var results = service.SearchByTitle(title);
                        Console.WriteLine("Rezultate căutare:");
                        foreach (var b in results)
                            Console.WriteLine($"{b.Id} - {b.Title} de {b.Author}, Cantitate: {b.Quantity}");
                        break;

                    case "4":
                        Console.Write("Id carte de împrumutat: ");
                        id = int.Parse(Console.ReadLine());
                        service.LendBook(id);
                        Console.WriteLine("Carte împrumutată cu succes.");
                        break;

                    case "5":
                        Console.Write("Id carte de returnat: ");
                        id = int.Parse(Console.ReadLine());
                        service.ReturnBook(id);
                        Console.WriteLine("Carte returnată cu succes.");
                        break;

                    case "6":
                        return; // iese din program

                    default:
                        Console.WriteLine("Opțiune invalidă.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare: " + ex.Message);
            }

            Console.WriteLine();
        }
    }
}
