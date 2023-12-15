using MangaList.Models;

namespace WebApiMangaApp.Model
{
    public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<CategoryManga> CategoryMangas { get; set; }
    }
}
