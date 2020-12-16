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
    public partial class UC_assocProd_Cat : UserControl
    {
        Produit_CategorieViewModel myDataObjectProduit_Categorie;
        ObservableCollection<Produit_CategorieViewModel> pc;
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<CategorieViewModel> cat;
        ProduitViewModel myDataObjectProduit;
        ObservableCollection<ProduitViewModel> pro;
        int compteur = 0;
        int selectedProduit_CategorieId;
        int selectedCategorieId;
        public static string onglet;
        public UC_assocProd_Cat()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadPC();
            loadCategories();
            loadProduits();
            appliquerContexte();
        }
        void loadPC()
        {
            pc = Produit_CategorieORM.listeProduit_Categorie();
            myDataObjectProduit_Categorie = new Produit_CategorieViewModel();
            listeProduit_Categories.ItemsSource = pc;
        }
        void loadCategories()
        {
            cat = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            ComboBoxCategorie.ItemsSource = cat;
        }
        void loadProduits()
        {
            pro = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pro;
        }
        private void nomProduit_CategorieButton_Click(object sender, RoutedEventArgs e)
        {
            pc.Add(myDataObjectProduit_Categorie);
            Produit_CategorieORM.insertProduit_Categorie(myDataObjectProduit_Categorie);
            compteur = pc.Count();

            listeProduit_Categories.Items.Refresh();
            myDataObjectProduit_Categorie = new Produit_CategorieViewModel();
            ComboBoxProduit.DataContext = myDataObjectProduit_Categorie;
            ComboBoxCategorie.DataContext = myDataObjectProduit_Categorie;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeProduit_Categories.SelectedItem is Produit_CategorieViewModel)
            {
                Produit_CategorieViewModel toRemove = (Produit_CategorieViewModel)listeProduit_Categories.SelectedItem;
                pc.Remove(toRemove);
                listeProduit_Categories.Items.Refresh();
                Produit_CategorieORM.supprimerProduit_Categorie(selectedProduit_CategorieId, selectedCategorieId);
            }
        }
        private void listeProduit_Categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeProduit_Categories.SelectedIndex < pc.Count) && (listeProduit_Categories.SelectedIndex >= 0))
            {
                selectedProduit_CategorieId = (pc.ElementAt<Produit_CategorieViewModel>(listeProduit_Categories.SelectedIndex)).idProduitProperty;
            }
            if ((listeProduit_Categories.SelectedIndex < pc.Count) && (listeProduit_Categories.SelectedIndex >= 0))
            {
                selectedCategorieId = (pc.ElementAt<Produit_CategorieViewModel>(listeProduit_Categories.SelectedIndex)).idCategorieProperty;
            }
        }
        void appliquerContexte()
        {
            ComboBoxProduit.DataContext = myDataObjectProduit_Categorie;
            ComboBoxCategorie.DataContext = myDataObjectProduit_Categorie;
            nomProduit_CategorieButton.DataContext = myDataObjectProduit_Categorie;
        }
    }
}