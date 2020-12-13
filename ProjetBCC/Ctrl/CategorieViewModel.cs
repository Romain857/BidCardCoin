using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nomCategorie;
        private string concat = "Ajouter ";

        public CategorieViewModel() { }

        public CategorieViewModel(int id, string nomCategorie)
        {
            this.id = id;
            this.nomCategorie = nomCategorie;
        }

        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public String nomCategorieProperty
        {
            get { return nomCategorie; }
            set
            {
                nomCategorie = value;
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
                CategorieORM.updateCategorie(this);  
            }
        }
    }
}
