using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    class OrderViewModel
    {
        public long ID { set; get; }
        public string ShipName { set; get; }
        public string ShipMobile { set; get; }
        public decimal? Price { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public int Quantity { set; get; }
        
    }
}
