using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using ProjetBCC.Ctrl;
using ProjetBCC.DAO;
using ProjetBCC.DAL;
using ProjetBCC.ORM;
using ProjetBCC.Vue;

namespace ProjetBCC
{
    public partial class AppliWindow : Window
    {
        PersonneViewModel myDataObject;
        ProduitViewModel myDataObjectProduit;
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<PersonneViewModel> lp;
        ObservableCollection<ProduitViewModel> lpr;
        ObservableCollection<CategorieViewModel> c;
        int selectedProduitId;
        public static string onglet;
        public AppliWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadPersonnes();
            loadProduits();
            loadCategories();
        }

        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            listePersonnes.ItemsSource = lp;
        }

        void loadProduits()
        {
            lpr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            listeProduits.ItemsSource = lpr;
            listeArtistes.ItemsSource = lpr;
            listeStyles.ItemsSource = lpr;
        }

        void loadCategories()
        {
            c = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            listeCategories.ItemsSource = c;
        }


        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (listeProduits.SelectedItem is ProduitViewModel)
            {
                ProduitViewModel toRemove = (ProduitViewModel)listeProduits.SelectedItem;
                lpr.Remove(toRemove);
                listeProduits.Items.Refresh();
                ProduitORM.supprimerProduit(selectedProduitId);
            }
        }
        private void listeProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeProduits.SelectedIndex < lp.Count) && (listeProduits.SelectedIndex >= 0))
            {
                selectedProduitId = (lpr.ElementAt<ProduitViewModel>(listeProduits.SelectedIndex)).idProperty;
            }
        }
        private void Button_Click_addProduct(object sender, RoutedEventArgs e)
        {
            AjouterProduitWindow win3 = new AjouterProduitWindow();
            win3.Show();
            this.Close();
        }
        private void Button_Click_addCategorie(object sender, RoutedEventArgs e)
        {
            AjouterCategorieWindow win3 = new AjouterCategorieWindow();
            win3.Show();
            this.Close();
        }
    }
}