using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace neApi.model
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Field is empty")]
        public string? Title { get; set; }=string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }
}
