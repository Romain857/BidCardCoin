using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class OrdreAchatDAO
    {
        public int idProduitDAO;
        public int idAcheteurDAO;
        public int idEnchereDAO;
        public float montantMaxDAO;
        public string adresseDepotDAO;

        public OrdreAchatDAO(int idProduitDAO, int idAcheteurDAO, int idEnchereDAO, float montantMaxDAO, string adresseDepotDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.idAcheteurDAO = idAcheteurDAO;
            this.idEnchereDAO = idEnchereDAO;
            this.montantMaxDAO = montantMaxDAO;
            this.adresseDepotDAO = adresseDepotDAO;
        }

        public static ObservableCollection<OrdreAchatDAO> listeOrdreAchat()
        {
            ObservableCollection<OrdreAchatDAO> l = OrdreAchatDAL.selectOrdreAchat();
            return l;
        }

        public static OrdreAchatDAO getOrdreAchat(int id)
        {
            OrdreAchatDAO p = OrdreAchatDAL.getOrdreAchat(id);
            return p;
        }
        /*public static void updateOrdreAchat(OrdreAchatDAO p)
        {
            OrdreAchatDAL.updateOrdreAchat(p);
        }*/

        public static void supprimerOrdreAchat(int idProduitProperty, int idAcheteurProperty, int idEnchereProperty)
        {
            OrdreAchatDAL.supprimerOrdreAchat(idProduitProperty, idAcheteurProperty, idEnchereProperty);
        }

        public static void insertOrdreAchat(OrdreAchatDAO p)
        {
            OrdreAchatDAL.insertOrdreAchat(p);
        }
    }
}
