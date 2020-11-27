using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBCC.DAL;

namespace ProjetBCC.DAO
{
    public class ProduitDAO
    {
        public int idDAO;
        public float estimationDAO;
        public float prixVenteDAO;
        public string nomProduitDAO;
        public string artisteDAO;
        public string styleDAO;
        public bool isVenduDAO;
        public int idCategorieDAO;
        public int idLotDAO;
        public int idPhotoDAO;

        public ProduitDAO(int idDAO, float estimationDAO, float prixVenteDAO, string nomDAO, string artisteDAO, string styleDAO, bool isVenduDAO, int idCategorieDAO, int idLotDAO, int idPhotoDAO)
        {
            this.idDAO = idDAO;
            this.estimationDAO = estimationDAO;
            this.prixVenteDAO = prixVenteDAO;
            this.nomProduitDAO = nomDAO;
            this.artisteDAO = artisteDAO;
            this.styleDAO = styleDAO;
            this.isVenduDAO = isVenduDAO;
            this.idCategorieDAO = idCategorieDAO;
            this.idLotDAO = idLotDAO;
            this.idPhotoDAO = idPhotoDAO;
        }
        public static ObservableCollection<ProduitDAO> listeProduits()
        {
            ObservableCollection<ProduitDAO> l = ProduitDAL.selectProduits();
            return l;
        }

        public static ProduitDAO getProduit(int id)
        {
            ProduitDAO p = ProduitDAL.getProduit(id);
            return p;
        }
        public static void updateProduit(ProduitDAO p)
        {
            ProduitDAL.updateProduit(p);
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAL.supprimerProduit(id);
        }

        public static void insertProduit(ProduitDAO p)
        {
            ProduitDAL.insertProduit(p);
        }
    }
}
