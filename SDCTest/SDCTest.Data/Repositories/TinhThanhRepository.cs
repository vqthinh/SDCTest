using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Data.Repositories
{
    public interface ITinhThanhRepository : IRepository<TinhThanh>
    {
        //Add some external function
    }
    public class TinhThanhRepository : GenericRepository<TinhThanh>
    {
        public TinhThanhRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
