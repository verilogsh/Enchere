using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enchere.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Enchere.Dal {
    public class ObjetRequtte {

        public static List<Categorie> getCategorie() {
            List<Categorie> ctg = new List<Categorie>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string request = "SELECT * FROM Categorie";
            SqlCommand command = new SqlCommand(request, connection);

            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    ctg.Add(new Categorie((string)reader["Id"], (string)reader["Nom"], (string)reader["Description"]));
                }
                reader.Close();
                return ctg;
            } catch (Exception e) {
                System.Console.WriteLine(e.Message);
            } finally {
                connection.Close();
            }
            return null;
        }

        public static List<ObjetEnchereAff> getObjetEnVente(int idCategorie) {
            List<ObjetEnchereAff> obj = new List<ObjetEnchereAff>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string request;
            if (idCategorie == 0) {
                request = "SELECT o.Id, e.Id IdEnchere, o.Nom, o.Description, o.IdCategorie, o.Photo, o.Piece, o.IdMembre IdVendeur, e.IdMembre IdAcheteur, o.PrixDepart, e.PrixAchat, e.DateDepart, e.DureeVente, e.PasDePrix FROM Enchere e INNER JOIN Objet o ON o.Id = e.IdObjet";
            } else {
                request = "SELECT o.Id, e.Id IdEnchere, o.Nom, o.Description, o.IdCategorie, o.Photo, o.Piece, o.IdMembre IdVendeur, e.IdMembre IdAcheteur, o.PrixDepart, e.PrixAchat, e.DateDepart, e.DureeVente, e.PasDePrix FROM Enchere e INNER JOIN Objet o ON o.Id = e.IdObjet WHERE o.IdCategorie = " + idCategorie;
            }
            
            SqlCommand command = new SqlCommand(request, connection);

            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    obj.Add(new ObjetEnchereAff((string)reader["Id"], (string)reader["IdEnchere"], (string)reader["Nom"], (string)reader["Description"],  (string)reader["IdCategorie"], (string)reader["photo"], (string)reader["piece"], (string)reader["IdVendeur"], (string)reader["IdAcheteur"], (decimal)reader["PrixDepart"], (decimal)reader["PrixAchat"], (DateTime)reader["DateDepart"], (int)reader["DureeVente"], (decimal)reader["PasDePrix"]));
                }
                reader.Close();
                return obj;
            } catch (Exception e) {
                System.Console.WriteLine(e.Message);
            } finally {
                connection.Close();
            }
            return null;
        }
    }
}