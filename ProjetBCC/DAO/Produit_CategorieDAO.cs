using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class Produit_CategorieDAO
    {
        public int idProduitDAO;
        public int idCategorieDAO;

        public Produit_CategorieDAO(int idProduitDAO, int idCategorieDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.idCategorieDAO = idCategorieDAO;
        }

        public static ObservableCollection<Produit_CategorieDAO> listeProduit_Categorie()
        {
            ObservableCollection<Produit_CategorieDAO> l = Produit_CategorieDAL.selectProduit_Categorie();
            return l;
        }

        public static Produit_CategorieDAO getProduit_Categorie(int id)
        {
            Produit_CategorieDAO p = Produit_CategorieDAL.getProduit_Categorie(id);
            return p;
        }
        /*public static void updateProduit_Categorie(Produit_CategorieDAO p)
        {
            Produit_CategorieDAL.updateProduit_Categorie(p);
        }*/

        public static void supprimerProduit_Categorie(int id)
        {
            Produit_CategorieDAL.supprimerProduit_Categorie(id);
        }

        public static void insertProduit_Categorie(Produit_CategorieDAO p)
        {
            Produit_CategorieDAL.insertProduit_Categorie(p);
        }
    }
}
