using BusinessLayer;
using Entities;
using MyEvernote.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //CatrgoryController üzerinden gelen view ve model talebi
            //TempData["mm"] = cat.Notes;
            //return RedirectToAction("Index", "Home");

            NoteManager nm = new NoteManager();


            return View(nm.GetAllNotes().OrderByDescending(x => x.ModifiedOn).ToList());
            //  return View(nm.GetAllNoteQueryable().OrderByDescending(x => x.ModifiedOn).ToList()); //Sıralamayı Sql üstünde yapılmasını sağlıyor
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            CategoryManager cm = new CategoryManager();

            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index","Home");
            }
            return View("Index", cat.Notes.OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();

            return View("Index", nm.GetAllNotes().OrderByDescending(x => x.LikeCount).ToList());

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModal model)
        {
            //Giriş Kontrolü ve yönlendirme
            //Session a kullanıcı bilgi saklama

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModal model)
        {

            if (ModelState.IsValid)
            {
                //if (model.Username == "aaa")
                //{
                //    ModelState.AddModelError("", "Kullanıcı Adı kullanılıyor");
                   
                //}

                //if (model.Email == "aaa@aa.com")
                //{
                //    ModelState.AddModelError("", "Eposta adresi kullanılıyor");
                  
                //}

                //foreach (var item in ModelState)
                //{
                //    if(item.Value.Errors.Count>0)
                //    {
                //        return View(model);
                //    }

                //}

                return RedirectToAction("RegisterOk");
            }

            //kullanıcı username kontrolü
            //kullanıcı eposta kontrolü
            //kayıt işlemi
            //aktivasyon epostası gönderimi

            return View(model);
        }

        public ActionResult RegisterOk()
        {
            return View();
        }    

        public ActionResult UserActivate(Guid activate_id)
        {
            //Kullanıcı aktivasyonu sağlanacak
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}