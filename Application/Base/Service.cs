using Domain.Base;
using Domain.Contract;

namespace Application.Base
{
    public abstract class BaseService
    {
        
    }
    public abstract class Service<T> : BaseService, IService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}