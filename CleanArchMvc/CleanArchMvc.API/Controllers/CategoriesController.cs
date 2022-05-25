using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetById([FromRoute] int id)
        {
            var categorie = await _categoryService.GetById(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        [HttpPost]

        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryRequest)
        {
            if (categoryRequest == null) 
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.Add(categoryRequest);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryRequest.Id }, categoryRequest);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Update([FromBody] CategoryDTO categoryRequest, int id)
        {
            if (id != categoryRequest.Id) 
            {
                return BadRequest();
            }

            if (categoryRequest == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.Update(categoryRequest);

            return Ok(categoryRequest);

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categorie = await _categoryService.GetById(id);

            if (categorie == null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.Remove(id);

            return Ok(categorie);
        }

    }
}
