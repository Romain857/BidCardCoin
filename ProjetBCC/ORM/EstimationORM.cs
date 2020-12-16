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
    public class EstimationORM
    {
        public static EstimationViewModel getEstimation(int id)
        {
            EstimationDAO pDAO = EstimationDAO.getEstimation(id);
            EstimationViewModel p = new EstimationViewModel(pDAO.estimationDAO, pDAO.dateEstimationDAO, pDAO.idProduitDAO, pDAO.idAdminDAO);
            return p;
        }

        public static ObservableCollection<EstimationViewModel> listeEstimation()
        {
            ObservableCollection<EstimationDAO> lDAO = EstimationDAO.listeEstimation();
            ObservableCollection<EstimationViewModel> l = new ObservableCollection<EstimationViewModel>();
            foreach (EstimationDAO element in lDAO)
            {
                EstimationViewModel p = new EstimationViewModel(element.estimationDAO, element.dateEstimationDAO, element.idProduitDAO, element.idAdminDAO);
                l.Add(p);
            }
            return l;
        }
        /*public static void updateEstimation(EstimationViewModel p)
        {
            EstimationDAO.updateEstimation(new EstimationDAO(p.idProduitProperty, p.idCategorieProperty));
        }*/

        public static void supprimerEstimation(int idPropduitProperty, int idAdminProperty)
        {
            EstimationDAO.supprimerEstimation(idPropduitProperty, idAdminProperty);
        }

        public static void insertEstimation(EstimationViewModel p)
        {
            EstimationDAO.insertEstimation(new EstimationDAO(p.estimationProperty, p.dateEstimationProperty, p.idProduitProperty, p.idAdminProperty));
        }
    }
}
