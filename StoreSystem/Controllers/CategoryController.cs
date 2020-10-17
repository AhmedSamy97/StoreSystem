using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _unitOfWork.Categories.GetCategories());
        }

        public async Task<IActionResult> AddCategory(Category category)
        {
            if (await _unitOfWork.Categories.Add(category))
                return BadRequest(new {Message = "This Category Already Exist Please Choose Another Name !"});
           //Save Category 
            _unitOfWork.Complete();
            return Ok(new {Message="Category Add Successfully "});
        }
    }
}