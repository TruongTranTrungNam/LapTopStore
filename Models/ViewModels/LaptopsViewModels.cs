using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LapTopStore.Models.ViewModels
{
    public class LaptopsViewModels
    {
        [Key]
        public long LaptopID { get; set; }
        [Required(ErrorMessage = "Nhập Tên Sản phẩm")]
        [Display(Name = "Tên Sản phẩm")]
        public string TenSP { get; set; }
        [Required(ErrorMessage = "Nhập Cấu hình")]
        [Display(Name = "Cấu hình")]
        public string CauHinh { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Giá Tiền")]
        public decimal GiaTien { get; set; }
        [Required(ErrorMessage = "Nhập Loại máy")]
        [Display(Name = "Loại Máy")]
        public string LoaiMay { get; set; }
        [Required(ErrorMessage = "Hãy chọn một bức hình")]
        [Display(Name = "Hình ảnh Laptop")]
        public IFormFile ImageLaptop { get; set; }
    }
}
