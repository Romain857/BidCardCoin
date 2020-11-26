using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.Ctrl
{
    public class PersonneViewModel
    {
        private int id;
        private string nomPersonne;
        private string prenomPersonne;
        private string mailPersonne;
        private int numerotelPersonne;
        private string mdpPersonne;
        private string adressePersonne;
        private int codePostalPersonne;
        private int age;

        public PersonneViewModel(){ }

        public PersonneViewModel(int id, string nom, string prenom, string mail, int numeroTel, string mdp, string adresse, int codepostal, int age)
        {
            this.id = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.mailPersonne = mail;
            this.numerotelPersonne = numeroTel;
            this.mdpPersonne = mdp;
            this.adressePersonne = adresse;
            this.codePostalPersonne = codepostal;
            this.age = age;

        }
        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value;
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
            }
        }
        public String mailPersonneProperty
        {
            get { return mailPersonne; }
            set
            {
                this.mailPersonne = value;
            }
        }
        public int numerotelPersonneProperty
        {
            get { return numerotelPersonne; }
            set
            {
                this.numerotelPersonne = value;
            }
        }
        public String mdpPersonneProperty
        {
            get { return mdpPersonne; }
            set
            {
                this.mdpPersonne = value;
            }
        }
        public String adressePersonneProperty
        {
            get { return adressePersonne; }
            set
            {
                this.adressePersonne = value;
            }
        }
        public int codePostalPersonneProperty
        {
            get { return codePostalPersonne; }
            set
            {
                this.codePostalPersonne = value;
            }
        }
        public int agePersonneProperty
        {
            get { return age; }
            set
            {
                this.age = value;
            }
        }
    }
}
