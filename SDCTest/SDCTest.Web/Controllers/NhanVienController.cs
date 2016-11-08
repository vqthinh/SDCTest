using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDCTest.Data.Infrastructure;
using SDCTest.Model.Models;

namespace SDCTest.Web.Controllers
{
    public class NhanVienController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: NhanVien
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            return View(unitOfWork.NhanVienRepository.GetPaging(null,q=>q.OrderBy(x=>x.ID),page,pageSize));
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
                    unitOfWork.NhanVienRepository.Insert(nhanVien);
                    unitOfWork.Save();
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
            NhanVien nhanVien = unitOfWork.NhanVienRepository.GetByID(id);
            GetDropDown(nhanVien.QuanID,nhanVien.TinhThanhID);
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
                    unitOfWork.NhanVienRepository.Update(nhanVien);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Lỗi, không thể cập nhật.");
            }
            GetDropDown(nhanVien.QuanID,nhanVien.TinhThanhID);
            return View(nhanVien);
        }

        public ActionResult Delete(int id)
        {
            NhanVien nhanVien = unitOfWork.NhanVienRepository.GetByID(id);
            unitOfWork.NhanVienRepository.Delete(nhanVien);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void GetDropDown(int? selectedQuan=null,int? selectedTinhThanh=null)
        {
            var listQuan = unitOfWork.QuanRepository.Get(filter: x =>x.TinhThanhID==1, orderBy: null);
            var listTinhThanh = unitOfWork.TinhThanhRepository.Get(null, null);
            if (selectedQuan == null)
            {
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", 0);
            }
            else
            {
                listQuan = unitOfWork.QuanRepository.Get(x => x.TinhThanhID == selectedTinhThanh, null);
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", selectedQuan);
            }
            ViewData["TinhThanhID"] = new SelectList(listTinhThanh, "ID", "TenTinhThanh", selectedTinhThanh);
        }

        public JsonResult GetQuan(int id)
        {
            var listQuan = unitOfWork.QuanRepository.Get(x=>x.TinhThanhID==id, null);
            return Json(new SelectList(listQuan, "ID", "TenQuan"));
        }


    }
}