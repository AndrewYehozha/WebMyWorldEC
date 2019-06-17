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
    public class Entertainment_CentersController : Controller
    {
        // GET: Entertainment_Centers1
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Entertainment_Centers/GetEntertainment_Centers").WithHeader("Authorization", Data.Token).GetStringAsync();
                var eCenterSuccsess = JsonConvert.DeserializeObject<Entertainment_CentersResponse>(responseString);

                if (eCenterSuccsess == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                return View(eCenterSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Entertainment_Centers1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Entertainment_Centers/GetEntertainment_Center?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var eCenterSuccsess = JsonConvert.DeserializeObject<Entertainment_CentersResponseOne>(responseString);

                if (eCenterSuccsess == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                return View(eCenterSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Entertainment_Centers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entertainment_Centers1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Owner,Address,Phone,Email,IsParking")] Entertainment_Centers entertainment_Centers)
        {
            try
            {
                await (Data.URL + "Entertainment_Centers/AddEntertainment_Center").WithHeader("Authorization", Data.Token).PostJsonAsync(entertainment_Centers);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Entertainment_Centers1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Entertainment_Centers/GetEntertainment_Center?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var eCenterSuccsess = JsonConvert.DeserializeObject<Entertainment_CentersResponseOne>(responseString);

                if (eCenterSuccsess == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                return View(eCenterSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Entertainment_Centers1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Owner,Address,Phone,Email,IsParking")] DataEntertainment_Centers entertainment_Centers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Entertainment_Centers/EditEntertainment_Center").WithHeader("Authorization", Data.Token).PostJsonAsync(entertainment_Centers);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(entertainment_Centers);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Entertainment_Centers1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var responseString = await (Data.URL + "Entertainment_Centers/GetEntertainment_Center?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var eCenterSuccsess = JsonConvert.DeserializeObject<Entertainment_CentersResponseOne>(responseString);

                if (eCenterSuccsess == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                return View(eCenterSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Entertainment_Centers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Entertainment_Centers/DeleteEntertainment_Center?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
