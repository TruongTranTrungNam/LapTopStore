using System.Collections.Generic;
namespace LapTopStore.Models.ViewModels
{
    public class LaptopsListViewModel
    {
        public IEnumerable<Laptop> Laptops { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}