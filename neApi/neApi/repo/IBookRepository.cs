using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using neApi.model;
using System.Text.Json;


namespace neApi.repo
{
    public interface IBookRepository
    {
        Task UpdateBookPatchAsync(JsonPatchDocument bookModel, int id);
        Task DeleteBookAsync( int BookId);
        Task AddBookAsync(Book books);
        Task<List<BookModel>> GetAllBookAsync();
        Task<BookModel> GetBookById(int id);
    }
}
