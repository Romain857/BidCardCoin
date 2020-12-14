using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class LotViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string description;
        private int idEnchere;
        private string concat = "Ajouter ";

        public LotViewModel() { }
        public LotViewModel(int id, string nom, string description, int idEnchere)
        {
            this.id = id;
            this.nom = nom;
            this.description = description;
            this.idEnchere = idEnchere;

        }
        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string nomProperty
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string descriptionProperty
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idEnchereProperty
        {
            get { return idEnchere; }
            set
            {
                idEnchere = value;
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
                LotORM.updateLot(this);
            }
        }
    }
}
