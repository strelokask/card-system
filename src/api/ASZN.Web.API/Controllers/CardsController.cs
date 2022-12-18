using ASZN.Services.Interface;
using ASZN.Web.DTO.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASZN.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<CardDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var dtos = await _cardService.GetUserCardsAsync(cancellationToken);

            return Ok(dtos);
        }
    }
}
