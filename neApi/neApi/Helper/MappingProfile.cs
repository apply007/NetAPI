using AutoMapper;
using neApi.model;

namespace neApi.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>(); // তোমার Model ও DTO map করো
            CreateMap<BookModel, Book>();
        }
    }
}
