using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public DataAuth data { get; set; }
    }

    public class DataAuth
    {
        public string Token { get; set; } 
        public int UserId { get; set; }
        public bool IsAdmin { get; set; } 
    }
}