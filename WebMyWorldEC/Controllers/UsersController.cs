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
    public class UsersController : Controller
    {
        // GET: Users
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseString = await (Data.URL + "Users/GetUsers").WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<UserResponse>(responseString);

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

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Users/GetUser?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<UserResponseOne>(responseString);
                
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

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FirstName,LastName,Email,IsAdministration,BonusScore,Password")] DataUser user)
        {
            try
            {
                await (Data.URL + "Users/AddUser").WithHeader("Authorization", Data.Token).PostJsonAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var responseString = await (Data.URL + "Users/GetUser?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<UserResponseOne>(responseString);

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

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Country,City,Address,Phone,Email,Birsday,IsBlocked,IsAdministration,BonusScore,Password")] DataUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseString = await (Data.URL + "Users/EditUserForAdmin").WithHeader("Authorization", Data.Token).PostJsonAsync(user);

                    if (responseString.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(user);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var responseString = await (Data.URL + "Users/GetUser?id=" + id).WithHeader("Authorization", Data.Token).GetStringAsync();
                var userSuccsess = JsonConvert.DeserializeObject<UserResponseOne>(responseString);
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await (Data.URL + "Users/DeleteUser?id=" + id).WithHeader("Authorization", Data.Token).DeleteAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }
    }
}
