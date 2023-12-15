using WebApiMangaApp.Data;
using WebApiMangaApp.Interface;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CategoriesExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);

            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
