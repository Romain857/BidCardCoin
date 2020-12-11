using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class LieuDAL
    {
        public LieuDAL()
        { }

        public static ObservableCollection<LieuDAO> selectLieu()
        {
            ObservableCollection<LieuDAO> l = new ObservableCollection<LieuDAO>();
            string query = "SELECT * FROM lieu;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LieuDAO p = new LieuDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
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

        public static LieuDAO getLieu(int id)
        {
            string query = "SELECT * FROM lieu WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LieuDAO cat = new LieuDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
            reader.Close();
            return cat;
        }
        public static void updateLieu(LieuDAO p)
        {
            string query = "UPDATE lieu set ville=\"" + p.villeDAO + "\", adresse=\"" + p.adresseDAO + "\",codePostal=\"" + p.codePostalDAO + "\",departement=\"" + p.departementDAO + "\" where id=" + p.idDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertLieu(LieuDAO p)
        {
            int id = getMaxIdLieu() + 1;
            string query = "INSERT INTO lieu VALUES (\"" + id + "\",\"" + p.villeDAO + "\",\"" + p.adresseDAO + "\",\"" + p.codePostalDAO + "\",\"" + p.departementDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLieu(int id)
        {
            string query = "DELETE FROM lieu WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdLieu()
        {
            int maxIdLieu = 0;
            string query = "SELECT MAX(id) FROM lieu";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdLieu = reader.GetInt32(0);
                }
                else
                {
                    maxIdLieu = 0;
                }
            }
            reader.Close();
            return maxIdLieu;
        }
    }
}
