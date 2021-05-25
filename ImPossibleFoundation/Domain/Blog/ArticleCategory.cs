namespace ImPossibleFoundation.Blog
{
    public class ArticleCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public Article Post { get; set; }
        public Category Category { get; set; }
    }
}
