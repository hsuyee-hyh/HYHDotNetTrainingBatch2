using HYHDotnetTrainingBatch2.WebAPI.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYHDotnetTrainingBatch2.WebAPI.DataAccess
{
    public class BlogDataAccess
    {
        private readonly AppDbContext _db;

        public BlogDataAccess(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TblBlog>> GetBlogsAsync(int pageNo, int pageSize)
        {
            return await _db.TblBlogs
                .Skip((pageNo -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();    
        }

        public async Task<int> CreateBlogAsync(BlogRequest blogRequest)
        {
            var blog = new TblBlog
            {
                Title = blogRequest.Title,
                Description = blogRequest.Description,
                Author = blogRequest.Author,
                DeleteFlag = false,
            };
             await _db.TblBlogs.AddAsync(blog);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateBlogAsync(int blogId, UpdateBlogRequest updateBlogRequest)
        {
          
            // find blog
            TblBlog item = await _db.TblBlogs.FirstOrDefaultAsync(x => x.Id == blogId);
            if(item == null)
            {
                throw new Exception("Blog not found.");
            }

            // update
            item.Title = updateBlogRequest.Title;
            item.Description = updateBlogRequest.Description;
            item.Author = updateBlogRequest.Author;
            item.DeleteFlag = false;

            return await _db.SaveChangesAsync();
        }


        public async Task<int> UpsertBlogAsync(int blogId, BlogRequest blogRequest)
        {
            // find
            var item = await _db.TblBlogs.FirstOrDefaultAsync(x => x.Id == blogId);

            // create if not found
            if(item == null)
            {
                var blog = new TblBlog
                {
                    Title = blogRequest.Title,
                    Description = blogRequest.Description,
                    Author = blogRequest.Author,
                    DeleteFlag = false,
                };
                await _db.TblBlogs.AddAsync(blog);
                return await _db.SaveChangesAsync();
            }

            // update found item
            item.Title = blogRequest.Title;
            item.Description = blogRequest.Description;
            item.Author = blogRequest.Author;

            return await _db.SaveChangesAsync();

        }

        // hard delete
        public async Task<int> DeleteBlogAsync(int blogId)
        {
            var item = await _db.TblBlogs.FirstOrDefaultAsync(x => x.Id == blogId);
            if(item == null)
            {
                throw new Exception("blog not found");
            }

            _db.TblBlogs.Remove(item);
            return await _db.SaveChangesAsync();
        }
    }
  
}
