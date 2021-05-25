using System;
using System.Threading;
using System.Threading.Tasks;
using ImPossibleFoundation.Blog;
using Microsoft.EntityFrameworkCore;

namespace ImPossibleFoundation.Data
{
    public interface IAppDbContext
    {
        DbSet<Article> Articles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}