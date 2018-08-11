using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAO;
using BLL;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class NienKhoaHocKyController : Controller
    {
        private NienKhoaHocKyBLL contexNKHK = new NienKhoaHocKyBLL();

        // GET: Admin/NienKhoaHocKy
        public ActionResult Index()
        {
            return View(contexNKHK.GetAll());
        }
        // GET: Admin/NienKhoaHocKy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NienKhoaHocKy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string nienKhoa)
        {
            if (string.IsNullOrEmpty(nienKhoa))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int temp = Int32.Parse(nienKhoa)+1;
            string idNK ="K"+ nienKhoa.Substring(2, 2)+"-1";
            NienKhoaHocKy nkhk = contexNKHK.GetById(idNK.Trim());
            if(nkhk== null)
            {
                nkhk = new NienKhoaHocKy();
                for (int i=1; i < 4; i++)
                {
                    nkhk.ID = "K" + nienKhoa.Substring(2, 2) + "-" + i.ToString();
                    nkhk.NienKhoa = nienKhoa + "-" + temp.ToString().Trim();
                    nkhk.HocKy = i;
                    contexNKHK.Create(nkhk);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
