using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class UserResponse
    {
        public bool Success { get; set; }
        public List<DataUser> data { get; set; }
    }

    public class UserResponseOne
    {
        public bool Success { get; set; }
        public DataUser data { get; set; }
    }

    public class DataUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Surname is required")]
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+)?(\d{10})(\d{1,4})?$", ErrorMessage = "Invalid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Birsday { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime DateRegistered { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdministration { get; set; }
        public int BonusScore { get; set; }
        public string Password { get; set; }
    }
}