using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using Model.EF;
using Model.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
		// GET: Admin/Home
		OnlineShopDbContext db = new OnlineShopDbContext();
		public ActionResult Index()
        {
			DateTime dateTimeNow = DateTime.Now.Date;
			dateTimeNow = dateTimeNow.AddYears(0);

			string[] dateX = new string[12];
			string[] data = new string[12];
			for (int i = 0; i < 12; i++)
			{

				dateX[i] = (dateTimeNow.Month.ToString() + "/" + dateTimeNow.Year.ToString()).ToString();
				var temp = db.OrderDetails.Where(a => a.CreatedDate.Value.Month == dateTimeNow.Month).Sum(s => (s.Price)*(s.Quantity));
				if (temp == null)
				{
					temp = 0;
				}
				data[i] = temp.ToString();
				dateTimeNow = dateTimeNow.AddMonths(1);
			}
			ViewBag.dateX = dateX;
			ViewBag.data = data;

			return View();
        }
    }
}