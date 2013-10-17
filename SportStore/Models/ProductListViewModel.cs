using System.Collections.Generic;

namespace SportStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<DomainModel.DAL.Product> Products { get; set; }

        public int CurrentPage { get; set; }

        public string CurrentCategory { get; set; }

        public int TotalPagesCount { get; set; }
    }
}