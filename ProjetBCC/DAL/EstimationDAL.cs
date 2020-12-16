using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class EstimationDAL
    {
        public EstimationDAL()
        { }

        public static ObservableCollection<EstimationDAO> selectEstimation()
        {
            ObservableCollection<EstimationDAO> l = new ObservableCollection<EstimationDAO>();
            string query = "SELECT * FROM estimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstimationDAO p = new EstimationDAO(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
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

        public static EstimationDAO getEstimation(int id)
        {
            string query = "SELECT * FROM estimation WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EstimationDAO cat = new EstimationDAO(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
            reader.Close();
            return cat;
        }
        /*public static void updateEstimation(EstimationDAO p)
        {
            string query = "UPDATE Estimation set idProduit=\"" + p.idProduitDAO + "\", idCategorie=\"" + p.idCategorieDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }*/
        public static void insertEstimation(EstimationDAO p)
        {
            string query = "INSERT INTO estimation VALUES (\"" + p.estimationDAO + "\",\"" + p.dateEstimationDAO + "\",\"" + p.idProduitDAO + "\",\"" + p.idAdminDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEstimation(int idProduitProperty, int idAdminProperty)
        {
            string query = "DELETE FROM estimation WHERE idProduit = \"" + idProduitProperty + "\"AND idAdmin = \"" + idAdminProperty + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
