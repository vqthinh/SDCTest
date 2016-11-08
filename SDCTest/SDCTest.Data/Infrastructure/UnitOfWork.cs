using System;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;

namespace SDCTest.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private SDCTestDbContext context = new SDCTestDbContext();

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public SDCTestDbContext DbContext
        {
            get { return context ?? (context = dbFactory.Init()); }
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
