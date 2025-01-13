using System;
using books.Model;

namespace books.Repository.category;

public interface ICategoryRepository
{

    Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();

    Task GetCategoryByIdAsync(Guid id);
    Task AddCategoryAsync(CategoryModel category);
    Task UpdateCategoryAsync(CategoryModel book);
    Task DeleteCategoryAsync(Guid id);


}
