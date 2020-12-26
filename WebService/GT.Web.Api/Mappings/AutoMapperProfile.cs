using AutoMapper;
using GT.Domain.Models;
using CropActivityDto = GT.Web.Api.Models.CropActivity;
using CropDto = GT.Web.Api.Models.Crop;
using GardenDto = GT.Web.Api.Models.Garden;

namespace GT.Web.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Crop
            CreateMap<Crop, CropDto>();
            CreateMap<CropDto, Crop>()
                .ForMember(dest => dest.Garden, opt => opt.Ignore());

            // CropActivity
            CreateMap<CropActivity, CropActivityDto>()
                .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.ActivityId));
            CreateMap<CropActivityDto, CropActivity>()
                .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.ActivityType))
                .ForMember(dest => dest.Crop, opt => opt.Ignore());

            // Garden
            CreateMap<Garden, GardenDto>();
            CreateMap<GardenDto, Garden>();
        }
    }
}
