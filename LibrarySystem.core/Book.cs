using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core
{
    public class Book
    {
        public int Id { get; set; }            // ID unic
        public string Title { get; set; }      // Titlul cărții
        public string Author { get; set; }     // Autorul
        public int Quantity { get; set; }      // Câte exemplare sunt disponibile

        // Constructor opțional pentru inițializare rapidă
        public Book(int id, string title, string author, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            Quantity = quantity;
        }

        // Constructor fără parametri (necesar pentru serializare JSON)
        public Book() { }
    }
}
