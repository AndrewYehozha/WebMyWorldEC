using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMyWorldEC.Models.Response
{
    public class ServicesToECResponse
    {
        public bool Success { get; set; }
        public List<DataServicesToEC> data { get; set; }
    }

    public class ServicesToECResponseOne
    {
        public bool Success { get; set; }
        public DataServicesToEC data { get; set; }
    }

    public class DataServicesToEC
    {
        public Nullable<int> ServiceId { get; set; }
        public int Id { get; set; }
        public Nullable<int> Entertainment_CenterId { get; set; }

        public DataEntertainment_Centers Entertainment_Centers { get; set; }
        public DataServices Service { get; set; }
    }
}