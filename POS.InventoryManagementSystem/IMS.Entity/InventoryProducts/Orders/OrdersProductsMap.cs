using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    using System;
    using System.Collections.Generic;
    public class OrdersProductsMap
    {
        public int OrderProductsCategoriesId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductMSRP { get; set; }
        public virtual Order   Order  { get; set; }
        public virtual Products Product{ get; set; }
    }
}
