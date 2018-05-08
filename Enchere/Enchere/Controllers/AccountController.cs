﻿using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Enchere.Dal;
using System.Threading;
using System.Globalization;
using Enchere.Models.ViewModel;
using Enchere.Models;
using System;

namespace Enchere.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        string str;

        public AccountController() {
        }

        public static void CreateCulture(string str) {
            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }

        }



        public ActionResult Login() {  //string ReturnUrl = ""
            ViewBag.error = "";
            //ViewBag.ReturnUrl = ReturnUrl;
            /*
            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            string cookie = "";
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
                ViewBag.cookie = cookie;
                CreateCulture(cookie);
            }
            else CreateCulture(str);  */
            return View();
        }


        //
        [HttpPost]
        public ActionResult Login(string username, string password, string ReturnUrl = "") {
            /*
                        str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                      string cookie = "";
                        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                            cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
                            ViewBag.cookie = cookie;
                            CreateCulture(cookie);
                        }
                        else CreateCulture(str);  */

            ViewBag.error = "";
            ViewBag.ReturnUrl = ReturnUrl;
            if (!MembreRequette.Authentifie(username, password)) {
                ViewBag.error = "Nom d'utilisateur ou mot de passe invalide!";
                return View();
            }
            else {
                FormsAuthentication.SetAuthCookie(username, false);
                if (ReturnUrl == "") {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return Redirect(ReturnUrl);
                }
            }
        }



        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Inscription() {
            /*
                        str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                        string cookie = "";
                        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                            cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
                            ViewBag.cookie = cookie;
                            CreateCulture(cookie);
                        }
                        else CreateCulture(str);  */

            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Membre u) {
            if (ModelState.IsValid) {
                MembreRequette.Add(u);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //  [Authorize]
        [HttpGet]
        public ActionResult Modifier() {
            Membre u = MembreRequette.GetUserByEmail(User.Identity.Name);
            // ViewBag.Courriel = User.Identity.Name;
            //  ViewBag.Nom = u.Nom;

            /*    str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                if (User.Identity.IsAuthenticated && u != null) str = u.Langue;
                string cookie = "";
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
                    ViewBag.cookie = cookie;
                    CreateCulture(cookie);
                }
                else CreateCulture(str);  */


            return View(u);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Modifier(Membre m) {
            // Membre u = MembreRequette.GetUserByEmail(User.Identity.Name);
            if (ModelState.IsValid) {
                MembreRequette.Update(m);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ModifierMDP() {
            Membre u = MembreRequette.GetUserByEmail(User.Identity.Name);
            MembreMDP mmdp = new MembreMDP(u);
            ViewBag.Nom = u.Nom;
            /*    str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                if (User.Identity.IsAuthenticated && u != null) str = u.Langue;
                string cookie = "";
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                    cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
                    ViewBag.cookie = cookie;
                    CreateCulture(cookie);
                }
                else CreateCulture(str);  */


            return View(mmdp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifierMDP(MembreMDP u) {
            Membre m = MembreRequette.GetUserByEmail(User.Identity.Name);
            if (ModelState.IsValid) {
                MembreRequette.UpdateMDP(u, m);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult ListeUsers(string order) {
            ViewBag.NomOrder = "nom";
            ViewBag.NomOrder = String.IsNullOrEmpty(order) ? "nom" : "";
            ViewBag.CiviliteOrder = "civilite";
            ViewBag.PrenomOrder = "prenom";
            ViewBag.LangueOrder = "Langage";
            ViewBag.CourrielOrder = "courriel";
            ViewBag.InscriptionOrder = "DateInscri";
            ViewBag.CoteOrder = "cote";
            if (order == null) order = "nom";
            ViewBag.Users = MembreRequette.lesMembres(order);
            return View();

        }

        [HttpGet]
        public ActionResult DeleteUser() {
           string nr = Request.QueryString["Numero"];      
            Membre m = MembreRequette.GetUserByNumero(nr);

            return View(m);
        }

        [HttpPost]
        public ActionResult DeleteUser(Membre m) {

            MembreRequette.Supprimer(m);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit() {
            string nr = Request.QueryString["Numero"];
            Membre u = MembreRequette.GetUserByNumero(nr);
            return View(u);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Membre m) {

            if (MembreRequette.UpdateFromAdmin(m))
                return RedirectToAction("Index", "Home");


            return View();
        }
    }
}