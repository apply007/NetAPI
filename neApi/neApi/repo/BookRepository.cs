using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using neApi.Data;
using neApi.Migrations;
using neApi.model;
using System.Net;
using System.Text.Json;

namespace neApi.repo
{
    public class BookRepository:IBookRepository
    {
        private readonly BookContext context;
        private readonly IMapper mapper;

        public BookRepository(BookContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task  UpdateBookPatchAsync(JsonPatchDocument bookModel, int id)
        {
            var book=await context.Books.FindAsync(id);
            if (book != null) { 

                bookModel.ApplyTo(book);
               context.SaveChanges();
            }

           
        }  
        
        public async Task  DeleteBookAsync( int BookId)
        {
            var book=await context.Books.SingleOrDefaultAsync(b=>b.BookId==BookId);
            var n = book;
            if (book == null) {
                throw new Exception();
            }
                 context.Books.Remove(book);
             await   context.SaveChangesAsync();

           
        }
        
        public async Task  AddBookAsync( Book books)
        {

            var book=await context.Books.AddAsync(books);    
             await   context.SaveChangesAsync();

        }
        public async Task<List<BookModel>> GetAllBookAsync( )
        {

            var books=await context.Books.ToListAsync();

            return mapper.Map<List<BookModel>>(books);
        } 
        
        public async Task<BookModel> GetBookById(int id)
        {

            var book = await context.Books.Where(b => b.BookId == id).Select(b => new Book() { BookId = b.BookId,Title=b.Title,Description=b.Description }).SingleAsync();

            return mapper.Map<BookModel>(book);
        }

    }
}
