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
    public class CategoriesController : Controller
    {
        // GET: Categories
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Categories/GetCategories").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoryResponse>(responseString);

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

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Categories/GetCategory?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoryResponseOne>(responseString);

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

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] DataCategory category)
        {
            try
            {
                await (Data.URL + "Categories/AddCategory").WithHeader("Authorization", Data.Token).PostJsonAsync(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Categories/GetCategory?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoryResponseOne>(responseString);

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

        // POST: Categories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] DataCategory category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Categories/EditCategory").WithHeader("Authorization", Data.Token).PostJsonAsync(category);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(category);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var responseString = await (Data.URL + "Categories/GetCategory?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoryResponseOne>(responseString);
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

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Categories/DeleteCategory?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
