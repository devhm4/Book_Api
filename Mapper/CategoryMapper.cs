using System;
using books.Dto;
using books.Model;

namespace books.Mapper;

public static class CategoryMapper
{

    public static CategoryDto toCategoryDto(this CategoryModel category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
        };
    }


}
