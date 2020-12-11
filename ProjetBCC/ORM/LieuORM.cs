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
    public class LieuORM
    {
        public static LieuViewModel getLieu(int id)
        {
            LieuDAO pDAO = LieuDAO.getLieu(id);
            LieuViewModel p = new LieuViewModel(pDAO.idDAO, pDAO.villeDAO, pDAO.adresseDAO, pDAO.codePostalDAO, pDAO.departementDAO);
            return p;
        }

        public static ObservableCollection<LieuViewModel> listeLieu()
        {
            ObservableCollection<LieuDAO> lDAO = LieuDAO.listeLieu();
            ObservableCollection<LieuViewModel> l = new ObservableCollection<LieuViewModel>();
            foreach (LieuDAO element in lDAO)
            {
                LieuViewModel p = new LieuViewModel(element.idDAO, element.villeDAO, element.adresseDAO, element.codePostalDAO, element.departementDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateLieu(LieuViewModel p)
        {
            LieuDAO.updateLieu(new LieuDAO(p.idProperty, p.villeProperty, p.adresseProperty, p.codePostalProperty, p.departementProperty));
        }

        public static void supprimerLieu(int id)
        {
            LieuDAO.supprimerLieu(id);
        }

        public static void insertLieu(LieuViewModel p)
        {
            LieuDAO.insertLieu(new LieuDAO(p.idProperty, p.villeProperty, p.adresseProperty, p.codePostalProperty, p.departementProperty));
        }
    }
}
