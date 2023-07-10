using AutoMapper;
using Core.Entities.Models;
using Core.Entities.InputModels;

namespace api.CodigoCodeTest.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Evoucher, EVoucherModel>().ReverseMap();
        }
    }
}
