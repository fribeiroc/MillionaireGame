using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class BuyingCart
    {
        /*public BuyingCart() I want this logic in the API
        {
            new CartLine() { BuyingCartId = Id };
        }*/
        public int Id { get; set; }

        public bool IsBought { get; set; }

        //A cart is always associated to the same user 1-1
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        //A cart doesn't have any cart lines at the beginning, it will have one or more lines after
        public virtual ICollection<CartLine>? CartLines { get; set; }
    }
}
