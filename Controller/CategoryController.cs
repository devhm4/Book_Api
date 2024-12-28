using AutoMapper;
using books.Model;
using books.Repository.category;
using books.Validation;
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
            if (response == null)
            {
                return NotFound();

            }
            return Ok(response);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddCategory([FromBody] AddCategory category)


        {
            var newCategore = new CategoryModel
            {
                Name = category.name
            };

            await _categoryRepository.AddCategoryAsync(newCategore);
            return Ok();
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
