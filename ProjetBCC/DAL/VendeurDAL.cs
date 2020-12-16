using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class VendeurDAL
    {
        public VendeurDAL()
        { }

        public static ObservableCollection<VendeurDAO> selectVendeur()
        {
            ObservableCollection<VendeurDAO> l = new ObservableCollection<VendeurDAO>();
            string query = "SELECT * FROM vendeur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VendeurDAO p = new VendeurDAO(reader.GetInt32(0), reader.GetInt32(1));
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

        public static VendeurDAO getVendeur(int id)
        {
            string query = "SELECT * FROM vendeur WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            VendeurDAO cat = new VendeurDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return cat;
        }
        public static void updateVendeur(VendeurDAO p)
        {
            string query = "UPDATE vendeur set idPersonne=\"" + p.idPersonneDAO  + "\" where id=" + p.idDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertVendeur(VendeurDAO p)
        {
            int id = getMaxIdVendeur() + 1;
            string query = "INSERT INTO vendeur VALUES (\"" + id + "\",\"" + p.idPersonneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerVendeur(int id)
        {
            string query = "DELETE FROM vendeur WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdVendeur()
        {
            int maxIdVendeur = 0;
            string query = "SELECT MAX(id) FROM vendeur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdVendeur = reader.GetInt32(0);
                }
                else
                {
                    maxIdVendeur = 0;
                }
            }
            reader.Close();
            return maxIdVendeur;
        }
    }
}