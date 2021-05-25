using System;
using System.Threading.Tasks;
using ImPossibleFoundation.Blog;
using ImPossibleFoundation.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImPossibleFoundation.Controllers
{
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ArticleDto>>> GetPaginatedArticle([FromQuery] GetPaginatedArticleListQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}