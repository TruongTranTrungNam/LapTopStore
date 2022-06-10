using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LapTopStore.Models;

namespace LapTopStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private ILapTopStoreRepository repository;
        public GenreNavigation(ILapTopStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Laptops
            .Select(x => x.LoaiMay)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}

    

