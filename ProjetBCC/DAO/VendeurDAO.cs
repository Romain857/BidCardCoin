using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class VendeurDAO
    {
        public int idDAO;
        public int idPersonneDAO;

        public VendeurDAO(int idDAO, int idPersonneDAO)
        {
            this.idDAO = idDAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        public static ObservableCollection<VendeurDAO> listeVendeur()
        {
            ObservableCollection<VendeurDAO> l = VendeurDAL.selectVendeur();
            return l;
        }

        public static VendeurDAO getVendeur(int id)
        {
            VendeurDAO p = VendeurDAL.getVendeur(id);
            return p;
        }
        public static void updateVendeur(VendeurDAO p)
        {
            VendeurDAL.updateVendeur(p);
        }

        public static void supprimerVendeur(int id)
        {
            VendeurDAL.supprimerVendeur(id);
        }

        public static void insertVendeur(VendeurDAO p)
        {
            VendeurDAL.insertVendeur(p);
        }
    }
}
