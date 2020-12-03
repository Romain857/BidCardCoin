using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class CategorieDAO
    {
        public int idDAO;
        public string nomCategorieDAO;
        
        public CategorieDAO(int idDAO, string nomCategorieDAO)
        {
            this.idDAO = idDAO;
            this.nomCategorieDAO = nomCategorieDAO;
        }

        public static ObservableCollection<CategorieDAO> listeCategorie()
        {
            ObservableCollection<CategorieDAO> l = CategorieDAL.selectCategorie();
            return l;
        }

        public static CategorieDAO getCategorie(int id)
        {
            CategorieDAO p = CategorieDAL.getCategorie(id);
            return p;
        }
        public static void updateCategorie(CategorieDAO p)
        {
            CategorieDAL.updateCategorie(p);
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAL.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieDAO p)
        {
            CategorieDAL.insertCategorie(p);
        }
    }
}
