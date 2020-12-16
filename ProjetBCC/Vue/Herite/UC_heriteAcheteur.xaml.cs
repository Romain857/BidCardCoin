using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetBCC.Ctrl;
using ProjetBCC.DAL;
using ProjetBCC.ORM;
using ProjetBCC.Vue;

namespace ProjetBCC.Vue
{
    /// <summary>
    /// Logique d'interaction pour UC_heriteAcheteur.xaml
    /// </summary>
    public partial class UC_heriteAcheteur : UserControl
    {
        AcheteurViewModel myDataObjectAcheteur;
        PersonneViewModel myDataObjectPersonne;
        ObservableCollection<PersonneViewModel> person;
        ObservableCollection<AcheteurViewModel> achete;
        int compteur = 0;
        int selectedheriteAcheteurId;
        public static string onglet;
        public UC_heriteAcheteur()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadPersonnes();
            loadAcheteurs();
            appliquerContexte();
        }
        void loadPersonnes()
        {
            person = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            ComboBoxPersonne.ItemsSource = person;
        }
        void loadAcheteurs()
        {
            achete = AcheteurORM.listeAcheteur();
            myDataObjectAcheteur= new AcheteurViewModel();
            listeheriteAcheteurs.ItemsSource = achete;
        }
        private void nomheriteAcheteurButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectAcheteur.idProperty = AcheteurDAL.getMaxIdAcheteur() + 1;

            achete.Add(myDataObjectAcheteur);
            AcheteurORM.insertAcheteur(myDataObjectAcheteur);
            compteur = achete.Count();

            listeheriteAcheteurs.Items.Refresh();
            myDataObjectAcheteur = new AcheteurViewModel();
            solde.DataContext = myDataObjectAcheteur;
            isSolvable.DataContext = myDataObjectAcheteur;
            identite.DataContext = myDataObjectAcheteur;
            moyenPaiement.DataContext = myDataObjectAcheteur;
            ComboBoxPersonne.DataContext = myDataObjectAcheteur;
            nomheriteAcheteurButton.DataContext = myDataObjectAcheteur;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeheriteAcheteurs.SelectedItem is AcheteurViewModel)
            {
                AcheteurViewModel toRemove = (AcheteurViewModel)listeheriteAcheteurs.SelectedItem;
                achete.Remove(toRemove);
                listeheriteAcheteurs.Items.Refresh();
                AcheteurORM.supprimerAcheteur(selectedheriteAcheteurId);
            }
        }
        private void listeheriteAcheteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeheriteAcheteurs.SelectedIndex < achete.Count) && (listeheriteAcheteurs.SelectedIndex >= 0))
            {
                selectedheriteAcheteurId = (achete.ElementAt<AcheteurViewModel>(listeheriteAcheteurs.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            solde.DataContext = myDataObjectAcheteur;
            isSolvable.DataContext = myDataObjectAcheteur;
            identite.DataContext = myDataObjectAcheteur;
            moyenPaiement.DataContext = myDataObjectAcheteur;
            ComboBoxPersonne.DataContext = myDataObjectAcheteur;
        }
    }
}
