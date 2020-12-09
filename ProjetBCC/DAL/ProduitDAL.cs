using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class ProduitDAL
    {
        public ProduitDAL()
        { }

        public static ObservableCollection<ProduitDAO> selectProduits()
        {
            ObservableCollection<ProduitDAO> l = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetInt32(0), reader.GetFloat(1), reader.GetFloat(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10));
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

        public static ProduitDAO getProduit(int id)
        {
            string query = "SELECT * FROM produit WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitDAO prod = new ProduitDAO(reader.GetInt32(0), reader.GetFloat(1), reader.GetFloat(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10));
            reader.Close();
            return prod;
        }
        public static void updateProduit(ProduitDAO p)
        {
            string query = "UPDATE produit set estimationActuelle=\"" + p.estimationActuelleDAO + "\", prixVente=\"" + p.prixVenteDAO + "\",nom=\"" + p.nomProduitDAO + "\", description=\"" + p.descriptionDAO +  "\", artiste=\"" + p.artisteDAO + "\", style=\"" + p.styleDAO + "\", isVendu=\"" + p.isVenduDAO + "\", idCategorie=\"" + p.idCategorieDAO + "\", idLot=\"" + p.idLotDAO + "\", idPhoto=\"" + p.idPhotoDAO + "\" where id=" + p.idDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduit(ProduitDAO p)
        {
            int id = getMaxIdProduit() + 1;
            string query = "INSERT INTO produit VALUES (\"" + id + "\",\"" + p.estimationActuelleDAO + "\",\"" + p.prixVenteDAO + "\",\"" + p.nomProduitDAO + "\",\"" + p.descriptionDAO + "\",\"" + p.artisteDAO + "\",\"" + p.styleDAO + "\",\"" + p.isVenduDAO + "\",\"" + p.idCategorieDAO + "\",\"" + p.idLotDAO + "\",\"" + p.idPhotoDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit(int id)
        {
            string query = "DELETE FROM produit WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdProduit()
        {
            int maxIdProduit = 0;
            string query = "SELECT MAX(id) FROM produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdProduit = reader.GetInt32(0);
                }
                else
                {
                    maxIdProduit = 0;
                }
            }
            reader.Close();
            return maxIdProduit;
        }
    }
}