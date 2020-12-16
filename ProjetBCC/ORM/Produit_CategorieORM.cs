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
    public class Produit_CategorieORM
    {
        public static Produit_CategorieViewModel getProduit_Categorie(int id)
        {
            Produit_CategorieDAO pDAO = Produit_CategorieDAO.getProduit_Categorie(id);
            Produit_CategorieViewModel p = new Produit_CategorieViewModel(pDAO.idProduitDAO, pDAO.idCategorieDAO);
            return p;
        }

        public static ObservableCollection<Produit_CategorieViewModel> listeProduit_Categorie()
        {
            ObservableCollection<Produit_CategorieDAO> lDAO = Produit_CategorieDAO.listeProduit_Categorie();
            ObservableCollection<Produit_CategorieViewModel> l = new ObservableCollection<Produit_CategorieViewModel>();
            foreach (Produit_CategorieDAO element in lDAO)
            {
                Produit_CategorieViewModel p = new Produit_CategorieViewModel(element.idProduitDAO, element.idCategorieDAO);
                l.Add(p);
            }
            return l;
        }
        /*public static void updateProduit_Categorie(Produit_CategorieViewModel p)
        {
            Produit_CategorieDAO.updateProduit_Categorie(new Produit_CategorieDAO(p.idProduitProperty, p.idCategorieProperty));
        }*/

        public static void supprimerProduit_Categorie(int idProduitProperty, int idCategorieProperty)
        {
            Produit_CategorieDAO.supprimerProduit_Categorie(idProduitProperty, idCategorieProperty);
        }

        public static void insertProduit_Categorie(Produit_CategorieViewModel p)
        {
            Produit_CategorieDAO.insertProduit_Categorie(new Produit_CategorieDAO(p.idProduitProperty, p.idCategorieProperty));
        }
    }
}
