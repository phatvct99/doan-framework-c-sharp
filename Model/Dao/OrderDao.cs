using System;
using PagedList;
using Model.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Configuration;
using Common;
using System.Data.Odbc;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public static string USER_SESSION = "USER_SESSION";
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
     
        public long Insert(Order order)
        {
            order.Status = true;
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public long Detail(Order order )

        {
            db.SaveChanges();
            return order.ID;
        }
        //public IEnumerable<OrderViewModel> Detailasd()
        //{
        //    var model = (from a in db.Orders
        //                 join b in db.OrderDetails
        //                 on a.ID equals b.OrderID
        //                 select new
        //                 {
        //                     ShipName = a.ShipName,
        //                     ShipAddress = a.ShipAddress,
        //                     ShipEmail = a.ShipEmail,
        //                     ShipMobile = a.ShipMobile,
        //                     Quantity = b.Quantity,
        //                     Price = b.Price
        //                 }).AsEnumerable().Select(x => new OrderViewModel()
        //                 {
        //                     ShipName = x.ShipName,
        //                     ShipAddress = x.ShipAddress,
        //                     ShipEmail = x.ShipEmail,
        //                     ShipMobile = x.ShipMobile,
        //                     Quantity = x.Quantity,
        //                     Price = x.Price
        //                 });
        //    model.OrderByDescending(x => x.Price);
        //    return model.ToList();
        //}
        public long Create(Order order)
        {
            order.CreatedDate = DateTime.Now;
            order.Status = true;

            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public long Edit(Order order)
        {
            //Xử lý alias
            order.CreatedDate = DateTime.Now;
            db.SaveChanges();
            return order.ID;
        }
        public bool Update(Order entity)
        {
            try
            {
                var Order = db.Orders.Find(entity.ID);
                Order.ShipName = entity.ShipName;
                Order.ShipMobile = entity.ShipMobile;
                Order.ShipAddress = entity.ShipAddress;
                Order.ShipEmail = entity.ShipEmail;
                Order.Status = entity.Status;
                Order.CreatedDate = entity.CreatedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public bool DetailUpdate(Order entity)
        {
            try
            {
                var Order = db.Orders.Find(entity.ID);
                
                Order.Status = entity.Status;
                //Order.CreatedDate = entity.CreatedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipMobile.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool ChangeStatus(long ID)
        {
            var order = db.Orders.Find(ID);
            order.Status = !order.Status;
            db.SaveChanges();
            return order.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Order ViewDetail(long id)
        {
            return db.Orders.Find(id);
        }
    }
}
