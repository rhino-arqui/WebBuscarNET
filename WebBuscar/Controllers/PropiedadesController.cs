using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebBuscar.Models;

namespace WebBuscar.Controllers
{
    public class PropiedadesController : Controller
    {
        // GET: Rentas
        public ActionResult Index()
        {
            IEnumerable<Client> libro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.13:8080/NegocioOPR/api/clients/");
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Client>>();
                    readTask.Wait();

                    libro = readTask.Result;
                    System.Diagnostics.Debug.WriteLine(libro.ToString());
                }
                else //web api sent error response 
                {
                    //log response status here..

                    libro = Enumerable.Empty<Client>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(libro);
        }

        // GET: Rentas/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Property> libro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.13:8080/NegocioOPR/api/properties/");
                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Property>>();
                    readTask.Wait();

                    libro = readTask.Result;
                    System.Diagnostics.Debug.WriteLine(libro.ToString());
                }
                else //web api sent error response 
                {
                    //log response status here..

                    libro = Enumerable.Empty<Property>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(libro);
        }

        // GET: Rentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rentas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rentas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rentas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rentas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rentas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
