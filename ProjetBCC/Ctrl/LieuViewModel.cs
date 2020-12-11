using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class LieuViewModel : INotifyPropertyChanged
    {
        private int id;
        private string ville;
        private string adresse;
        private int codePostal;
        private string departement;
        private string concat = "Ajouter ";

        public LieuViewModel() { }
        public LieuViewModel(int id, string ville, string adresse, int codePostal, string departement)
        {
            this.id = id;
            this.ville = ville;
            this.adresse = adresse;
            this.codePostal = codePostal;
            this.departement = departement;

        }
        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string villeProperty
        {
            get { return ville; }
            set
            {
                ville = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string adresseProperty
        {
            get { return adresse; }
            set
            {
                adresse = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int codePostalProperty
        {
            get { return codePostal; }
            set
            {
                codePostal = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string departementProperty
        {
            get { return departement; }
            set
            {
                departement = value;
                OnPropertyChanged("ConcatProperty");
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
                LieuORM.updateLieu(this);
            }
        }
    }
}
