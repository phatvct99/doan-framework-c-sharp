using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        OnlineShopDbContext db = null;
        public OrderDetailDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(OrderDetail detail)
        {
            
                detail.CreatedDate = DateTime.Now;
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return detail.OrderID; ;
           
        }
        public List<OrderDetail> ListAll()
        {
            return db.OrderDetails.OrderBy(x => x.OrderID).ToList();
        }
        public OrderDetail ViewDetail(long id)
        {
            return db.OrderDetails.Find(id);
        }
    }
}
