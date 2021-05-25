using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImPossibleFoundation.Common.Exceptions;
using ImPossibleFoundation.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ImPossibleFoundation.Blog.Queries.GetArticleDetail
{
    public class GetArticleDetailsQuery : IRequest<ArticleDetailVm>
    {
        public GetArticleDetailsQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class GetArticleDetailsQueryHandler : IRequestHandler<GetArticleDetailsQuery, ArticleDetailVm>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetArticleDetailsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ArticleDetailVm> Handle(GetArticleDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await context.Articles
                .ProjectTo<ArticleDetailVm>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(nameof(Article), request.Id);

            return item;
        }
    }
}