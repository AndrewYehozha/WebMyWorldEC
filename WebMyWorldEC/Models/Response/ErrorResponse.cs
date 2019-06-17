using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public int ErrorNum { get; set; }
        public string ErrorMessages { get; set; }
    }
}