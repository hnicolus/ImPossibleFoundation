using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ImPossibleFoundation.Common;
using ImPossibleFoundation.Common.Exceptions;
using ImPossibleFoundation.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImPossibleFoundation.Blog
{
    public class ArticleRepository : IRepository<Article, Guid>
    {
        private readonly AppDbContext db;

        public ArticleRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Article>> GetAllAsync(Expression<Func<Article, bool>> filter = null, Func<IQueryable<Article>, IOrderedQueryable<Article>> order = null, string includeDetails = null)
        {
            var result = await db.Articles.ToListAsync();
            return result;
        }

        public async Task<Article> GetAsync(Guid id)
        {
            return await db.Articles.FindAsync(id);
        }

        public Task<Article> GetFirstOrDefaultAsync(Expression<Func<Article, bool>> filter = null, string includeDetails = null)
        {
            return db.Articles.FirstOrDefaultAsync(filter);
        }

        public async Task<Article> InsertAsync(Article entity)
        {
            await db.Articles.AddAsync(entity);
            return entity;
        }

        public async Task<Article> RemoveAsync(Guid id)
        {
            var result = await db.Articles.FindAsync(id);

            if (result == null)
                throw new NotFoundException(nameof(Article), id);

            db.Articles.Remove(result);
            return result;
        }
    }
}