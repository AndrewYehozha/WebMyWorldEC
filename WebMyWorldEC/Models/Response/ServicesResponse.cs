using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class ServicesResponse
    {
        public bool Success { get; set; }
        public List<DataServices> data { get; set; }
    }

    public class ServicesResponseOne
    {
        public bool Success { get; set; }
        public DataServices data { get; set; }
    }

    public class DataServices
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Service Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Cost is required")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "The Floor is required")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "The Hall is required")]
        public int Hall { get; set; }
        [Required(ErrorMessage = "The AgeFrom is required")]
        public int AgeFrom { get; set; }
    }
}