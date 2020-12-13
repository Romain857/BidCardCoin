using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class AdminDAO
    {
        public int idDAO;
        public string nomAdminDAO;
        public string prenomAdminDAO;
        public string mailAdminDAO;
        public int numerotelAdminDAO;
        public string mdpAdminDAO;
        public int ageDAO;
        public int idLieuDAO;
        public AdminDAO(int idDAO, string nomAdminDAO, string prenomAdminDAO, string mailAdminDAO, int numerotelAdminDAO, string mdpAdminDAO, int ageDAO, int idLieuDAO)
        {
            this.idDAO = idDAO;
            this.nomAdminDAO = nomAdminDAO;
            this.prenomAdminDAO = prenomAdminDAO;
            this.mailAdminDAO = mailAdminDAO;
            this.numerotelAdminDAO = numerotelAdminDAO;
            this.mdpAdminDAO = mdpAdminDAO;
            this.ageDAO = ageDAO;
            this.idLieuDAO = idLieuDAO;
        }

        public static ObservableCollection<AdminDAO> listeAdmins()
        {
            ObservableCollection<AdminDAO> l = AdminDAL.selectAdmins();
            return l;
        }

        public static AdminDAO getAdmin(int id)
        {
            AdminDAO p = AdminDAL.getAdmin(id);
            return p;
        }
    }
}
