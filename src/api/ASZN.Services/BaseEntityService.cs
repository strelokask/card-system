using ASZN.DAL;
using ASZN.DomainModel;
using AutoMapper;

namespace ASZN.Services
{
    public abstract class BaseEntityService<T>
        where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected IMapper _mapper;

        public BaseEntityService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
