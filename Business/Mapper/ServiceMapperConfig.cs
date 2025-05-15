using AutoMapper;
using Business.DTOs;
using Domain.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class ServiceMapperConfig : Profile
    {
        public ServiceMapperConfig() 
        {
            CreateMap<Book, GetBookDTO>()
                .AfterMap((src, dest) => {
                    dest.BookId = src.Id;
                    dest.BookTitle = src.Title;
                    dest.AuthorName = src.Author.FullName;
                });
            CreateMap<AddBookDTO, Book>()
                .ForMember( (dest) => dest.Title, src => src.MapFrom(src=> src.BookTitle) );
            CreateMap<GetBookDTO, AddBookDTO>();

            CreateMap<AuthorDTO, Author>()
                .AfterMap((src, dest) => {
                    dest.Website = src.PersonalWebsite;
                    dest.Email = src.UserEmail;
                    dest.FullName = $"{src.FirstName} {src.SecondName} {src.ThirdName} {src.LastName}";
                });
            CreateMap<Author, GetAuthorDto>()
                .ForMember( dest => dest.Books, src => src.MapFrom(src => src.Books))
                .AfterMap( (src, dest) =>
                {
                    dest.FirstName = src.FullName.Split(' ')[0];
                    dest.SecondName = src.FullName.Split(' ')[1];
                    dest.ThirdName = src.FullName.Split(' ')[2]; 
                    dest.LastName = src.FullName.Split(' ')[3];
                    dest.AuthorId = src.Id;
                    dest.PersonalWebsite = src.Website;
                    dest.UserEmail = src.Email;
                    dest.NumBooks = src.Books.Count;
                });
        }
    }
}
