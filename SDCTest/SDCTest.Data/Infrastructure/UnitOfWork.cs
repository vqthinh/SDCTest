using System;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;

namespace SDCTest.Data.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private SDCTestDbContext context = new SDCTestDbContext();
        private NhanVienRepository nhanVienRepository;
        private GenericRepository<Quan> quanRepository;
        private GenericRepository<TinhThanh> tinhThanhRepository;

        public NhanVienRepository NhanVienRepository
        {
            get
            {

                if (this.nhanVienRepository == null)
                {
                    this.nhanVienRepository = new NhanVienRepository(context);
                }
                return nhanVienRepository;
            }
        }
        public GenericRepository<Quan> QuanRepository
        {
            get
            {

                if (this.quanRepository == null)
                {
                    this.quanRepository = new GenericRepository<Quan>(context);
                }
                return quanRepository;
            }
        }

        public GenericRepository<TinhThanh> TinhThanhRepository
        {
            get
            {

                if (this.tinhThanhRepository == null)
                {
                    this.tinhThanhRepository = new GenericRepository<TinhThanh>(context);
                }
                return tinhThanhRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
