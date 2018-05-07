using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enchere.Models;
using Enchere.Dal;

namespace Enchere.Controllers
{
    public class ObjetController : Controller
    {
        // GET: Objet
        [HttpGet]
        public ActionResult lireCategorie()
        {
           // List<Categorie> list = new List<Categorie>();
           // list = ObjetRequtte.getCategorie();
            return Json(ObjetRequtte.getCategorie(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult lireObjetEnVente(int idCategorie) {
            List<ObjetEnchereAff> list = new List<ObjetEnchereAff>();
            list = ObjetRequtte.getObjetEnVente(idCategorie);
            return Json(ObjetRequtte.getObjetEnVente(idCategorie), JsonRequestBehavior.AllowGet);
        }
    }
}
