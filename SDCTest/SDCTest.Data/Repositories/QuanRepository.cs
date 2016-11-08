using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Data.Repositories
{
    public interface IQuanRepository : IRepository<Quan>
    {
        
    }

    public class QuanRepository : GenericRepository<Quan>,IQuanRepository
    {
        public QuanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
