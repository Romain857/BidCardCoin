using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class LotDAO
    {
        public int idDAO;
        public string nomDAO;
        public string descriptionDAO;
        public DateTime dateVenteDAO;
        public int idEnchereDAO;

        public LotDAO(int idDAO, string nomDAO, string descriptionDAO, DateTime dateVenteDAO, int idEnchereDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
            this.dateVenteDAO = dateVenteDAO;
            this.idEnchereDAO = idEnchereDAO;
        }
        public static ObservableCollection<LotDAO> listeLot()
        {
            ObservableCollection<LotDAO> l = LotDAL.selectLot();
            return l;
        }

        public static LotDAO getLot(int id)
        {
            LotDAO p = LotDAL.getLot(id);
            return p;
        }
        public static void updateLot(LotDAO p)
        {
            LotDAL.updateLot(p);
        }

        public static void supprimerLot(int id)
        {
            LotDAL.supprimerLot(id);
        }

        public static void insertLot(LotDAO p)
        {
            LotDAL.insertLot(p);
        }
    }
}
