using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using LapTopStore.Models;
using System.Linq;
using LapTopStore.Models.ViewModels;
using System.Threading.Tasks;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;


namespace LapTopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly LapTopStoreDbContext _context;
        private readonly LapTopStoreDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private ILapTopStoreRepository repository;
        public int PageSize = 9;
        public HomeController(ILapTopStoreRepository repo , LapTopStoreDbContext context, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index(string genre,int laptopPage = 1)
            => View(new LaptopsListViewModel
            {
                Laptops = repository.Laptops
                .Where(p => genre == null || p.LoaiMay == genre)
                .OrderBy(p => p.LaptopID)
                .Skip((laptopPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = laptopPage,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    repository.Laptops.Count() :
                    repository.Laptops.Where(e =>
                            e.LoaiMay == genre).Count()
                },
                CurrentGenre = genre
            });

        public IActionResult TrangChu(string genre, int laptopPage = 1)
           => View(new LaptopsListViewModel
           {
               Laptops = repository.Laptops
               .Where(p => genre == null || p.LoaiMay == genre)
               .OrderBy(p => p.LaptopID)
               .Skip((laptopPage - 1) * PageSize)
               .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = laptopPage,
                   ItemsPerPage = PageSize,
                   TotalItems = genre == null ?
                   repository.Laptops.Count() :
                   repository.Laptops.Where(e =>
                           e.LoaiMay == genre).Count()
               },
               CurrentGenre = genre
           });

        public async Task<IActionResult> TimKiem(string searchString)
        {
            var laptop = from b in repository.Laptops
                         select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                laptop = laptop.Where(s => s.TenSP!.Contains(searchString));
            }
            return View(await laptop.ToListAsync());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created(LaptopsViewModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Laptop laptop = new Laptop
                {

                    TenSP = model.TenSP,
                    CauHinh = model.CauHinh,
                    LoaiMay = model.LoaiMay,
                    GiaTien = model.GiaTien,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(laptop);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

         // GET: Laptops/Details/5
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.LaptopID == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Details2/5
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.LaptopID == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }


        private string UploadedFile(LaptopsViewModels model)
        {
            string uniqueFileName = null;

            if (model.ImageLaptop != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageLaptop.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageLaptop.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
    