using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SDCTest.Data.Infrastructure;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;
using SDCTest.Service.Interfaces;

namespace SDCTest.Service.Services
{
    public class NhanVienService : INhanVienService
    {
        private IUnitOfWork _unitOfWork;
        private INhanVienRepository _nhanVienRepository;
        private IQuanRepository _quanRepository;
        private ITinhThanhRepository _tinhThanhRepository;

        public NhanVienService(IUnitOfWork unitOfWork, INhanVienRepository nhanVienRepository, IQuanRepository quanRepository,
            ITinhThanhRepository tinhThanhRepository)
        {
            _unitOfWork = unitOfWork;
            _nhanVienRepository = nhanVienRepository;
            _quanRepository = quanRepository;
            _tinhThanhRepository = tinhThanhRepository;
        }

        public IEnumerable<NhanVien> GetAll()
        {
            return _nhanVienRepository.Get(null, null);
        }

        public IPagedList<NhanVien> GetAllPaging(int page, int pageSize)
        {
            return _nhanVienRepository.GetPaging(null, x => x.OrderBy(y => y.ID), page, pageSize);
        }

        public NhanVien GetById(int id)
        {
            return _nhanVienRepository.GetByID(id);
        }

        public void Insert(NhanVien nhanVien)
        {
            _nhanVienRepository.Insert(nhanVien);
        }

        public void Update(NhanVien nhanVien)
        {
            _nhanVienRepository.Update(nhanVien);
        }

        public void Delete(int id)
        {
            _nhanVienRepository.Delete(id);
        }

        public IEnumerable<Quan> GetQuans(Expression<Func<Quan, bool>> filter = null,
            Func<IQueryable<Quan>, IOrderedQueryable<Quan>> orderBy = null)
        {
            return _quanRepository.Get(filter, orderBy);
        }

        public IEnumerable<TinhThanh> GetTinhThanhs()
        {
            return _tinhThanhRepository.Get(null, null);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
