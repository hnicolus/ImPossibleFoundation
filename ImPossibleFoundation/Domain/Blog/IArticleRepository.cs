using System;
using ImPossibleFoundation.Common;

namespace ImPossibleFoundation.Blog
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {

    }
}