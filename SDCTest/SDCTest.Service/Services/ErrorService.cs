using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Data.Infrastructure;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;
using SDCTest.Service.Interfaces;

namespace SDCTest.Service.Services
{
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Create(Error error)
        {
            _errorRepository.Insert(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
