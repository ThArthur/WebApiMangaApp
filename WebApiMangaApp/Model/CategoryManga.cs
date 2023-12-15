using WebApiMangaApp.Model;

namespace MangaList.Models
{
    public class CategoryManga
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
