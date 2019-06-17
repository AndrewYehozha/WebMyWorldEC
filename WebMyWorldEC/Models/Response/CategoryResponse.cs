using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class CategoryResponse
    {
        public bool Success { get; set; }
        public List<DataCategory> data { get; set; }
    }

    public class CategoryResponseOne
    {
        public bool Success { get; set; }
        public DataCategory data { get; set; }
    }

    public class DataCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}