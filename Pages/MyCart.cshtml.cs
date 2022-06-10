using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LapTopStore.MyTagHelper;
using LapTopStore.Models;
using System.Linq;

namespace LapTopStore.Pages
{
    public class MyCartModel : PageModel
    {
        private ILapTopStoreRepository repository;
        public MyCartModel(ILapTopStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService; 
        }
        public MyCart myCart { get; set; }

        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
        }
        public IActionResult OnPost(long laptopId, string returnUrl)
        {
            Laptop laptop = repository.Laptops
            .FirstOrDefault(l => l.LaptopID == laptopId);
            //myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
            myCart.AddItem(laptop, 1);
            //HttpContext.Session.SetJson("mycart", myCart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long laptopId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Laptop.LaptopID == laptopId).Laptop);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}