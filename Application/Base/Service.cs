using Domain.Base;
using Domain.Contract;

namespace Application.Base
{
    public class Service<T> : BaseService, IService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }

    public abstract class BaseService
    {
        
    }
}