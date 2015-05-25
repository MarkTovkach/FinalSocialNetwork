using System;
using System.Linq;
using DAL;
using DAL.EF;

namespace BLL
{
    public class UserManager : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;
        public UserManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }




        
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed == false)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
