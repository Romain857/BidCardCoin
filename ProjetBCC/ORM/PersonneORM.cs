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
            PersonneViewModel p = new PersonneViewModel(pDAO.idDAO, pDAO.nomPersonneDAO, pDAO.prenomPersonneDAO, pDAO.mailPersonneDAO, pDAO.numerotelPersonneDAO, pDAO.mdpPersonneDAO, pDAO.adressePersonneDAO, pDAO.codePostalPersonneDAO, pDAO.ageDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.idDAO, element.nomPersonneDAO, element.prenomPersonneDAO, element.mailPersonneDAO, element.numerotelPersonneDAO, element.mdpPersonneDAO, element.adressePersonneDAO, element.codePostalPersonneDAO, element.ageDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idProperty, p.nomPersonneProperty, p.prenomPersonneProperty, p.mailPersonneProperty, p.numerotelPersonneProperty, p.mdpPersonneProperty, p.adressePersonneProperty, p.codePostalProperty, p.agePersonneProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idProperty, p.nomPersonneProperty, p.prenomPersonneProperty, p.mailPersonneProperty, p.numerotelPersonneProperty, p.mdpPersonneProperty, p.adressePersonneProperty, p.codePostalProperty, p.agePersonneProperty));
        }
    }
}
