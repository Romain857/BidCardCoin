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
    public class EnchereORM
    {
        public static EnchereViewModel getEnchere(int id)
        {
            EnchereDAO pDAO = EnchereDAO.getEnchere(id);
            EnchereViewModel p = new EnchereViewModel(pDAO.idDAO, pDAO.nomEnchereDAO, pDAO.heureEnchereDAO, pDAO.dateEnchereDAO, pDAO.idLieuDAO, pDAO.idAdminDAO);
            return p;
        }

        public static ObservableCollection<EnchereViewModel> listeEncheres()
        {
            ObservableCollection<EnchereDAO> lDAO = EnchereDAO.listeEncheres();
            ObservableCollection<EnchereViewModel> l = new ObservableCollection<EnchereViewModel>();
            foreach (EnchereDAO element in lDAO)
            {
                EnchereViewModel p = new EnchereViewModel(element.idDAO, element.nomEnchereDAO, element.heureEnchereDAO, element.dateEnchereDAO, element.idLieuDAO, element.idAdminDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateEnchere(EnchereViewModel p)
        {
            EnchereDAO.updateEnchere(new EnchereDAO(p.idProperty, p.nomEnchereProperty, p.heureEnchereProperty, p.dateEnchereProperty, p.idLieuProperty, p.idAdminProperty));
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAO.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereViewModel p)
        {
            EnchereDAO.insertEnchere(new EnchereDAO(p.idProperty, p.nomEnchereProperty, p.heureEnchereProperty, p.dateEnchereProperty, p.idLieuProperty, p.idAdminProperty));
        }
    }
}
