using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMyWorldEC.Models;
using Flurl.Http;
using Newtonsoft.Json;
using WebMyWorldEC.Models.Response;

namespace WebMyWorldEC.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments1
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Payments/GetPayments").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<PaymentResponse>(responseString);

                if (userSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(userSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Payments1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Payments/GetPayment?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<PaymentResponseOne>(responseString);

                if (userSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(userSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
