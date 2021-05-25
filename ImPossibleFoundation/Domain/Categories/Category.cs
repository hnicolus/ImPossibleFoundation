using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ImPossibleFoundation.Domain.Entities;

namespace ImPossibleFoundation.Blog
{
	public class Category: FullAuditedEntity<int>
	{
		public Category()	{ }

		[Required]
		[StringLength(120)]
		public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public List<ArticleCategory> PostCategories { get; set; }
    }
}
