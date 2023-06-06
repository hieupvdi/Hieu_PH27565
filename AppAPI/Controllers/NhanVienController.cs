using AppData.Context;
using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
using Microsoft.AspNetCore.Mvc;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        INhanVienRepositories<NhanVien> irepos;
        // Tạo luôn DbContext để không bị null
        NhanvienContext context =
            new NhanvienContext();
        public NhanVienController()
        {
            // Tạo 1 AllRepo để gán cho IALlrepo (Dependency Injection)
            NhanVienRepositories<NhanVien> repos =
                new NhanVienRepositories<NhanVien>(context, context.NhanViens);
            irepos = repos;
        }
        [HttpGet("get-all-Nhanvien")]
        public IEnumerable<NhanVien> GetAll()
        {
            return irepos.GetAllItem();
        }
        [HttpGet("getByid-Nhanvien/{id}")]
        public IActionResult GetById(Guid id)
        {
            var nhanvien = irepos.GetById(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return Ok(nhanvien);
        }
        [HttpPost("create-Nhanvien")]
        public bool CreateNhanvien(string Ten, int Tuoi, int Role, string Email,int Luong, bool Trangthai)
        {
            NhanVien Nv = new NhanVien();
            Nv.Id = Guid.NewGuid(); // ID tự sinh
            Nv.Ten = Ten;
            Nv.Tuoi = Tuoi;
            Nv.Role = Role;
            Nv.Email = Email;
            Nv.Luong = Luong;   
            Nv.Trangthai = Trangthai;
            return irepos.CreateItem(Nv);
        }

        [HttpPut("Update-Nhanvien")]
        public bool UpdateNhanvien(Guid Id, string Ten, int Tuoi, int Role, string Email, int Luong, bool Trangthai)
        {
            NhanVien Nv = new NhanVien();
            Nv.Id=Id;
            Nv.Ten = Ten;
            Nv.Tuoi = Tuoi;
            Nv.Role = Role;
            Nv.Email = Email;
            Nv.Luong = Luong;
            Nv.Trangthai = Trangthai;
            return irepos.UpdateItem(Nv);
        }

        [HttpDelete("Delete-Nhanvien")]
        public bool DeleteNhanvien(Guid Id)
        {
            NhanVien Nv = new NhanVien();
            Nv.Id = Id;
            return irepos.DeleteItem(Nv);
        }

        [HttpGet("tinh-BMI ")]
        public float BMINhanvien(float weight, float height)
        {
            float bmi = 0;
            return weight / (height * height);
             
        }

    }
}
