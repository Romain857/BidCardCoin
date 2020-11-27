using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetBCC.Ctrl;
using ProjetBCC.DAO;

namespace ProjetBCC.ORM
{
    public class ProduitORM
    {
        public static ProduitViewModel getProduit(int id)
        {
            ProduitDAO pDAO = ProduitDAO.getProduit(id);
            ProduitViewModel p = new ProduitViewModel(pDAO.idDAO, pDAO.estimationDAO, pDAO.prixVenteDAO, pDAO.nomProduitDAO, pDAO.artisteDAO, pDAO.styleDAO, pDAO.isVenduDAO, pDAO.idCategorieDAO, pDAO.idLotDAO, pDAO.idPhotoDAO);
            return p;
        }

        public static ObservableCollection<ProduitViewModel> listeProduits()
        {
            ObservableCollection<ProduitDAO> lDAO = ProduitDAO.listeProduits();
            ObservableCollection<ProduitViewModel> l = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in lDAO)
            {
                ProduitViewModel p = new ProduitViewModel(element.idDAO, element.estimationDAO, element.prixVenteDAO, element.nomProduitDAO, element.artisteDAO, element.styleDAO, element.isVenduDAO, element.idCategorieDAO, element.idLotDAO, element.idPhotoDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateProduit(ProduitViewModel p)
        {
            ProduitDAO.updateProduit(new ProduitDAO(p.idProperty, p.estimationProperty, p.prixVenteProperty, p.nomProduitProperty, p.artisteProperty, p.styleProperty, p.isVenduProperty, p.idCategorieProperty, p.idLotProperty, p.idPhotoProperty));
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAO.supprimerProduit(id);
        }

        public static void insertProduit(ProduitViewModel p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProperty, p.estimationProperty, p.prixVenteProperty, p.nomProduitProperty, p.artisteProperty, p.styleProperty, p.isVenduProperty, p.idCategorieProperty, p.idLotProperty, p.idPhotoProperty));
        }
    }
}
