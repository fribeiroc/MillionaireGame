using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class CartLine
    {
        public int Id { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }

        //A cart line can only have one product
        public virtual int? ProductId { get; set; }

        public virtual Product? Product { get; set; }

        //A cart line can only be in one Cart
        public virtual int? BuyingCartId { get; set; }

        public virtual BuyingCart? BuyingCart { get; set; }
    }
}
