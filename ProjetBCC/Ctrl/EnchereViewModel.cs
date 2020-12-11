using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class EnchereViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nomEnchere;
        private string heureEnchere;
        private DateTime dateEnchere;
        private int idLieu;
        private string concat = "Ajouter ";

        public EnchereViewModel() { }
        public EnchereViewModel(int id, string nomEnchere, string heureEnchere, DateTime dateEnchere, int idLieu)
        {
            this.id = id;
            this.nomEnchere = nomEnchere;
            this.heureEnchere = heureEnchere;
            this.dateEnchere = dateEnchere;
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
        public string nomEnchereProperty
        {
            get { return nomEnchere; }
            set
            {
                nomEnchere = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string heureEnchereProperty
        {
            get { return heureEnchere; }
            set
            {
                heureEnchere = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public DateTime dateEnchereProperty
        {
            get { return dateEnchere; }
            set
            {
                dateEnchere = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idLieuProperty
        {
            get { return idLieu; }
            set
            {
                idLieu = value;
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
                EnchereORM.updateEnchere(this);
            }
        }
    }
}
