using ProjetBCC.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.Ctrl
{
    public class ProduitViewModel : INotifyPropertyChanged
    {
        private int id;
        private float estimationActuelle;
        private float prixVente;
        private string nom;
        private string description;
        private string artiste;
        private string style;
        private string dateVente;
        private int idLot;
        private int idPhoto;
        private int idAcheteur;
        private int idVendeur;
        private string concat = "Ajouter ";

        public ProduitViewModel() { }
        public ProduitViewModel(int id, float estimationActuelle, float prixVente, string nom, string description, string artiste, string style, string dateVente, int idLot, int idPhoto, int idAcheteur, int idVendeur)
        {
            this.id = id;
            this.estimationProperty = estimationActuelle;
            this.prixVenteProperty = prixVente;
            this.nomProduitProperty = nom;
            this.descriptionProperty = description;
            this.artisteProperty = artiste;
            this.styleProperty = style;
            this.dateVenteProperty = dateVente;
            this.idLot = idLot;
            this.idPhoto = idPhoto;
            this.idAcheteur = idAcheteur;
            this.idVendeur = idVendeur;
        }
        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public float estimationProperty
        {
            get { return estimationActuelle; }
            set
            {
                estimationActuelle = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public float prixVenteProperty
        {
            get { return prixVente; }
            set
            {
                prixVente = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string nomProduitProperty
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
        public string artisteProperty
        {
            get { return artiste; }
            set
            {
                artiste = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string styleProperty
        {
            get { return style; }
            set
            {
                style = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public string dateVenteProperty
        {
            get { return dateVente; }
            set
            {
                dateVente = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idLotProperty
        {
            get { return idLot; }
            set
            {
                idLot = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idPhotoProperty
        {
            get { return idPhoto; }
            set
            {
                idPhoto = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idAcheteurProperty
        {
            get { return idAcheteur; }
            set
            {
                idAcheteur = value;
                OnPropertyChanged("ConcatProperty");
            }
        }
        public int idVendeurProperty
        {
            get { return idVendeur; }
            set
            {
                idVendeur = value;
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
                ProduitORM.updateProduit(this);
            }
        }
    }
}
