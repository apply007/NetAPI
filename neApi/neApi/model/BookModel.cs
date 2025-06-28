using System.ComponentModel.DataAnnotations;

namespace neApi.model
{
    public class BookModel
    {
        public int BookId { get; set; }
       
        public string? Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
