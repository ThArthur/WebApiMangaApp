using MangaList.Models;
using Microsoft.EntityFrameworkCore;
using WebApiMangaApp.Data;
using WebApiMangaApp.Dto.MangaDTOs;
using WebApiMangaApp.Interface;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.Repository
{
    public class MangaRepository : IMangaRepository
    {
        private readonly AppDbContext _context;

        public MangaRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool AddCategoryToManga(int mangaId, List<int> categoryId)
        {
            var manga = GetManga(mangaId);

            foreach (var category in categoryId)
            {
                var innerCategory = _context.Categories.Where(c => c.Id == category).FirstOrDefault();

                var mangaCategoria = new CategoryManga { Manga = manga, Category = innerCategory };

                _context.CategoryMangas.Add(mangaCategoria);
            }
            return Save();
        }

        public Manga CreateManga(Manga manga)
        {
            // Adicione o mangá ao contexto
            var mangaEntity = _context.Mangas.Add(manga).Entity;

            // Salve as mudanças no contexto
            Save();

            // Retorne o mangá criado
            return mangaEntity;
        }

        public bool DeleteManga(Manga manga)
        {
            _context.Remove(manga);

            return Save();
        }

        public Manga GetManga(int mangaId)
        {
            return _context.Mangas.Where(m => m.Id == mangaId).FirstOrDefault();
        }

        public IEnumerable<MangaWithCategoryNames> GetMangas()
        {
            var mangas = _context.Mangas.Include(m => m.CategoryMangas).ThenInclude(cm => cm.Category).ToList();

            var mangaFormatted = mangas.Select(m => new MangaWithCategoryNames
            {
                Id = m.Id,
                Title = m.Title,
                CategoryNames = m.CategoryMangas.Select(cm => cm.Category.Name).ToList()
            });

            return mangaFormatted;
        }

        public bool MangaExists(int mangaId)
        {
            return _context.Mangas.Any(m => m.Id == mangaId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateManga(Manga manga)
        {
            _context.Update(manga);

            return Save();
        }
    }
}
