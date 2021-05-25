using System;
using ImPossibleFoundation.Blog;
using Microsoft.EntityFrameworkCore;

namespace ImPossibleFoundation.Data
{
    public interface IAppDbContext
    {
        DbSet<Article> Articles { get; set; }
    }
}