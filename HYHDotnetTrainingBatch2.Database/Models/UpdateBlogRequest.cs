using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYHDotnetTrainingBatch2.WebAPI.Database.Models
{
    public class UpdateBlogRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool DeleteFlag { get; set; }

    }
}
