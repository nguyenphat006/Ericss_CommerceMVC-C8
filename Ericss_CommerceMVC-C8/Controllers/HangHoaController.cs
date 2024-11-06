using Ericss_CommerceMVC_C8.Data;
using Ericss_CommerceMVC_C8.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ericss_CommerceMVC_C8.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly EricssEcommerceContext db;

        public HangHoaController(EricssEcommerceContext context)
        {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHh,
                TenHH = p.TenHh,
                Hinh = p.Hinh ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai,
                Motangan = p.MoTaDonVi ?? ""
            });
            return View(result);
        }
    }
}
