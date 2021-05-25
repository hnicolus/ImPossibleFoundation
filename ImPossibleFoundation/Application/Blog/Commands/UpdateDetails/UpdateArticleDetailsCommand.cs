using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImPossibleFoundation.Common.Exceptions;
using ImPossibleFoundation.Data;
using MediatR;

namespace ImPossibleFoundation.Blog
{
    public class UpdateArticleDetailsCommand : IRequest<ArticleDetailVm>
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
    }

    public class UpdateArticleDetailsCommandHandler : IRequestHandler<UpdateArticleDetailsCommand, ArticleDetailVm>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public UpdateArticleDetailsCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ArticleDetailVm> Handle(UpdateArticleDetailsCommand request, CancellationToken cancellationToken)
        {

            var article = await context.Articles.FindAsync(request.ArticleId);

            if (article == null)
                throw new NotFoundException(nameof(Article), request.ArticleId);

            article.Title = request.Title;
            article.Content = request.Content;
            article.Cover = request.Cover;

            context.Articles.Update(article);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<ArticleDetailVm>(article);
        }
    }
}