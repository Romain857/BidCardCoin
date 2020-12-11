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
    public class LotORM
    {
        public static LotViewModel getLot(int id)
        {
            LotDAO pDAO = LotDAO.getLot(id);
            LotViewModel p = new LotViewModel(pDAO.idDAO, pDAO.nomDAO, pDAO.descriptionDAO, pDAO.dateVenteDAO, pDAO.idEnchereDAO);
            return p;
        }

        public static ObservableCollection<LotViewModel> listeLot()
        {
            ObservableCollection<LotDAO> lDAO = LotDAO.listeLot();
            ObservableCollection<LotViewModel> l = new ObservableCollection<LotViewModel>();
            foreach (LotDAO element in lDAO)
            {
                LotViewModel p = new LotViewModel(element.idDAO, element.nomDAO, element.descriptionDAO, element.dateVenteDAO, element.idEnchereDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateLot(LotViewModel p)
        {
            LotDAO.updateLot(new LotDAO(p.idProperty, p.nomProperty, p.descriptionProperty, p.dateVenteProperty, p.idEnchereProperty));
        }

        public static void supprimerLot(int id)
        {
            LotDAO.supprimerLot(id);
        }

        public static void insertLot(LotViewModel p)
        {
            LotDAO.insertLot(new LotDAO(p.idProperty, p.nomProperty, p.descriptionProperty, p.dateVenteProperty, p.idEnchereProperty));
        }
    }
}
