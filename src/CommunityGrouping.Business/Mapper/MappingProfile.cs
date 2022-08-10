using AutoMapper;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Entities.Dto.ApplicationUser;

namespace CommunityGrouping.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegisterDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
