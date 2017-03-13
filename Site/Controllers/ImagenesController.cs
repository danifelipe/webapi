using ClassLibrary.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ImagenesController : Controller
    {
        // GET: Imagenes
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult mostrar()
        {

            List<Musica> a = new List<Musica>();
            a.Add(new Musica { id = 1, nombre = "aa" });
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
    }
}