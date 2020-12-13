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
    public class AdminORM
    {
        public static AdminViewModel getAdmin(int id)
        {
            AdminDAO pDAO = AdminDAO.getAdmin(id);
            AdminViewModel p = new AdminViewModel(pDAO.idDAO, pDAO.nomAdminDAO, pDAO.prenomAdminDAO, pDAO.mailAdminDAO, pDAO.numerotelAdminDAO, pDAO.mdpAdminDAO, pDAO.ageDAO, pDAO.idLieuDAO);
            return p;
        }

        public static ObservableCollection<AdminViewModel> listeAdmins()
        {
            ObservableCollection<AdminDAO> lDAO = AdminDAO.listeAdmins();
            ObservableCollection<AdminViewModel> l = new ObservableCollection<AdminViewModel>();
            foreach (AdminDAO element in lDAO)
            {
                AdminViewModel p = new AdminViewModel(element.idDAO, element.nomAdminDAO, element.prenomAdminDAO, element.mailAdminDAO, element.numerotelAdminDAO, element.mdpAdminDAO,element.ageDAO, element.idLieuDAO);
                l.Add(p);
            }
            return l;
        }
    }
}