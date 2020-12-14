using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class VendeurViewModel : INotifyPropertyChanged
    {
        private int id;
        private int idPersonne;
        private string concat = "Ajouter ";

        public VendeurViewModel() { }

        public VendeurViewModel(int id, int idPersonne)
        {
            this.id = id;
            this.idPersonne = idPersonne;
        }

        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                idPersonne = value;
                OnPropertyChanged("nomVendeurProperty");
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
                VendeurORM.updateVendeur(this);
            }
        }
    }
}
