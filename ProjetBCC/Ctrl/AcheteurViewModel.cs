using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class AcheteurViewModel : INotifyPropertyChanged
    {
        private int id;
        private float solde;
        private bool isSolvable;
        private string identite;
        private string moyenPaiement;
        private int idPersonne;
        private string concat = "Ajouter ";

        public AcheteurViewModel() { }

        public AcheteurViewModel(int id, float solde, bool isSolvable, string identite, string moyenPaiement, int idPersonne)
        {
            this.id = id;
            this.solde = solde;
            this.isSolvable = isSolvable;
            this.identite = identite;
            this.moyenPaiement = moyenPaiement;
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
        public float soldeProperty
        {
            get { return solde; }
            set
            {
                solde = value;
                OnPropertyChanged("nomAcheteurProperty");
            }
        }
        public bool isSolvableProperty
        {
            get { return isSolvable; }
            set
            {
                isSolvable = value;
                OnPropertyChanged("nomAcheteurProperty");
            }
        }
        public string identiteProperty
        {
            get { return identite; }
            set
            {
                identite = value;
                OnPropertyChanged("nomAcheteurProperty");
            }
        }
        public string moyenPaiementProperty
        {
            get { return moyenPaiement; }
            set
            {
                moyenPaiement = value;
                OnPropertyChanged("nomAcheteurProperty");
            }
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                idPersonne = value;
                OnPropertyChanged("nomAcheteurProperty");
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
                AcheteurORM.updateAcheteur(this);
            }
        }
    }
}
