using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SDCTest.Model.Models;

namespace SDCTest.Service.Interfaces
{
    public interface INhanVienService
    {
        IEnumerable<NhanVien> GetAll();

        IPagedList<NhanVien> GetAllPaging(int page, int pageSize);

        NhanVien GetById(int id);

        void Insert(NhanVien nhanVien);

        void Update(NhanVien nhanVien);

        void Delete(int id);

        IEnumerable<Quan> GetQuans(Expression<Func<Quan, bool>> filter = null,
            Func<IQueryable<Quan>, IOrderedQueryable<Quan>> orderBy = null);

        IEnumerable<TinhThanh> GetTinhThanhs();
    }
}
