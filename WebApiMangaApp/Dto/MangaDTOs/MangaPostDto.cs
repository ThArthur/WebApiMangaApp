namespace WebApiMangaApp.Dto.MangaDTOs
{
    public class MangaPostDto
    {
        public string Title { get; set; }
        public List<int> categories { get; set; } = new List<int>();
    }
}
