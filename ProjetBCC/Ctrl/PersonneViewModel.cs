using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class PersonneViewModel : INotifyPropertyChanged
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
        private string concat = "Ajouter ";
        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom, string mail, int numeroTel, string mdp, string adresse, int codePostal, int age)
        {
            this.id = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.mailPersonne = mail;
            this.numerotelPersonne = numeroTel;
            this.mdpPersonne = mdp;
            this.adressePersonne = adresse;
            this.codePostalPersonne = codePostal;
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
        public string nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }

        }
        public string prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public string mailPersonneProperty
        {
            get { return mailPersonne; }
            set
            {
                this.mailPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public int numerotelPersonneProperty
        {
            get { return numerotelPersonne; }
            set
            {
                this.numerotelPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public string mdpPersonneProperty
        {
            get { return mdpPersonne; }
            set
            {
                this.mdpPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public string adressePersonneProperty
        {
            get { return adressePersonne; }
            set
            {
                this.adressePersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public int codePostalProperty
        {
            get { return codePostalPersonne; }
            set
            {
                this.codePostalPersonne = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public int agePersonneProperty
        {
            get { return age; }
            set
            {
                this.age = value;
                OnPropertyChanged("nomCategorieProperty");
            }
        }
        public string ConcatProperty
        {
            get { return concat; }
            set
            {
                this.concat = value;
                OnPropertyChanged("ConcatProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                PersonneORM.updatePersonne(this);
            }
        }
    }
}