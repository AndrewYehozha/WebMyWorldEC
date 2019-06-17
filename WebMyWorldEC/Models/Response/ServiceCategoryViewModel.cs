using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class ServiceCategoryViewModel : ServicesResponse
    {
        public virtual IEnumerable<CategoryResponse> Categories { get; set; }
        public decimal Rating { get; set; }
        public decimal? userRating { get; set; }
    }
}