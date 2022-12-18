using ASZN.Web.DTO.Card;

namespace ASZN.Services.Interface
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetUserCardsAsync(CancellationToken cancellationToken);
    }
}
