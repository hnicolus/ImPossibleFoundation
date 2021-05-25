using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class BlogPageModel
    {
        [Required]
        [StringLength(160)]
        public string Title { get; set; } = "Blog Title";
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Display(Name = "Items per page")]
        public int ItemsPerPage { get; set; }
        [StringLength(160)]
        [Display(Name = "Blog cover URL")]
        public string Cover { get; set; }
        [StringLength(160)]
        [Display(Name = "Blog logo URL")]
        public string Logo { get; set; }
        public bool IncludeFeatured { get; set; }
        public string HeaderScript { get; set; }
        public string FooterScript { get; set; }

    }
}