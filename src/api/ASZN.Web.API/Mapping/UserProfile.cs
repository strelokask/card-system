using ASZN.DomainModel;
using ASZN.Web.DTO.User;
using AutoMapper;

namespace ASZN.Web.API.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserCreateDto, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(_ => _.UserName));
        }
    }
}
