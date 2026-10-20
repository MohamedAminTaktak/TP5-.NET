using AutoMapper;
using MoviesApi.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();

            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore());
        }
    }
}