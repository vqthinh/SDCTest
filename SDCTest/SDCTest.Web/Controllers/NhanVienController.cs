using System.Data;
using System.Web.Mvc;
using SDCTest.Data.Infrastructure;
using SDCTest.Data.Repositories;
using SDCTest.Model.Models;
using System.Linq;

namespace SDCTest.Web.Controllers
{
    public class NhanVienController : Controller
    {
        IUnitOfWork _unitOfWork;
        INhanVienRepository _nhanVienRepository;
        IQuanRepository _quanRepository;
        ITinhThanhRepository _tinhThanhRepository;

        public NhanVienController(IUnitOfWork unitOfWork,INhanVienRepository nhanVienRepository,IQuanRepository quanRepository,ITinhThanhRepository tinhThanhRepository)
        {
            _unitOfWork = unitOfWork;
            _nhanVienRepository = nhanVienRepository;
            _quanRepository = quanRepository;
            _tinhThanhRepository = tinhThanhRepository;
        }

        // GET: NhanVien
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            return View(_nhanVienRepository.GetPaging(null,q=>q.OrderBy(x=>x.ID),page,pageSize));
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
                    _nhanVienRepository.Insert(nhanVien);
                    _unitOfWork.Commit();
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
            NhanVien nhanVien = _nhanVienRepository.GetByID(id);
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
                    _nhanVienRepository.Update(nhanVien);
                    _unitOfWork.Commit();
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
            NhanVien nhanVien = _nhanVienRepository.GetByID(id);
            _nhanVienRepository.Delete(nhanVien);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        private void GetDropDown(int? selectedQuan=null,int? selectedTinhThanh=null)
        {
            var listQuan = _quanRepository.Get(filter: x =>x.TinhThanhID==1, orderBy: null);
            var listTinhThanh = _tinhThanhRepository.Get(null, null);
            if (selectedQuan == null)
            {
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", 0);
            }
            else
            {
                listQuan = _quanRepository.Get(x => x.TinhThanhID == selectedTinhThanh, null);
                ViewData["QuanID"] = new SelectList(listQuan, "ID", "TenQuan", selectedQuan);
            }
            ViewData["TinhThanhID"] = new SelectList(listTinhThanh, "ID", "TenTinhThanh", selectedTinhThanh);
        }

        public JsonResult GetQuan(int id)
        {
            var listQuan = _quanRepository.Get(x=>x.TinhThanhID==id, null);
            return Json(new SelectList(listQuan, "ID", "TenQuan"));
        }


    }
}