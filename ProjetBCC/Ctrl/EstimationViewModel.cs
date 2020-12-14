using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class EstimationViewModel
    {
        private string estimation;
        private string dateEstimation;
        private int idProduit;
        private int idAdmin;
        private string concat = "Ajouter ";

        public EstimationViewModel() { }

        public EstimationViewModel(string estimation, string dateEstimation, int idProduit, int idAdmin)
        {
            this.estimation = estimation;
            this.dateEstimation = dateEstimation;
            this.idProduit = idProduit;
            this.idAdmin = idAdmin;
        }
        public string estimationProperty
        {
            get { return estimation; }
            set
            {
                estimation = value;
            }
        }
        public string dateEstimationProperty
        {
            get { return dateEstimation; }
            set
            {
                dateEstimation = value;
            }
        }
        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public int idAdminProperty
        {
            get { return idAdmin; }
            set
            {
                idAdmin = value;
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
