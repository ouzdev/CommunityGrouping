using AutoMapper;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegisterDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
            
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<OccupationDto, Occupation>().ReverseMap();
            CreateMap<CommunityGroupDto, CommunityGroup>().ReverseMap();

        }
    }
}
