using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class EstimationDAO
    {
        public string estimationDAO;
        public string dateEstimationDAO;
        public int idProduitDAO;
        public int idAdminDAO;

        public EstimationDAO(string estimationDAO, string dateEstimationDAO, int idProduitDAO, int idAdminDAO)
        {
            this.estimationDAO = estimationDAO;
            this.dateEstimationDAO = dateEstimationDAO;
            this.idProduitDAO = idProduitDAO;
            this.idAdminDAO = idAdminDAO;
        }

        public static ObservableCollection<EstimationDAO> listeEstimation()
        {
            ObservableCollection<EstimationDAO> l = EstimationDAL.selectEstimation();
            return l;
        }

        public static EstimationDAO getEstimation(int id)
        {
            EstimationDAO p = EstimationDAL.getEstimation(id);
            return p;
        }
        /*public static void updateEstimation(EstimationDAO p)
        {
            EstimationDAL.updateEstimation(p);
        }*/

        public static void supprimerEstimation(int id)
        {
            EstimationDAL.supprimerEstimation(id);
        }

        public static void insertEstimation(EstimationDAO p)
        {
            EstimationDAL.insertEstimation(p);
        }
    }
}
