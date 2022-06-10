using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LapTopStore.Models
{
    public class Laptop
    {
        [Key]

        
        public long LaptopID { get; set; }
        [Display(Name = "Tên Sản phẩm")]
        [Required(ErrorMessage = "Nhập Tên sản phẩm")]
        
        public string TenSP { get; set; }
        [Display(Name = "Cấu Hình")]
        [Required(ErrorMessage = "Nhập Cấu hình")]
        public string CauHinh { get; set; }
        [Display(Name = "Giá Tiền")]
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Nhập Giá tiền")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaTien { get; set; }
        [Display(Name = "Loại Máy")]
        [Required(ErrorMessage = "Nhập Loại máy")]
        public string LoaiMay { get; set; }
        public string ProfilePicture { get; set; }
       
    }
}
