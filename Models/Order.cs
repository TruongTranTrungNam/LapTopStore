using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LapTopStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Nhập Tên của bạn")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Nhập địa chỉ của bạn")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Display(Name = "Thành phố")]
        [Required(ErrorMessage = "Nhập thành phố của bạn")]
        public string City { get; set; }
        [Display(Name = "Quận và huyện")]
        [Required(ErrorMessage = "Nhập quận huyện của bạn")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Display(Name = "Đất nước")]
        [Required(ErrorMessage = "Nhập đất nước của bạn")]
        public string Country { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}
