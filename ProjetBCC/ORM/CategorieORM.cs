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
    public class CategorieORM
    {
        public static CategorieViewModel getCategorie(int id)
        {
            CategorieDAO pDAO = CategorieDAO.getCategorie(id);
            CategorieViewModel p = new CategorieViewModel(pDAO.idDAO, pDAO.nomCategorieDAO);
            return p;
        }

        public static ObservableCollection<CategorieViewModel> listeCategorie()
        {
            ObservableCollection<CategorieDAO> lDAO = CategorieDAO.listeCategorie();
            ObservableCollection<CategorieViewModel> l = new ObservableCollection<CategorieViewModel>();
            foreach (CategorieDAO element in lDAO)
            {
                CategorieViewModel p = new CategorieViewModel(element.idDAO, element.nomCategorieDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateCategorie(CategorieViewModel p)
        {
            CategorieDAO.updateCategorie(new CategorieDAO(p.idProperty, p.nomCategorieProperty));
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAO.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieViewModel p)
        {
            CategorieDAO.insertCategorie(new CategorieDAO(p.idProperty, p.nomCategorieProperty));
        }
    }
}
