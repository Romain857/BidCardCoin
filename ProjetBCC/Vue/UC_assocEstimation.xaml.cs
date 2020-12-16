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
    /// Logique d'interaction pour UC_assocEstimation.xaml
    /// </summary>
    public partial class UC_assocEstimation : UserControl
    {
        EstimationViewModel myDataObjectEstimation;
        ObservableCollection<EstimationViewModel> est;
        ProduitViewModel myDataObjectProduit;
        ObservableCollection<ProduitViewModel> pro;
        AdminViewModel myDataObjectAdmin;
        ObservableCollection<AdminViewModel> ad;
        int compteur = 0;
        int selectedEstimationId;
        public static string onglet;
        public UC_assocEstimation()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadAdmins();
            loadProduits();
            loadEstimations();
            appliquerContexte();
        }
        void loadAdmins()
        {
            ad = AdminORM.listeAdmins();
            myDataObjectAdmin = new AdminViewModel();
            ComboBoxAdmin.ItemsSource = ad;
        }
        void loadProduits()
        {
            pro = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pro;
        }
        void loadEstimations()
        {
            est = EstimationORM.listeEstimation();
            myDataObjectEstimation = new EstimationViewModel();
            listeEstimations.ItemsSource = est;
        }
        private void nomEstimationButton_Click(object sender, RoutedEventArgs e)
        {
            est.Add(myDataObjectEstimation);
            EstimationORM.insertEstimation(myDataObjectEstimation);
            compteur = est.Count();

            listeEstimations.Items.Refresh();
            myDataObjectEstimation = new EstimationViewModel();
            estimation.DataContext = myDataObjectEstimation;
            dateEstimation.DataContext = myDataObjectEstimation;
            ComboBoxProduit.DataContext = myDataObjectEstimation;
            ComboBoxAdmin.DataContext = myDataObjectEstimation;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeEstimations.SelectedItem is EstimationViewModel)
            {
                EstimationViewModel toRemove = (EstimationViewModel)listeEstimations.SelectedItem;
                est.Remove(toRemove);
                listeEstimations.Items.Refresh();
                EstimationORM.supprimerEstimation(selectedEstimationId);
            }
        }
        private void listeEstimation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEstimations.SelectedIndex < est.Count) && (listeEstimations.SelectedIndex >= 0))
            {
                selectedEstimationId = (est.ElementAt<EstimationViewModel>(listeEstimations.SelectedIndex)).idProduitProperty;
            }
        }
        void appliquerContexte()
        {
            estimation.DataContext = myDataObjectEstimation;
            dateEstimation.DataContext = myDataObjectEstimation;
            ComboBoxProduit.DataContext = myDataObjectEstimation;
            ComboBoxAdmin.DataContext = myDataObjectEstimation;
            nomEstimationButton.DataContext = myDataObjectEstimation;
        }
    }
}
