using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImPossibleFoundation.Data;
using ImPossibleFoundation.Identity;
using MediatR;

namespace ImPossibleFoundation.Blog
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
    }

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext context;
        private readonly IIdentityService identityService;

        public CreateArticleCommandHandler(IMapper mapper, IAppDbContext context, IIdentityService identityService)
        {
            this.mapper = mapper;
            this.context = context;
            this.identityService = identityService;
        }
        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            
            var article = Article.Create(request.Title, request.Description, request.Cover);
            article.Content = request.Content;
            article.Slug = request.Slug;
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync(cancellationToken);
            return article.Id;
        }
    }
}