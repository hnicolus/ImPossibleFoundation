using System;
using System.Threading;
using System.Threading.Tasks;
using ImPossibleFoundation.Blog;

namespace ImPossibleFoundation.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}