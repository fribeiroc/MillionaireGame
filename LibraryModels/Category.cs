using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        //One Category can attributed to many Questions 1-M
        public virtual ICollection<Product> Products { get; set; }
    }
}
