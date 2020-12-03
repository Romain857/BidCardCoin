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
    public class PersonneORM
    {
        public static PersonneViewModel getPersonne(int id)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(id);
            PersonneViewModel p = new PersonneViewModel(pDAO.idDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO, pDAO.mailPersonneDAO, pDAO.numerotelPersonneDAO, pDAO.mdpPersonneDAO, pDAO.ageDAO, pDAO.idEnchereDAO, pDAO.idLieuDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.idDAO, element.nomPersonneDAO, element.prenomPersonneDAO, element.mailPersonneDAO, element.numerotelPersonneDAO, element.mdpPersonneDAO,element.ageDAO, element.idEnchereDAO, element.idLieuDAO);
                l.Add(p);
            }
            return l;
        }
    }
}