using System;
using AutoMapper;
using ImPossibleFoundation.Common.Mappings;
using ImPossibleFoundation.Dtos;

namespace ImPossibleFoundation.Blog
{


    public class ArticleDto : FullAuditedEntityDto<Guid>, IMapFrom<Article>
    {
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
    }
}