using System;
using AutoMapper;
using books.Dto;
using books.Model;

namespace books.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<BookModel, BookDto>().ReverseMap();
        CreateMap<CategoryModel, CategoryDto>().ReverseMap();
    }
}

