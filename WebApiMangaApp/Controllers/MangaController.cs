using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiMangaApp.Dto.MangaDTOs;
using WebApiMangaApp.Interface;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MangaController(IMangaRepository mangaRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MangaWithCategoryNames>))]
        public IActionResult GetMangas()
        {
            var mangas = _mapper.Map<List<MangaWithCategoryNames>>(_mangaRepository.GetMangas());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(mangas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MangaDto))]
        public IActionResult GetCategory(int id)
        {
            if (!_mangaRepository.MangaExists(id)) return NotFound();

            var manga = _mapper.Map<MangaDto>(_mangaRepository.GetManga(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(manga);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateManga([FromBody] MangaPostDto mangaCreate)
        {
            if (mangaCreate == null) return BadRequest(ModelState);

            var manga = _mangaRepository.GetMangas().Where(c => c.Title.Trim().ToUpper() == mangaCreate.Title.TrimEnd().ToUpper()).FirstOrDefault();

            if (manga != null)
            {
                ModelState.AddModelError("", "Manga already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var novoManga = new Manga
            {
                Title = mangaCreate.Title
            };

            Manga mangaCriado = _mangaRepository.CreateManga(novoManga);

            if (mangaCreate.categories != null)
            {
                foreach (var category in mangaCreate.categories)
                {
                    if (!_categoryRepository.CategoriesExists(category))
                    {
                        ModelState.AddModelError("", "Category not exists!");
                        return StatusCode(422, ModelState);
                    }
                }

                if (mangaCreate.categories.Count > 0)
                {
                    _mangaRepository.AddCategoryToManga(mangaCriado.Id, mangaCreate.categories);
                }
            }

            return Ok("Successfully Created!");
        }

        [HttpPut("{mangaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult UpdateManga(int mangaId, [FromBody] MangaPutDto updateManga)
        {
            if (updateManga == null) return BadRequest(ModelState);

            if(!_mangaRepository.MangaExists(mangaId)) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            var manga = _mangaRepository.GetManga(mangaId);

            if (updateManga.Title != null) manga.Title = updateManga.Title;

            var mangaMap = _mapper.Map<Manga>(manga);

            if (!_mangaRepository.UpdateManga(mangaMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Manga!");

                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }

    }
}
