using System;
using Domain.Repositories;

namespace Domain.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        #region [Repositories]
        public IUserRepository UserRepository { get;}
        #endregion

        int Commit();
    }
}