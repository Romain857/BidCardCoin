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
    public class VendeurORM
    {
        public static VendeurViewModel getVendeur(int id)
        {
            VendeurDAO pDAO = VendeurDAO.getVendeur(id);
            VendeurViewModel p = new VendeurViewModel(pDAO.idDAO, pDAO.idPersonneDAO);
            return p;
        }

        public static ObservableCollection<VendeurViewModel> listeVendeur()
        {
            ObservableCollection<VendeurDAO> lDAO = VendeurDAO.listeVendeur();
            ObservableCollection<VendeurViewModel> l = new ObservableCollection<VendeurViewModel>();
            foreach (VendeurDAO element in lDAO)
            {
                VendeurViewModel p = new VendeurViewModel(element.idDAO, element.idPersonneDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateVendeur(VendeurViewModel p)
        {
            VendeurDAO.updateVendeur(new VendeurDAO(p.idProperty, p.idPersonneProperty));
        }

        public static void supprimerVendeur(int id)
        {
            VendeurDAO.supprimerVendeur(id);
        }

        public static void insertVendeur(VendeurViewModel p)
        {
            VendeurDAO.insertVendeur(new VendeurDAO(p.idProperty, p.idPersonneProperty));
        }
    }
}
