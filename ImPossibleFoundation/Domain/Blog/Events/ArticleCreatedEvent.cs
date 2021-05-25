using System;
using ImPossibleFoundation.Blog;
using ImPossibleFoundation.DomainEvents;

namespace ImPossibleFoundation.Blog
{
    public class ArticleCreatedEvent : DomainEvent
    {
        public ArticleCreatedEvent(Article item)
        {
            Item = item;
        }

        public Article Item { get; }
    }
}