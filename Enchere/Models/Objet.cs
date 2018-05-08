using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enchere.Models {
    public class Objet {

        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateInscri { get; set; }
        public string Categorie { get; set; }
        public string Photo { get; set; }
        public string Piece { get; set; }
        public string IdMembre { get; set; }
        public bool Nouveau { get; set; }
        public bool EnVente { get; set; }
        public Decimal PrixDepart { get; set; }

        public Objet(string id, string nom,  string description, DateTime dateInscri, string categorie, string photo, string piece, string idMembre, bool nouveau, bool enVente, Decimal prixDepart) {
            Id = id;
            Nom = nom;
            Description = description;
            DateInscri = dateInscri;
            Categorie = categorie;
            Photo = photo;
            Piece = piece;
            IdMembre = idMembre;
            Nouveau = nouveau;
            EnVente = enVente;
            PrixDepart = prixDepart;
        }
    }
}