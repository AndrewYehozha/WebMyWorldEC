using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class PaymentResponse
    {
        public bool Success { get; set; }
        public List<DataPayment> data { get; set; }
    }

    public class PaymentResponseOne
    {
        public bool Success { get; set; }
        public DataPayment data { get; set; }
    }

    public class DataPayment
    {
        public int Id { get; set; }
        public string Entert_CenterName { get; set; }
        public string ServiceName { get; set; }
        public string UserEmail { get; set; }
        public decimal Cost { get; set; }
        public System.DateTime PaymentDate { get; set; }
    }
}