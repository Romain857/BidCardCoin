using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetBCC.DAO;

namespace ProjetBCC.DAL
{
    public class PersonneDAL
    {
        public PersonneDAL()
        { }

        public static ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8));
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

        public static PersonneDAO getPersonne(int id)
        {
            string query = "SELECT * FROM personne WHERE id=" + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8));
            reader.Close();
            return pers;
        }
        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set nom=\"" + p.nomPersonneDAO + "\", prenom=\"" + p.prenomPersonneDAO + "\", mail=\"" + p.mailPersonneDAO + "\", numeroTel=\"" + p.numerotelPersonneDAO + "\", motDePasse=\"" + p.mdpPersonneDAO + "\", adresse=\"" + p.adressePersonneDAO + "\",codePostal=\"" + p.codePostalPersonneDAO + "\", age=\"" + p.ageDAO + "\" where id=" + p.idDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.nomPersonneDAO + "\",\"" + p.prenomPersonneDAO + "\",\"" + p.mailPersonneDAO + "\",\"" + p.numerotelPersonneDAO + "\",\"" + p.mdpPersonneDAO + "\",\"" + p.adressePersonneDAO + "\",\"" + p.codePostalPersonneDAO + "\",\"" + p.ageDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
        {
            int maxIdPersonne = 0;
            string query = "SELECT MAX(id) FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdPersonne = reader.GetInt32(0);
                }
                else
                {
                    maxIdPersonne = 0;
                }
            }
            reader.Close();
            return maxIdPersonne;
        }
    }
}