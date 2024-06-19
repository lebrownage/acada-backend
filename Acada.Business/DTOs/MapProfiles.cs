using Acada.Business.DTOs.Models;
using Acada.Domain.Entities;
using AutoMapper;

namespace Acada.Business.DTOs
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
