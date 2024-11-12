using books.Mapper;
using books.Model;
using books.Repository;
using books.Repository.category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books.Controller
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatogories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryDto = categories.Select(s => s.toCategoryDto()).ToList();
            if (categoryDto == null)
            {
                return NotFound();
            }
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCatogories), new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {

            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetCategoryById(Guid id)
        // {
        //     var category = await _categoryRepository.GetCategoryByIdAsync(id);
        //     if (category == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(category);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryModel category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
            return NoContent();
        }

    }
}
