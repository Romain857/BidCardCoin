using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class Produit_CategorieViewModel //: INotifyPropertyChanged
    {
        private int idProduit;
        private int idCategorie;
        private string concat = "Ajouter ";

        public Produit_CategorieViewModel() { }

        public Produit_CategorieViewModel(int idProduit, int idCategorie)
        {
            this.idProduit = idProduit;
            this.idCategorie = idCategorie;
        }

        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public int idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
               // OnPropertyChanged("nomCategorieProperty");
            }
        }

        public string ConcatProperty
        {
            get { return concat; }
            set
            {
                this.concat = value;
                //OnPropertyChanged("ConcatProperty");
            }
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                Produit_CategorieORM.updateProduit_Categorie(this);
            }
        }*/
    }
}
