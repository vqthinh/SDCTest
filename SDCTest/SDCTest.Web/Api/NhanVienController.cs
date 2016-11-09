using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDCTest.Model.Models;
using SDCTest.Service.Interfaces;
using SDCTest.Web.Infrastructure.Core;

namespace SDCTest.Web.Api
{
 
    public class NhanVienController : ApiControllerBase
    {
        private INhanVienService _nhanVienService;
        public NhanVienController(IErrorService errorService,INhanVienService nhanVienService) : base(errorService)
        {
            _nhanVienService = nhanVienService;
        }

        public IEnumerable<NhanVien> Get()
        {
            return _nhanVienService.GetAll();
        }
    
    }
}