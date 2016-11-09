using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Data.Repositories
{
    public interface IErrorRepository : IRepository<Error>
    {
        
    }
    public class ErrorRepository : GenericRepository<Error>,IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
