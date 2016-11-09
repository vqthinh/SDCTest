using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDCTest.Model.Models;
using SDCTest.Service.Interfaces;
using SDCTest.WebAPI.Infrastructure.Core;

namespace SDCTest.WebAPI.Api
{
    [RoutePrefix("api/nhanvien")]
    public class NhanVienController : ApiControllerBase
    {
        private INhanVienService _nhanVienService;
        public NhanVienController(IErrorService errorService,INhanVienService nhanVienService) : base(errorService)
        {
            _nhanVienService = nhanVienService;
        }
        [Route("getall")]
        public IEnumerable<NhanVien> GetNhanViens()
        {
            return _nhanVienService.GetAll();
        }
    }
}