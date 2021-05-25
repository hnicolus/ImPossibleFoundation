using System;
using ImPossibleFoundation.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImPossibleFoundation.Blog
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable(name: ImPossibleFoundationConsts.DbPrefix + "BlogArticles");
            builder.Ignore(e => e.DomainEvents);
            builder.Property(x => x.Title).HasMaxLength(ArticleConsts.TitleMaxLength);
            builder.Property(x => x.Description).HasMaxLength(ArticleConsts.DescriptionMaxLength);
            builder.Property(x => x.Content).HasMaxLength(ArticleConsts.ContentMaxLength);
            builder.Property(x => x.Slug).HasMaxLength(ArticleConsts.SlugMaxLength);
            builder.Property(x => x.Rating).HasMaxLength(ArticleConsts.RatingMaxLength);
            builder.Property(x => x.Cover).HasMaxLength(ArticleConsts.CoverMaxLength);
        }
    }
}