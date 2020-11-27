using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.Ctrl
{
    public class ProduitViewModel
    {
        private int id;
        private float estimation;
        private float prixVente;
        private string nom;
        private string artiste;
        private string style;
        private bool isVendu;
        private int idCategorie;
        private int idLot;
        private int idPhoto;

        public ProduitViewModel() { }

        public ProduitViewModel(int id, float estimation, float prixVente, string nom, string artiste, string style, bool isVendu, int idCategorie, int idLot, int idPhoto)
        {
            this.id = id;
            this.estimationProperty = estimation;
            this.prixVenteProperty = prixVente;
            this.nomProduitProperty = nom;
            this.artisteProperty = artiste;
            this.styleProperty = style;
            this.isVendu = isVendu;
            this.idCategorie = idCategorie;
            this.idLot = idLot;
            this.idPhoto = idPhoto;
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
            get { return estimation; }
            set
            {
                estimation = value;
            }
        }
        public float prixVenteProperty
        {
            get { return prixVente; }
            set
            {
                prixVente = value;
            }
        }
        public string nomProduitProperty
        {
            get { return nom; }
            set
            {
                nom = value;
            }
        }
        public string artisteProperty
        {
            get { return artiste; }
            set
            {
                artiste = value;
            }
        }
        public string styleProperty
        {
            get { return style; }
            set
            {
                style = value;
            }
        }
        public bool isVenduProperty
        {
            get { return isVendu; }
            set
            {
                isVendu = value;
            }
        }
        public int idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
            }
        }
        public int idLotProperty
        {
            get { return idLot; }
            set
            {
                idLot = value;
            }
        }
        public int idPhotoProperty
        {
            get { return idPhoto; }
            set
            {
                idPhoto = value;
            }
        }
    }
}
