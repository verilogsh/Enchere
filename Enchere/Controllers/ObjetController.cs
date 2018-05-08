using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enchere.Models;
using Enchere.Models.ViewModel;
using Enchere.Dal;
using Enchere.Utility;

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

        [HttpGet]
        public ActionResult gestionObjetMembre() {
            string currentUser = @User.Identity.Name;
            List<Objet> list = new List<Objet>();
            list = ObjetRequtte.getObjetMembre("aa@aa.com", "none");
            return View(list);
        }

        [HttpGet]
        public ActionResult Create() {
            List<Categorie> list = ObjetRequtte.getCategorie();
            ViewBag.listCateg = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ObjetViewModel model) {
            string currentUser = @User.Identity.Name;
            //Membre mb = MembreRequette.GetUserByEmail(currentUser);
            Membre mb = new Membre();
            mb.Id = "AAAA";
            ObjetRequtte.SavePhoto(model.Photo);
            ObjetRequtte.SavePiece(model.Piece);
            Objet obj = new Objet(IdGenerator.getObjetId(), model.Nom.Trim(), model.Description.Trim(), DateTime.Now, model.Categorie.Trim(), model.Photo.FileName.Trim(), model.Piece.FileName.Trim(), mb.Id.Trim(), true, false, model.PrixDepart);
            ObjetRequtte.insertObjet(obj);
            return View();
        }

    }
}
