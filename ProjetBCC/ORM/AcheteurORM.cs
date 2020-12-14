using ProjetBCC.Ctrl;
using ProjetBCC.DAO;
using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.ORM
{
    public class AcheteurORM
    {
        public static AcheteurViewModel getAcheteur(int id)
        {
            AcheteurDAO pDAO = AcheteurDAO.getAcheteur(id);
            AcheteurViewModel p = new AcheteurViewModel(pDAO.idDAO, pDAO.soldeDAO, pDAO.isSolvableDAO, pDAO.identiteDAO, pDAO.moyenPaiementDAO, pDAO.idPersonneDAO);
            return p;
        }

        public static ObservableCollection<AcheteurViewModel> listeAcheteur()
        {
            ObservableCollection<AcheteurDAO> lDAO = AcheteurDAO.listeAcheteur();
            ObservableCollection<AcheteurViewModel> l = new ObservableCollection<AcheteurViewModel>();
            foreach (AcheteurDAO element in lDAO)
            {
                AcheteurViewModel p = new AcheteurViewModel(element.idDAO, element.soldeDAO, element.isSolvableDAO, element.identiteDAO, element.moyenPaiementDAO, element.idPersonneDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateAcheteur(AcheteurViewModel p)
        {
            AcheteurDAO.updateAcheteur(new AcheteurDAO(p.idProperty, p.soldeProperty, p.isSolvableProperty, p.identiteProperty, p.moyenPaiementProperty, p.idPersonneProperty));
        }

        public static void supprimerAcheteur(int id)
        {
            AcheteurDAO.supprimerAcheteur(id);
        }

        public static void insertAcheteur(AcheteurViewModel p)
        {
            AcheteurDAO.insertAcheteur(new AcheteurDAO(p.idProperty, p.soldeProperty, p.isSolvableProperty, p.identiteProperty, p.moyenPaiementProperty, p.idPersonneProperty));
        }
    }
}
