using Flunt.Notifications;
using Flunt.Validations;
using MangaList.Models;

namespace WebApiMangaApp.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryManga> CategoryMangas { get; set; }
    }
}
