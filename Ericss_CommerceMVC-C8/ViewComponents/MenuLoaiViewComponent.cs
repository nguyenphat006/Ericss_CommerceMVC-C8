using Ericss_CommerceMVC_C8.Data;
using Ericss_CommerceMVC_C8.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ericss_CommerceMVC_C8.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly EricssEcommerceContext db;
        public MenuLoaiViewComponent(EricssEcommerceContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var items = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai, 
                TenLoai = lo.TenLoai, 
                SoLuong = lo.HangHoas.Count
            });
            return View(items);
        }
    }
}
