namespace WebApiMangaApp.Dto.MangaDTOs
{
    public class MangaWithCategoryNames
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}
