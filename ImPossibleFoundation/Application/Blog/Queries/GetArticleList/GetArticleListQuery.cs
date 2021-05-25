using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImPossibleFoundation.Common;
using ImPossibleFoundation.Common.Mappings;
using ImPossibleFoundation.Common.Models;
using ImPossibleFoundation.Data;
using ImPossibleFoundation.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ImPossibleFoundation.Blog
{
    public class GetPaginatedArticleListQuery : IRequest<PaginatedList<ArticleDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetPaginatedArticleListQueryHandler : IRequestHandler<GetPaginatedArticleListQuery, PaginatedList<ArticleDto>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext dbContext;

        public GetPaginatedArticleListQueryHandler(
            IMapper mapper, IAppDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<PaginatedList<ArticleDto>> Handle(GetPaginatedArticleListQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Articles.ProjectTo<ArticleDto>(mapper.ConfigurationProvider)
            .OrderBy(i => i.Title).PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}