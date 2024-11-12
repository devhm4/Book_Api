using books.Dto;
using books.Model;

namespace books.Mapper;

public static class BookMapper
{

    public static BookDto toBookDto(this BookModel bookModel)
    {
        return new BookDto
        {
            id = bookModel.id,
            name = bookModel.name,
            author = bookModel.author,
            description = bookModel.description,
            Categories = bookModel.Categories.Select(c => c.toCategoryDto()).ToList()

        };
    }

}
