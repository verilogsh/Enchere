﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enchere.Models {
    public class ObjetEnchereAff {

        public ObjetEnchereAff(string id, string idEnchere, string nom, string description, string idCategorie, string photo, string piece, string idVendeur, string idAcheteur, decimal prixDepart, decimal prixActuel, DateTime dateDepart, int dureeVente, decimal pasDePrix) {
            Id = id;
            IdEchere = idEnchere;
            Nom = nom;
            Description = description;
            IdCategorie = idCategorie;
            Photo = photo;
            Piece = piece;
            IdVendeur = idVendeur;
            IdAcheteur = idAcheteur;
            PrixDepart = prixDepart;
            PrixActuel = prixActuel;
            DateDepart = dateDepart;
            DureeVente = dureeVente;
            PasDePrix = pasDePrix;
        }

        public string Id { get; set; }
        public string IdEchere { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string IdCategorie { get; set; }
        public string Photo { get; set; }
        public string Piece { get; set; }
        public string IdVendeur { get; set; }
        public string IdAcheteur { get; set; }
        public decimal PrixDepart { get; set; }
        public decimal PrixActuel { get; set; }
        public DateTime DateDepart { get; set; }
        public int DureeVente { get; set; }
        public decimal PasDePrix { get; set; }
    }
}