using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public  class NhanVien
    {
        [Required(ErrorMessage = "id trống")]
        public Guid Id { get; set; }
        [StringLength(30, ErrorMessage = "Tối đa 30 kí tự")]
        public string Ten { get; set; }
        [Range(18,50, ErrorMessage = "tuổi phải nhập từ 18 đến 50")]
        public int Tuoi { get; set; }
        [Required(ErrorMessage = "Role trống")]
        public int Role { get; set; }
        [EmailAddress(ErrorMessage = "Email sai format")]
        public string Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "Lương từ 5.000.000 đến 30.000.000")]
        public int Luong { get; set; }
        [Required(ErrorMessage = "Trang thai trống")]
        public bool Trangthai { get; set; }

    }
}
