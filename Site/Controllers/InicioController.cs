using ClassLibrary.Modelo;
using Site.Suscriptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult guardar(Musica objeto)
        {
            MusicaSuscriptor obj = new MusicaSuscriptor();
            int a =0;
            a=obj.guardar();
            return RedirectToAction("Index","Inicio");
        }
    }
}