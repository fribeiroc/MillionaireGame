using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a product name.")]
        [MaxLength(35, ErrorMessage = "The product name must not exceed 35 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the description of the product.")]
        [MaxLength(255, ErrorMessage = "The description must not exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide the price of the product.")]
        #region DoubleAnnotation as explained in https://stackoverflow.com/questions/19811180/best-data-annotation-for-a-decimal18-2
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "You can only provide two decimal values on the price.")] //only allow two decimal values in the number
        [Range(0, 9999999999999999.99, ErrorMessage = "Provide a price below 9999999999999999.99.")] //maxlength = 18 units
        #endregion
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Specify how many stock the product has.")]
        public int Stock { get; set; }

        //One Product can be attributed in many Cart lines 1-M
        public virtual ICollection<CartLine>? CartLines { get; set; }

        //One Product only has one Category 1-M
        [Required(ErrorMessage = "Specify a category for the product")]
        public virtual int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
