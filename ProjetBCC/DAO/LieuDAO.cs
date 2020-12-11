using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class LieuDAO
    {
        public int idDAO;
        public string villeDAO;
        public string adresseDAO;
        public int codePostalDAO;
        public string departementDAO;

        public LieuDAO(int idDAO, string villeDAO, string adresseDAO, int codePostalDAO, string departementDAO)
        {
            this.idDAO = idDAO;
            this.villeDAO = villeDAO;
            this.adresseDAO = adresseDAO;
            this.codePostalDAO = codePostalDAO;
            this.departementDAO = departementDAO;
        }
        public static ObservableCollection<LieuDAO> listeLieu()
        {
            ObservableCollection<LieuDAO> l = LieuDAL.selectLieu();
            return l;
        }

        public static LieuDAO getLieu(int id)
        {
            LieuDAO p = LieuDAL.getLieu(id);
            return p;
        }
        public static void updateLieu(LieuDAO p)
        {
            LieuDAL.updateLieu(p);
        }

        public static void supprimerLieu(int id)
        {
            LieuDAL.supprimerLieu(id);
        }

        public static void insertLieu(LieuDAO p)
        {
            LieuDAL.insertLieu(p);
        }
    }
}
