using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using OnlineShop.Models;
using OnlineShop.Common;
using PagedList;
using PagedList.Mvc;

   
namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: Admin/Order
        [HttpGet]
        public ActionResult Index(string searchString, int page=1, int pageSize=10)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            SetViewBag();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Detail(long id)
        {
           
            var Order = new OrderDao().ViewDetail(id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult Detail(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.DetailUpdate(order);
                if (result)
                {
                    SetAlert("Xác nhận đơn hàng thành công", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn hàng không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Create(Order model)
        {
            new OrderDao().Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Order = new OrderDao().ViewDetail(id);           
            return View(Order);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update(order);
                if (result)
                {
                    SetAlert("Sửa đơn hàng thành công", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn hàng không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new OrderDao().Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new OrderDetailDao();
            ViewBag.ProductID = new SelectList(dao.ListAll(), "Quantity", "Price", selectedId);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long ID)
        {
            var result = new OrderDao().ChangeStatus(ID);
            return Json(new
            {
                status = result
            }); ;
        }

    }
}