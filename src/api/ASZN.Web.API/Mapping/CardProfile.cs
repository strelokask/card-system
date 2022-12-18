using ASZN.DomainModel;
using ASZN.Web.DTO.Card;
using AutoMapper;

namespace ASZN.Web.API.Mapping
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>();
        }
    }
}
