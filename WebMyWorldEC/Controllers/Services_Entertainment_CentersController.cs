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
using Newtonsoft.Json;
using WebMyWorldEC.Models.Response;
using Flurl.Http;

namespace WebMyWorldEC.Controllers
{
    public class Services_Entertainment_CentersController : Controller
    {
        // GET: Services_Entertainment_Centers
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Entertainment_Centers/GetServicesToEC").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<ServicesToECResponse>(responseString);

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

        // GET: Services_Entertainment_Centers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                var responseString = await (Data.URL + "Entertainment_Centers/GetServiceToEC?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<ServicesToECResponseOne>(responseString);

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

        // GET: Services_Entertainment_Centers/Create
        public ActionResult Create()
        {
            try
            {
                var responseString1 = Task.Run(() => ((Data.URL + "Entertainment_Centers/GetEntertainment_Centers").WithHeader("Authorization", Data.Token).GetStringAsync()));
                var ECSuccsess = JsonConvert.DeserializeObject<Entertainment_CentersResponse>(responseString1.Result);

                var responseString2 = Task.Run(() => ((Data.URL + "Services/GetServices").WithHeader("Authorization", Data.Token).GetStringAsync()));
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponse>(responseString2.Result);

                ViewBag.Entertainment_CenterId = new SelectList(ECSuccsess.data, "Id", "Name");
                ViewBag.ServiceId = new SelectList(servicesSuccsess.data, "Id", "Name");

                return View();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Services_Entertainment_Centers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServiceId,Entertainment_CenterId")] DataServicesToEC servicesToEC)
        {
            try
            {
                await (Data.URL + "Entertainment_Centers/AddServiceToEntertainment_Center").WithHeader("Authorization", Data.Token).PostJsonAsync(servicesToEC);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services_Entertainment_Centers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var responseString1 = await (Data.URL + "Entertainment_Centers/GetServiceToEC?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<ServicesToECResponseOne>(responseString1);

                var responseString2 = Task.Run(() => ((Data.URL + "Services/GetServices").WithHeader("Authorization", Data.Token).GetStringAsync()));
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponse>(responseString2.Result);

                if (userSuccsess == null || servicesSuccsess == null)
                {
                    return HttpNotFound();
                }

                ViewBag.ServiceId = new SelectList(servicesSuccsess.data, "Id", "Name", userSuccsess.data.ServiceId);

                return View(userSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Services_Entertainment_Centers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServiceId,Id,Entertainment_CenterId")] Services_Entertainment_Centers services_Entertainment_Centers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Entertainment_Centers/EditServiceToEC").WithHeader("Authorization", Data.Token).PostJsonAsync(services_Entertainment_Centers);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Edit/" + services_Entertainment_Centers.Id);
                }

                return View(services_Entertainment_Centers);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services_Entertainment_Centers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                var responseString = await (Data.URL + "Entertainment_Centers/GetServiceToEC?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<ServicesToECResponseOne>(responseString);

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

        // POST: Services_Entertainment_Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Entertainment_Centers/DeleteServiceToEC?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
