using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using OnlineShop.Common;
using PagedList;
using PagedList.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            //ViewBag.SearchString = searchString;
            //SetViewBag();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory model)
        {
            new ProductCategoryDao().Create(model);
            SetAlert("Thêm danh mục thành công", "success");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ProductCategory = new ProductCategoryDao().ViewDetail(id);
            return View(ProductCategory);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                var result = dao.Update(productcategory);
                if (result)
                {
                    SetAlert("Sửa danh mục thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
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
            new ProductCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

        //public void SetViewBag(long? selectedId = null)
        //{
        //    var dao = new ProductCategoryDao();
        //    ViewBag.ProductID = new SelectList(dao.ListAll(), "Quantity", "Price", selectedId);
        //}
        //[HttpPost]
        //public JsonResult ChangeStatus(long ID)
        //{
        //    var result = new OrderDao().ChangeStatus(ID);
        //    return Json(new
        //    {
        //        status = result
        //    }); ;
        //}
    }
}