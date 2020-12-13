using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.Ctrl
{
    public class AdminViewModel
    {
        private int id;
        private string nomAdmin;
        private string prenomAdmin;
        private string mailAdmin;
        private int numerotelAdmin;
        private string mdpAdmin;
        private int age;
        private int idLieu;

        public AdminViewModel(){ }

        public AdminViewModel(int id, string nom, string prenom, string mail, int numeroTel, string mdp, int age, int idLieu)
        {
            this.id = id;
            this.nomAdminProperty = nom;
            this.prenomAdminProperty = prenom;
            this.mailAdmin = mail;
            this.numerotelAdmin = numeroTel;
            this.mdpAdmin = mdp;
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
        public String nomAdminProperty
        {
            get { return nomAdmin; }
            set
            {
                nomAdmin = value;
            }

        }
        public String prenomAdminProperty
        {
            get { return prenomAdmin; }
            set
            {
                this.prenomAdmin = value;
            }
        }
        public String mailAdminProperty
        {
            get { return mailAdmin; }
            set
            {
                this.mailAdmin = value;
            }
        }
        public int numerotelAdminProperty
        {
            get { return numerotelAdmin; }
            set
            {
                this.numerotelAdmin = value;
            }
        }
        public String mdpAdminProperty
        {
            get { return mdpAdmin; }
            set
            {
                this.mdpAdmin = value;
            }
        }
        public int ageAdminProperty
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
