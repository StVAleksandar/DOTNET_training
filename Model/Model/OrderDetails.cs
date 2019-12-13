using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class OrderDetails
    {
        public int orderID { get; set; }
        public int productID { get; set; }
        public decimal unitPrice { get; set; }
        public short quantity { get; set; }
        public decimal discount { get; set; }
    }
}
