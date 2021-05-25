
using System.Threading;
using System.Threading.Tasks;
using ImPossibleFoundation.Blog;
using ImPossibleFoundation.Common;
using ImPossibleFoundation.Infrastructure.EntityFrameworkCore;

namespace ImPossibleFoundation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IArticleRepository ArticleRepository { get; set; }

        #region Constructors

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }


        public void Dispose()
        {
            Task.Run(() => context.DisposeAsync());
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        #endregion Constructors
    }
}