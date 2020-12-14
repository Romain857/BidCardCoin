using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class OrdreAchatDAL
    {
        public OrdreAchatDAL()
        { }

        public static ObservableCollection<OrdreAchatDAO> selectOrdreAchat()
        {
            ObservableCollection<OrdreAchatDAO> l = new ObservableCollection<OrdreAchatDAO>();
            string query = "SELECT * FROM ordreachat;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrdreAchatDAO p = new OrdreAchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetString(4));
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

        public static OrdreAchatDAO getOrdreAchat(int id)
        {
            string query = "SELECT * FROM ordreachat WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            OrdreAchatDAO cat = new OrdreAchatDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetString(4));
            reader.Close();
            return cat;
        }
        /*public static void updateOrdreAchat(OrdreAchatDAO p)
        {
            string query = "UPDATE OrdreAchat set idProduit=\"" + p.idProduitDAO + "\", idCategorie=\"" + p.idCategorieDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }*/
        public static void insertOrdreAchat(OrdreAchatDAO p)
        {
            string query = "INSERT INTO ordreachat VALUES (\"" + p.idProduitDAO + "\",\"" + p.idAcheteurDAO + "\",\"" + p.idEnchereDAO + "\",\"" + p.montantMaxDAO + "\",\"" + p.adresseDepotDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerOrdreAchat(int id)
        {
            string query = "DELETE FROM ordreachat WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
