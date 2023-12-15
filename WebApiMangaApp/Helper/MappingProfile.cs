using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApiMangaApp.Dto.CategoryDTOs;
using WebApiMangaApp.Dto.EployeeDTOs;
using WebApiMangaApp.Dto.MangaDTOs;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.ProfileConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>(); // Mapeamento de Category para CategoryDto
            CreateMap<CategoryDto, Category>(); // Mapeamento reverso de CategoryDto para Category
            CreateMap<CategoryPostDto, Category>();

            CreateMap<Manga, MangaDto>();
            CreateMap<MangaDto, Manga>();
            CreateMap<MangaPostDto, Manga>();
            CreateMap<MangaPutDto, Manga>();

        }
    }
}
