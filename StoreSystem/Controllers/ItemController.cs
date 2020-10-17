using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{subCategoryID}")]
        public async Task<IEnumerable<Item>> GetAllItemsPerSubCategory(int subCategoryID)
        {
            return await _unitOfWork.Items.GetAllItemOfSpecificSubCategory(subCategoryID);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            if (!await _unitOfWork.Items.AddNewItem(item))
            {
                return BadRequest(
                    new {Message = "SubCategory And Price Per Unit Already Exist Try To Update Quantity"});
            }
            _unitOfWork.Complete();
            return Ok(new {Message="Subcategory Add SuccessFully"});
        }
    }
}
