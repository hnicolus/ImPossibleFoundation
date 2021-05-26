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
        public async Task<ActionResult<PaginatedList<ArticleDto>>> GetPaginatedArticleAsync([FromQuery] GetPaginatedArticleListQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDetailVm>> GetArticleDetail(Guid id)
        {
            return await Mediator.Send(new GetArticleDetailsQuery(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateArticleAsync([FromBody] CreateArticleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticleAsync(Guid id,[FromBody] UpdateArticleDetailsCommand command)
        {
            
            await Mediator.Send(command);
            return NoContent();
        }

        

    }

}