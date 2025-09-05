using HYHDotnetTrainingBatch2.WebAPI.DataAccess;
using HYHDotnetTrainingBatch2.WebAPI.Database.Models;
using System.Threading.Tasks;

namespace HYHDotnetTrainingBatch2.WebAPI.BusinessLogic
{
    public class BlogService
    {
        private readonly BlogDataAccess _blogDataAccess;

        public BlogService(BlogDataAccess blogDataAccess)
        {
            _blogDataAccess = blogDataAccess;
        }
        public async Task<List<TblBlog>> getBlogsAsync(int pageNo, int pageSize)
        {
            if(pageNo == 0)
            {
                throw new Exception("PageNo cannot be null.");
            }

            if(pageSize == 0)
            {
                throw new Exception("Page size cannot be null.");
            }

            return await _blogDataAccess.GetBlogsAsync(pageNo, pageSize);
        }

        public async Task<int> CreateBlogAsync(BlogRequest blogRequest)
        {
            if(blogRequest == null)
            {
                throw new Exception("Blog cannot be null.");
            }

             return await _blogDataAccess.CreateBlogAsync(blogRequest);
        }

        public async Task<int> UpdateBlogAsync(int blogId, UpdateBlogRequest updateBlogRequest)
        {
            if (updateBlogRequest == null)
            {
                throw new Exception("Blog cannot be null");
            }

            if(blogId == null)
            {
                throw new Exception("BlogId cannot be null.");
            }

            return await _blogDataAccess.UpdateBlogAsync(blogId, updateBlogRequest);
        }

        public async Task<int> UpsertBlogAsync(int blogId, BlogRequest blogRequest)
        {
            if (blogId == null)
            {
                throw new Exception("Blog id cannot be null.");
            }
            if(blogRequest == null)
            {
                throw new Exception("Blog cannot be null.");
            }
            return await _blogDataAccess.UpsertBlogAsync(blogId, blogRequest);
        }


        public async Task<int> DeleteBlogAsync(int blogId)
        {
            if(blogId == null || blogId == 0)
            {
                throw new Exception("Id cannot be null or zero.");
            }
            return await _blogDataAccess.DeleteBlogAsync(blogId);
        }
    }

   
}
