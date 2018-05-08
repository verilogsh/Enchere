using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enchere.Models.ViewModel {
    public class ObjetViewModel {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
        public decimal PrixDepart { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public HttpPostedFileBase Piece { get; set; }

    }
}