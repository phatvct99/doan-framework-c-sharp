//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Reflection;
////using Model.Dao;
////using Model.EF;
//using System.ComponentModel.DataAnnotations;


//namespace OnlineShop.Areas.Admin.Models
//{
//    public class OrderModel
//    {
//        public long ID { get; set; }

//        public DateTime? CreatedDate { get; set; }

//        public long? CustomerID { get; set; }

        
//        public string ShipName { get; set; }

        
//        public string ShipMobile { get; set; }

        
//        public string ShipAddress { get; set; }

        
//        public string ShipEmail { get; set; }

//        public bool Status { get; set; }
//        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

//        public Order TypeOf_Order()
//        {
//            Order order = new Order();
//            PropertyInfo[] pithis = typeof(OrderDao).GetProperties();
//            PropertyInfo[] pieClinet = typeof(Order).GetProperties();
//            foreach (var items in pithis)
//            {
//                foreach (var itempiem in pieClinet)
//                {
//                    if (itempiem.Name == items.Name)
//                    {
//                        itempiem.SetValue(order, items.GetValue(this));
//                        break;
//                    }
//                }
//            }
//            return order;
//        }

//        // convert tu model sang view

//        public void TypeOf_OrderEntity(Order order)
//        {

//            PropertyInfo[] pithis = typeof(OrderDao).GetProperties();
//            PropertyInfo[] pieClinet = typeof(Order).GetProperties();
//            foreach (var items in pithis)
//            {
//                foreach (var itempiem in pieClinet)
//                {
//                    if (itempiem.Name == items.Name)
//                    {
//                        items.SetValue(this, itempiem.GetValue(order));
//                        break;
//                    }
//                }
//            }

//        }
//        //public OrderDao(Order order)
//        //{
//        //      return TypeOf_OrderEntity(order);

//        //}
//        //public OrderDao()
//        //{
//        //}
//    }
//}