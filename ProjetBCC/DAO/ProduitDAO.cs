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
        public float estimationActuelleDAO;
        public float prixVenteDAO;
        public string nomProduitDAO;
        public string descriptionDAO;
        public string artisteDAO;
        public string styleDAO;
        public bool isVenduDAO;
        public int idLotDAO;
        public int idPhotoDAO;

        public ProduitDAO(int idDAO, float estimationActuelleDAO, float prixVenteDAO, string nomProduitDAO, string descriptionDAO, string artisteDAO, string styleDAO, bool isVenduDAO, int idLotDAO, int idPhotoDAO)
        {
            this.idDAO = idDAO;
            this.estimationActuelleDAO = estimationActuelleDAO;
            this.prixVenteDAO = prixVenteDAO;
            this.nomProduitDAO = nomProduitDAO;
            this.descriptionDAO = descriptionDAO;
            this.artisteDAO = artisteDAO;
            this.styleDAO = styleDAO;
            this.isVenduDAO = isVenduDAO;
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
