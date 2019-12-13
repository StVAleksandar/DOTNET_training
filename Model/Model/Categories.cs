using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categories
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public byte[] picture { get; set; }
    }
}
