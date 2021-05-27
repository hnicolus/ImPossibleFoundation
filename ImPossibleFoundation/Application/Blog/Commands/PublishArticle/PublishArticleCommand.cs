using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImPossibleFoundation.Clocking;
using ImPossibleFoundation.Data;
using MediatR;

namespace ImPossibleFoundation.Blog
{
    public class PublishArticleCommand : IRequest<Guid>
    {
        public PublishArticleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }

    public class PublishArticleCommandHandler : IRequestHandler<PublishArticleCommand, Guid>
    {
        private readonly IClock clock;
        private readonly IMapper mapper;
        private readonly IAppDbContext context;

        public PublishArticleCommandHandler(IClock clock, IMapper mapper, IAppDbContext context)
        {
            this.clock = clock;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Guid> Handle(PublishArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await context.Articles.FindAsync(request.Id);
            article.IsPublished = true;
            article.Published = clock.Now;
            context.Articles.Update(article);
            await context.SaveChangesAsync(cancellationToken);
            return article.Id;
        }
    }
}