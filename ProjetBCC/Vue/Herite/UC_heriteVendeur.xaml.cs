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
    /// Logique d'interaction pour UC_heriteVendeur.xaml
    /// </summary>
    public partial class UC_heriteVendeur : UserControl
    {
        VendeurViewModel myDataObjectVendeur;
        PersonneViewModel myDataObjectPersonne;
        ObservableCollection<PersonneViewModel> person;
        ObservableCollection<VendeurViewModel> vende;
        int compteur = 0;
        int selectedheriteVendeurId;
        public static string onglet;
        public UC_heriteVendeur()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadPersonnes();
            loadVendeurs();
            appliquerContexte();
        }
        void loadPersonnes()
        {
            person = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            ComboBoxPersonne.ItemsSource = person;
        }
        void loadVendeurs()
        {
            vende = VendeurORM.listeVendeur();
            myDataObjectVendeur = new VendeurViewModel();
            listeheriteVendeurs.ItemsSource = vende;
        }
        private void nomheriteVendeurButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectVendeur.idProperty = VendeurDAL.getMaxIdVendeur() + 1;

            vende.Add(myDataObjectVendeur);
            VendeurORM.insertVendeur(myDataObjectVendeur);
            compteur = vende.Count();

            listeheriteVendeurs.Items.Refresh();
            myDataObjectVendeur = new VendeurViewModel();
            ComboBoxPersonne.DataContext = myDataObjectVendeur;
            nomheriteVendeurButton.DataContext = myDataObjectVendeur;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeheriteVendeurs.SelectedItem is VendeurViewModel)
            {
                VendeurViewModel toRemove = (VendeurViewModel)listeheriteVendeurs.SelectedItem;
                vende.Remove(toRemove);
                listeheriteVendeurs.Items.Refresh();
                VendeurORM.supprimerVendeur(selectedheriteVendeurId);
            }
        }
        private void listeheriteVendeur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeheriteVendeurs.SelectedIndex < vende.Count) && (listeheriteVendeurs.SelectedIndex >= 0))
            {
                selectedheriteVendeurId = (vende.ElementAt<VendeurViewModel>(listeheriteVendeurs.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            ComboBoxPersonne.DataContext = myDataObjectVendeur;
        }
    }
}