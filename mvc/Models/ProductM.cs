using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductWebApplication.Models
{
    public class ProductM
    {
        [Key]
        public int ProductId { set; get; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ProductName is must")]
        [StringLength(50, ErrorMessage = "must not exceded than this")]
        public string ProductName { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Rate is must")]
        [Range(8, 2, ErrorMessage = "must in limit")]
        public decimal Rate { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Description is must")]
        [StringLength(50, ErrorMessage = "must not exceded than this")]
        public string Description { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Categoryname is must")]
        [StringLength(50, ErrorMessage = "must not exceded than this")]
        public string CategoryName { set; get; }





    }
}