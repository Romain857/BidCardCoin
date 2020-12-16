using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class Produit_CategorieDAL
    {
        public Produit_CategorieDAL()
        { }

        public static ObservableCollection<Produit_CategorieDAO> selectProduit_Categorie()
        {
            ObservableCollection<Produit_CategorieDAO> l = new ObservableCollection<Produit_CategorieDAO>();
            string query = "SELECT * FROM produit_categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Produit_CategorieDAO p = new Produit_CategorieDAO(reader.GetInt32(0), reader.GetInt32(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème dans la table : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static Produit_CategorieDAO getProduit_Categorie(int id)
        {
            string query = "SELECT * FROM produit_categorie WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Produit_CategorieDAO cat = new Produit_CategorieDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return cat;
        }
        /*public static void updateProduit_Categorie(Produit_CategorieDAO p)
        {
            string query = "UPDATE produit_categorie set idProduit=\"" + p.idProduitDAO + "\", idCategorie=\"" + p.idCategorieDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }*/
        public static void insertProduit_Categorie(Produit_CategorieDAO p)
        {
            string query = "INSERT INTO produit_categorie VALUES (\"" + p.idProduitDAO + "\",\"" + p.idCategorieDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit_Categorie(int idProduitProperty, int idCategorieProperty)
        {
            string query = "DELETE FROM produit_categorie WHERE idProduit = \"" + idProduitProperty + "\"AND idCategorie = \"" + idCategorieProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
