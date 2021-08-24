using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VirtualLibrary.Models;
using VirtualLibrary.Dtos;


namespace VirtualLibrary.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>();
        }
    }
}