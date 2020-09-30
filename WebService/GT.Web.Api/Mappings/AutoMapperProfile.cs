using AutoMapper;
using GT.Domain.Models;
using CropDto = GT.Web.Api.Models.Crop;
using CropActivityDto = GT.Web.Api.Models.CropActivity;
using GardenDto = GT.Web.Api.Models.Garden;

namespace GT.Web.Api.Mappings
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Crop
            CreateMap<Crop, CropDto>();
            CreateMap<CropDto, Crop>();

            // CropActivity
            CreateMap<CropActivity, CropActivityDto>();
            CreateMap<CropActivityDto, CropActivity>();

            // Garden
            CreateMap<Garden, GardenDto>();
            CreateMap<GardenDto, Garden>();
        }
    }
}
