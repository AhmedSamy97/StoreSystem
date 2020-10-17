using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Core;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategories_ForCategory(int id)
        {
            return Ok(await _unitOfWork.SubCategories.GetSubCategory_ForCategory(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddSubCategories_ForCategory(SubCategory subCategory)
        {
            if (!await _unitOfWork.SubCategories.AddSubcategory(subCategory))
                return BadRequest(new {Message = "Invalid name or Category ID"});
            
            _unitOfWork.Complete();
            return Ok(new {Message = "SubCategory Already Exists"});

        }

    }
}
