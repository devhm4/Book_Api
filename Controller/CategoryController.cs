using AutoMapper;
using books.Model;
using books.Repository.category;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace books.Controller
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatogories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var response = mapper.Map<IEnumerable<Dto.CategoryDto>>(categories);
            if (categories == null)
            {
                return NotFound();

            }
            return Ok(categories);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryModel category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
            return NoContent();
        }

    }
}
