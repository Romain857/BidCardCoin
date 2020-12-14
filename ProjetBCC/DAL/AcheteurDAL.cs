using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class AcheteurDAL
    {
        public AcheteurDAL()
        { }

        public static ObservableCollection<AcheteurDAO> selectAcheteur()
        {
            ObservableCollection<AcheteurDAO> l = new ObservableCollection<AcheteurDAO>();
            string query = "SELECT * FROM acheteur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AcheteurDAO p = new AcheteurDAO(reader.GetInt32(0), reader.GetFloat(1), reader.GetBoolean(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
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

        public static AcheteurDAO getAcheteur(int id)
        {
            string query = "SELECT * FROM acheteur WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AcheteurDAO cat = new AcheteurDAO(reader.GetInt32(0), reader.GetFloat(1), reader.GetBoolean(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
            reader.Close();
            return cat;
        }
        public static void updateAcheteur(AcheteurDAO p)
        {
            string query = "UPDATE acheteur set solde=\"" + p.soldeDAO + "\", isSolvable=\"" + p.isSolvableDAO + "\", identite=\"" + p.identiteDAO + "\", moyenPaiement=\"" + p.moyenPaiementDAO + "\", idPersonne=\"" + p.idPersonneDAO + "\" where id=" + p.idDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertAcheteur(AcheteurDAO p)
        {
            int id = getMaxIdAcheteur() + 1;
            string query = "INSERT INTO acheteur VALUES (\"" + id + "\",\"" + p.soldeDAO + "\",\"" + p.isSolvableDAO + "\",\"" + p.identiteDAO + "\",\"" + p.moyenPaiementDAO + "\",\"" + p.idPersonneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerAcheteur(int id)
        {
            string query = "DELETE FROM acheteur WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdAcheteur()
        {
            int maxIdAcheteur = 0;
            string query = "SELECT MAX(id) FROM acheteur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdAcheteur = reader.GetInt32(0);
                }
                else
                {
                    maxIdAcheteur = 0;
                }
            }
            reader.Close();
            return maxIdAcheteur;
        }
    }
}
