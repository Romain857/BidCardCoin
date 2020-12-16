using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class OrdreAchatViewModel
    {
        private int idProduit;
        private int idAcheteur;
        private int idEnchere;
        private float montantMax;
        private string adresseDepot;
        private string concat = "Ajouter ";

        public OrdreAchatViewModel() { }

        public OrdreAchatViewModel(int idProduit, int idAcheteur, int idEnchere, float montantMax, string adresseDepot)
        {
            this.idProduit = idProduit;
            this.idAcheteur = idAcheteur;
            this.idEnchere = idEnchere;
            this.montantMax = montantMax;
            this.adresseDepot = adresseDepot;
        }
        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public int idAcheteurProperty
        {
            get { return idAcheteur; }
            set
            {
                idAcheteur = value;
                // OnPropertyChanged("nomCategorieProperty");
            }
        }
        public int idEnchereProperty
        {
            get { return idEnchere; }
            set
            {
                idEnchere = value;
                // OnPropertyChanged("nomCategorieProperty");
            }
        }
        public float montantMaxProperty
        {
            get { return montantMax; }
            set
            {
                montantMax = value;
            }
        }
        public string adresseDepotProperty
        {
            get { return adresseDepot; }
            set
            {
                adresseDepot = value;
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
