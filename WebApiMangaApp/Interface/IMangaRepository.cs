using WebApiMangaApp.Dto.MangaDTOs;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.Interface
{
    public interface IMangaRepository
    {
        IEnumerable<MangaWithCategoryNames> GetMangas();
        Manga GetManga(int mangaId);
        bool MangaExists(int mangaId);
        Manga CreateManga(Manga manga);
        bool UpdateManga(Manga manga);
        bool DeleteManga(Manga manga);
        bool AddCategoryToManga(int mangaId, List<int> categoryId);
        bool Save();
    }
}
