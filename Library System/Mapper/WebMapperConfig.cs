using AutoMapper;
using Business.DTOs;
using Library_System.ViewModels;
using Services.DTOs;

namespace Library_System.Mapper
{
    public class WebMapperConfig: Profile
    {
        public WebMapperConfig() {
            CreateMap<AddAuthorViewModel, AuthorDTO>()
                .ReverseMap();
            CreateMap<GetAuthorDto, AddAuthorViewModel>();
                //.ForMember(dest=> dest.AuthorId, src => src.MapFrom(src=> src.AuthorId));
            CreateMap<GetAuthorDto, GetAuthorViewModel>()
                .AfterMap( (src, dest)=>
                {
                    dest.BooksCount =src.NumBooks;
                    dest.FullName = $"{src.FirstName} {src.SecondName} {src.ThirdName} {src.LastName}";
                } )
                .ForMember(dest => dest.Books, src => src.MapFrom(src => src.Books.Select(b => b.BookTitle)) );



            CreateMap<GetBookDTO, BookViewModel>();
            CreateMap<BookViewModel, AddBookDTO>();
        }
    }
}
