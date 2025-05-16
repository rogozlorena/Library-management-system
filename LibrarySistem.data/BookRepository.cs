using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibrarySystem.Core;



namespace LibrarySystem.Data
{
    public class BookRepository
    {
        private readonly string _filePath = "books.json"; // fișierul unde salvăm

        // Încarcă cărțile din fișier JSON
        public List<Book> LoadBooks()
        {
            if (!File.Exists(_filePath))
                return new List<Book>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        // Salvează cărțile în fișier JSON
        public void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
