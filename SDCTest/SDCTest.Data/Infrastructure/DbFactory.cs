using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCTest.Data.Infrastructure
{
    public class DbFactory : Disposable,IDbFactory
    {
        private SDCTestDbContext dbContext;
        public SDCTestDbContext Init()
        {
            return dbContext ?? (dbContext = new SDCTestDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
