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
        private int age;
        private int idLieu;

        public PersonneViewModel(){ }

        public PersonneViewModel(int id, string nom, string prenom, string mail, int numeroTel, string mdp, int age, int idLieu)
        {
            this.id = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.mailPersonne = mail;
            this.numerotelPersonne = numeroTel;
            this.mdpPersonne = mdp;
            this.age = age;
            this.idLieu = idLieu;

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
        public int agePersonneProperty
        {
            get { return age; }
            set
            {
                this.age = value;
            }
        }
        public int idLieuProperty
        {
            get { return idLieu; }
            set
            {
                this.idLieu = value;
            }
        }
    }
}
