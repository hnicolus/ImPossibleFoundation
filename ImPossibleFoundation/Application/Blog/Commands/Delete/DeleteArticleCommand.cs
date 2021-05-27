using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImPossibleFoundation.Common.Exceptions;
using ImPossibleFoundation.Data;
using MediatR;

namespace ImPossibleFoundation.Blog
{
    public class DeleteArticleCommand : IRequest<Guid>
    {
        public DeleteArticleCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
    }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext context;

        public DeleteArticleCommandHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Guid> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await context.Articles.FindAsync(request.Id);
            if (article == null) throw new NotFoundException(nameof(Article), request.Id);
            context.Articles.Remove(article);
            await context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}