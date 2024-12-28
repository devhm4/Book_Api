using System;
using System.Net.Security;
using books.Enitity;
using books.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace books.Repository.category;


public class CategoryRepository : ICategoryRepository
{

    private readonly BookDbContext _context;

    public CategoryRepository(BookDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
    {
        return await _context.categories.ToListAsync();
    }


    public async Task AddCategoryAsync(CategoryModel category)
    {
        var result = await _context.categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var category = await _context.categories.FindAsync(id);
        _context.categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task GetCategoryByIdAsync(Guid id)
    {
        await _context.categories.FindAsync(id);
    }



    public async Task UpdateCategoryAsync(CategoryModel category)
    {
        _context.categories.Update(category);
        await _context.SaveChangesAsync();
    }


}



