using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Core;
using LibrarySystem.Data;

namespace LibrarySystem.Services
{
    public class BookService
    {
        private readonly BookRepository _repository;
        private List<Book> _books;

        public BookService()
        {
            _repository = new BookRepository();
            _books = _repository.LoadBooks();
        }

        // CREATE - Adaugă o carte nouă
        public void AddBook(Book book)
        {
            // Verifică dacă există deja carte cu același Id
            if (_books.Any(b => b.Id == book.Id))
                throw new InvalidOperationException("Book with this ID already exists.");

            _books.Add(book);
            _repository.SaveBooks(_books);
        }

        // READ - Obține toate cărțile
        public List<Book> GetAllBooks()
        {
            return _books;
        }

        // READ - Caută după titlu (parțial, case-insensitive)
        public List<Book> SearchByTitle(string title)
        {
            return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // READ - Caută după autor (parțial, case-insensitive)
        public List<Book> SearchByAuthor(string author)
        {
            return _books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // READ - Caută după titlu și autor împreună
        public List<Book> Search(string title, string author)
        {
            return _books.Where(b =>
                b.Title.Contains(title, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // UPDATE - Modifică detaliile unei cărți după Id
        public void UpdateBook(Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book == null)
                throw new InvalidOperationException("Book not found.");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Quantity = updatedBook.Quantity;

            _repository.SaveBooks(_books);
        }

        // DELETE - Șterge o carte după Id
        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new InvalidOperationException("Book not found.");

            _books.Remove(book);
            _repository.SaveBooks(_books);
        }

        // Lend (Împrumută o carte) - scade cantitatea cu 1 dacă disponibilă
        public void LendBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new InvalidOperationException("Book not found.");

            if (book.Quantity <= 0)
                throw new InvalidOperationException("Book out of stock.");

            book.Quantity--;
            _repository.SaveBooks(_books);
        }

        // Return (Returnează o carte) - crește cantitatea cu 1
        public void ReturnBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new InvalidOperationException("Book not found.");

            // Optional: poți adăuga o limită maximă, dar de obicei nu e nevoie
            book.Quantity++;
            _repository.SaveBooks(_books);
        }

        // Verifică disponibilitatea unei cărți (dacă există și dacă e în stoc)
        public bool IsAvailable(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book != null && book.Quantity > 0;
        }
    }
}
