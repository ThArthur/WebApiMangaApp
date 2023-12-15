using Flunt.Notifications;
using Flunt.Validations;

namespace WebApiMangaApp.Dto.MangaDTOs
{
    public class MangaPutDto
    {
        public string? Title { get; set; }
        public List<int>? categories { get; set; }
    }
}
