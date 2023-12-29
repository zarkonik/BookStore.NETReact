﻿using Microsoft.EntityFrameworkCore;

namespace BookStoreZN.Services.BookService
{
    public class BookService : IBookService
    {

        private readonly DataContext _context;
        public BookService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
        public async Task<Book>? GetSingleBook(int id)
        {
            var book = await  _context.Books.FindAsync(id);
            if (book == null)
                return null;
            return book; 
        }
        public async Task<List<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>>? DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return null;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }



        public async Task<List<Book>>? UpdateBook(int id, Book request)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return null;
            book.Title = request.Title;
            book.Description = request.Description;
            book.Author = request.Author;
            book.Genre = request.Genre;
            book.Price = request.Price;
            

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
