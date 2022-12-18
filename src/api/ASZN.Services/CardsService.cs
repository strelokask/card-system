using ASZN.DAL;
using ASZN.DomainModel;
using ASZN.Services.Interface;
using ASZN.Web.DTO.Card;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASZN.Services
{
    public class CardsService : BaseEntityService<Card>, ICardService
    {
        public CardsService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<CardDto>> GetUserCardsAsync(CancellationToken cancellationToken)
        {
            var dtos = await _dbContext.Cards.AsNoTracking()
                .ProjectTo<CardDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return dtos;
        }
    }
}
