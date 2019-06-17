using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class CategoriesServicesResponse
    {
        public bool Success { get; set; }
        public List<DataCategoriesServices> data { get; set; }
    }

    public class CategoriesServicesResponseOne
    {
        public bool Success { get; set; }
        public DataCategoriesServices data { get; set; }
    }

    public class DataCategoriesServices
    {
        public Nullable<int> IdCategories { get; set; }
        public Nullable<int> IdServices { get; set; }
        public int Id { get; set; }

        public DataCategory Category { get; set; }
        public DataServices Service { get; set; }
    }
}