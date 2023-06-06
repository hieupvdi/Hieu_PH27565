using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppVIew.Controllers
{
    public class NhanVienController : Controller
    {
        public NhanVienController()
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            string apiURL ="https://localhost:7133/api/NhanVien/get-all-Nhanvien";
            // Sau khi có URL thì thực hiện việc lấy dữ liệu trả về từ nó
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(apiURL); // Lấy kết quả
                                                              // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhanVien nv)
        {
            if (!ModelState.IsValid)
                return View(nv);

            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7133/api/NhanVien/create-Nhanvien?Ten={nv.Ten}&Tuoi={nv.Tuoi}&Role={nv.Role}&Email={nv.Email}&Luong={nv.Luong}&Trangthai={nv.Trangthai}";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(nv);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7133/api/NhanVien/getByid-Nhanvien/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(NhanVien nv)
        {

            if (!ModelState.IsValid) return View(nv);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7133/api/NhanVien/Update-Nhanvien?Id={nv.Id}&Ten={nv.Ten}&Tuoi={nv.Tuoi}&Role={nv.Role}&Email={nv.Email}&Luong={nv.Luong}&Trangthai={nv.Trangthai}";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(GiamGiaVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(nv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {


            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7133/api/NhanVien/Delete-Nhanvien?Id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai tiep roi be oi");
            return BadRequest();
        }
        //[HttpGet]
        //public  Task<IActionResult> BMINhanvien(float weight, float height)
        //{


        //    var httpClient = new HttpClient();
        //    string apiURL = $"https://localhost:7133/api/NhanVien/tinh-BMI ?weight={weight}&height={height}";

        //    var response = await httpClient.GetAsync(apiURL);

        //    string apiData = await response.Content.ReadAsStringAsync();
          
        //    return View(result);
        //}



  
    }
}
