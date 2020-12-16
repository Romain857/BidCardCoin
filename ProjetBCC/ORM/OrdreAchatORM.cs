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
    public class OrdreAchatORM
    {
        public static OrdreAchatViewModel getOrdreAchat(int id)
        {
            OrdreAchatDAO pDAO = OrdreAchatDAO.getOrdreAchat(id);
            OrdreAchatViewModel p = new OrdreAchatViewModel(pDAO.idProduitDAO, pDAO.idAcheteurDAO, pDAO.idEnchereDAO, pDAO.montantMaxDAO, pDAO.adresseDepotDAO);
            return p;
        }

        public static ObservableCollection<OrdreAchatViewModel> listeOrdreAchat()
        {
            ObservableCollection<OrdreAchatDAO> lDAO = OrdreAchatDAO.listeOrdreAchat();
            ObservableCollection<OrdreAchatViewModel> l = new ObservableCollection<OrdreAchatViewModel>();
            foreach (OrdreAchatDAO element in lDAO)
            {
                OrdreAchatViewModel p = new OrdreAchatViewModel(element.idProduitDAO, element.idAcheteurDAO, element.idEnchereDAO, element.montantMaxDAO, element.adresseDepotDAO);
                l.Add(p);
            }
            return l;
        }
        /*public static void updateOrdreAchat(OrdreAchatViewModel p)
        {
            OrdreAchatDAO.updateOrdreAchat(new OrdreAchatDAO(p.idProduitProperty, p.idCategorieProperty));
        }*/

        public static void supprimerOrdreAchat(int idProduitProperty, int idAcheteurProperty, int idEnchereProperty)
        {
            OrdreAchatDAO.supprimerOrdreAchat(idProduitProperty, idAcheteurProperty, idEnchereProperty);
        }

        public static void insertOrdreAchat(OrdreAchatViewModel p)
        {
            OrdreAchatDAO.insertOrdreAchat(new OrdreAchatDAO(p.idProduitProperty, p.idAcheteurProperty, p.idEnchereProperty, p.montantMaxProperty, p.adresseDepotProperty));
        }
    }
}
