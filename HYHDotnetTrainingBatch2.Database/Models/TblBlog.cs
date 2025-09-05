using System;
using System.Collections.Generic;

namespace HYHDotnetTrainingBatch2.WebAPI.Database.Models;

public partial class TblBlog
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
