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
using Flurl.Http;
using WebMyWorldEC.Models.Response;

namespace WebMyWorldEC.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Services/GetServices").WithHeader("Authorization", Data.Token).GetStringAsync();
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponse>(responseString);

                if (servicesSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(servicesSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Services/GetService?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponseOne>(responseString);

                if (servicesSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(servicesSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Cost,Floor,Hall")] DataServices service)
        {
            try
            {
                await (Data.URL + "Services/AddService").WithHeader("Authorization", Data.Token).PostJsonAsync(service);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Services/GetService?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponseOne>(responseString);

                if (servicesSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(servicesSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Services/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Cost,Floor,Hall,AgeFrom")] DataServices service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Services/EditService").WithHeader("Authorization", Data.Token).PostJsonAsync(service);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(service);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Services/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var responseString = await (Data.URL + "Services/GetService?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponseOne>(responseString);
                if (servicesSuccsess == null)
                {
                    return HttpNotFound();
                }

                return View(servicesSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Services/DeleteService?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
