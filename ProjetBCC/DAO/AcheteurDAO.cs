using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class AcheteurDAO
    {
        public int idDAO;
        public float soldeDAO;
        public bool isSolvableDAO;
        public string identiteDAO;
        public string moyenPaiementDAO;
        public int idPersonneDAO;

        public AcheteurDAO(int idDAO, float soldeDAO, bool isSolvableDAO, string identiteDAO, string moyenPaiementDAO, int idPersonneDAO)
        {
            this.idDAO = idDAO;
            this.soldeDAO = soldeDAO;
            this.isSolvableDAO = isSolvableDAO;
            this.identiteDAO = identiteDAO;
            this.moyenPaiementDAO = moyenPaiementDAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        public static ObservableCollection<AcheteurDAO> listeAcheteur()
        {
            ObservableCollection<AcheteurDAO> l = AcheteurDAL.selectAcheteur();
            return l;
        }

        public static AcheteurDAO getAcheteur(int id)
        {
            AcheteurDAO p = AcheteurDAL.getAcheteur(id);
            return p;
        }
        public static void updateAcheteur(AcheteurDAO p)
        {
            AcheteurDAL.updateAcheteur(p);
        }

        public static void supprimerAcheteur(int id)
        {
            AcheteurDAL.supprimerAcheteur(id);
        }

        public static void insertAcheteur(AcheteurDAO p)
        {
            AcheteurDAL.insertAcheteur(p);
        }
    }
}
