using HYHDotnetTrainingBatch2.WebAPI.BusinessLogic;
using HYHDotnetTrainingBatch2.WebAPI.DataAccess;
using HYHDotnetTrainingBatch2.WebAPI.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HYHDotnetTrainingBatch2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;
        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{PageNo}/{PageSize}")]
        public async Task<IActionResult> GetBlogsAsync(int PageNo, int PageSize)
        {
            var list = await _blogService.getBlogsAsync(PageNo, PageSize);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogAsync(BlogRequest blogRequest)
        {
            int result = await _blogService.CreateBlogAsync(blogRequest);
            if (result ==0)
            {
                return BadRequest("Failed to create blog.");
            }

            return Ok("Create successful");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBlogAsync(int id,UpdateBlogRequest updateBlogRequest)
        {
            if(id == null)
            {
                return BadRequest("Id cannot be null.");
            }
            int result =await _blogService.UpdateBlogAsync(id, updateBlogRequest);
            if (result == 0)
            {
                return BadRequest("Fail to update blog.");
            }
            return Ok("Update successful");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpsertBlogAsync(int id, BlogRequest blogRequest)
        {
            int result = await _blogService.UpsertBlogAsync(id, blogRequest);
            if(result == 0)
            {
                return BadRequest("Failed to put the blog");
            }
            return Ok("Upsert successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogAsync(int id)
        {
            var result = await _blogService.DeleteBlogAsync(id);
            if (result == 0)
            {
                return BadRequest("Failed to delete");
            }
            return Ok("Delete success");
        }

    }


   

}
