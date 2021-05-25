using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ImPossibleFoundation.Domain.Entities;
using ImPossibleFoundation.DomainEvents;

namespace ImPossibleFoundation.Blog
{
    public class Article : FullAuditedEntity<Guid>, IHasDomainEvent
    {
        protected Article() { }

        internal Article(
            [NotNull] string title,
            [NotNull] string description,
            [NotNull] string cover)
        {
            Title = title;
            Description = description;
            Cover = cover;
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
        public int PostViews { get; set; }
        public double Rating { get; set; }
        public bool IsFeatured { get; set; }
        public bool Selected { get; set; }

        public DateTime Published { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        // public ICollection<ArticleCategory> PostCategories { get; set; }

        public static Article Create(string title, string description, string cover)
        {
            return new Article(title, description, cover);
        }
    }
}