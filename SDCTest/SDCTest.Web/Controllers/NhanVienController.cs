using System.Data;
using System.Web.Mvc;
using SDCTest.Data.Infrastructure;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;
using System.Linq;
using SDCTest.Service.Interfaces;

namespace SDCTest.Web.Controllers
{
    public class NhanVienController : Controller
    {
        private INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }


        // GET: NhanVien
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            return View(_nhanVienService.GetAllPaging(page, pageSize));
        }

        public ActionResult Create()
        {
            GetDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nhanVienService.Insert(nhanVien);
                    _nhanVienService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Lỗi, không thể thêm.");
            }
            GetDropDown();
            return View(nhanVien);
        }

        public ActionResult Edit(int id)
        {
            NhanVien nhanVien = _nhanVienService.GetById(id);
            GetDropDown(nhanVien.QuanID, nhanVien.TinhThanhID);
            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nhanVienService.Update(nhanVien);
                    _nhanVienService.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Lỗi, không thể cập nhật.");
            }
            GetDropDown(nhanVien.QuanID, nhanVien.TinhThanhID);
            return View(nhanVien);
        }

        public ActionResult Delete(int id)
        {
            _nhanVienService.Delete(id);
            _nhanVienService.Save();
            return RedirectToAction("Index");
        }

        private void GetDropDown(int? selectedQuan = null, int? selectedTinhThanh = null)
        {
            var listQuan = _nhanVienService.GetQuans(x => x.TinhThanhID == 1,null);
            var listTinhThanh = _nhanVienService.GetTinhThanhs();
            if (selectedQuan == null)
            {
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", 0);
            }
            else
            {
                listQuan = _nhanVienService.GetQuans(x => x.TinhThanhID == selectedTinhThanh, null);
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", selectedQuan);
            }
            ViewData["TinhThanhID"] = new SelectList(listTinhThanh, "ID", "TenTinhThanh", selectedTinhThanh);
        }

        public JsonResult GetQuan(int id)
        {
            var listQuan = _nhanVienService.GetQuans(x => x.TinhThanhID == id, null);
            return Json(new SelectList(listQuan, "ID", "TenQuan"));
        }


    }
}