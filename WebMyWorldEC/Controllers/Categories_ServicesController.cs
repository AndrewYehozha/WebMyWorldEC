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
    public class Categories_ServicesController : Controller
    {
        // GET: Categories_Services
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Categories/GetCategoriesServices").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoriesServicesResponse>(responseString);

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

        // GET: Categories_Services/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                var responseString = await (Data.URL + "Categories/GetCategoriesServices").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoriesServicesResponse>(responseString);

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

        // GET: Categories_Services/Create
        public ActionResult Create()
        {
            var responseString1 = Task.Run(() => ((Data.URL + "Categories/GetCategories").WithHeader("Authorization", Data.Token).GetStringAsync()));
            var categoriesSuccsess = JsonConvert.DeserializeObject<CategoryResponse>(responseString1.Result);

            var responseString2 = Task.Run(() => ((Data.URL + "Services/GetServices").WithHeader("Authorization", Data.Token).GetStringAsync()));
            var servicesSuccsess = JsonConvert.DeserializeObject<ServicesResponse>(responseString2.Result);

            ViewBag.IdCategories = new SelectList(categoriesSuccsess.data, "Id", "Name");
            ViewBag.IdServices = new SelectList(servicesSuccsess.data, "Id", "Name");

            return View();
        }

        // POST: Categories_Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdCategories,IdServices")] Categories_Services categories_Services)
        {
            try
            {
                await (Data.URL + "Categories/AddCategoryToService").WithHeader("Authorization", Data.Token).PostJsonAsync(categories_Services);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Categories_Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var responseString1 = await (Data.URL + "Categories/GetCategoryService?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoriesServicesResponseOne>(responseString1);

                var responseString2 = await (Data.URL + "Categories/GetCategories").WithHeader("Authorization", Data.Token).GetStringAsync();
                var categoriesSuccsess = JsonConvert.DeserializeObject<CategoryResponse>(responseString2);

                if (userSuccsess == null || categoriesSuccsess == null)
                {
                    return HttpNotFound();
                }

                ViewBag.IdCategories = new SelectList(categoriesSuccsess.data, "Id", "Name", userSuccsess.data.IdCategories);

                return View(userSuccsess.data);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // POST: Categories_Services/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCategories,Id")] DataCategoriesServices categories_Services)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Categories/EditCategoryToService").WithHeader("Authorization", Data.Token).PostJsonAsync(categories_Services);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Edit/" + categories_Services.Id);
                }

                return View(categories_Services);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Categories_Services/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                var responseString = await (Data.URL + "Categories/GetCategoryService?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<CategoriesServicesResponseOne>(responseString);

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

        // POST: Categories_Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Categories/DeleteCategoryService?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
