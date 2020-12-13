using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class PersonneDAO
    {
        public int idDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public string mailPersonneDAO;
        public int numerotelPersonneDAO;
        public string mdpPersonneDAO;
        public string adressePersonneDAO;
        public int codePostalPersonneDAO;
        public int ageDAO;
        public PersonneDAO(int idDAO, string nomPersonneDAO, string prenomPersonneDAO, string mailPersonneDAO, int numerotelPersonneDAO, string mdpPersonneDAO, string adressePersonneDAO, int codePostalPersonneDAO, int ageDAO)
        {
            this.idDAO = idDAO;
            this.nomPersonneDAO = nomPersonneDAO;
            this.prenomPersonneDAO = prenomPersonneDAO;
            this.mailPersonneDAO = mailPersonneDAO;
            this.numerotelPersonneDAO = numerotelPersonneDAO;
            this.mdpPersonneDAO = mdpPersonneDAO;
            this.adressePersonneDAO = adressePersonneDAO;
            this.codePostalPersonneDAO = codePostalPersonneDAO;
            this.ageDAO = ageDAO;
        }

        public static ObservableCollection<PersonneDAO> listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }

        public static PersonneDAO getPersonne(int id)
        {
            PersonneDAO p = PersonneDAL.getPersonne(id);
            return p;
        }
        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}