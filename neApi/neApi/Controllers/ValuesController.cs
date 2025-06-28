using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using neApi.Data;
using neApi.model;
using neApi.repo;
using System.Text.Json;

namespace neApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly BookContext context;
        private readonly IBookRepository bookRepository;

        public ValuesController(BookContext context,IBookRepository bookRepository)
        {
            this.context = context;
            this.bookRepository = bookRepository;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
         var books=await bookRepository.GetAllBookAsync();

            return Ok(books);
        }

        [Route("get-all/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
          var book= await bookRepository.GetBookById(id);
            return Ok(book);
        }
    
        [Route("search")]
        [HttpGet]
        public string GetQuery(int? id,string? name,int? age,int? job)
        {
            return "Hello"+id+name+age+job;
        }


        [HttpPatch("{id}")]
      
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await bookRepository.UpdateBookPatchAsync(bookModel,id);
            return Ok();
        }
        [HttpDelete("{BookId}")]
      
        public async Task<IActionResult> DeleteBook( [FromRoute] int BookId)
        {
            await bookRepository.DeleteBookAsync(BookId);
            return Ok();
        } 

        [HttpPost("")]
      
        public async Task<IActionResult> AddBook( [FromBody] Book books)
        {
            if (ModelState.IsValid)
            {
                await bookRepository.AddBookAsync(books);
                return Ok();
            }
            return ValidationProblem();
          
        }
    }
}
