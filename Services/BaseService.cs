using MapsterMapper;
using Rule4.Data;

namespace Rule4.Services
{
    public class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly DataContext _dataContext;
        public BaseService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
    }
}
