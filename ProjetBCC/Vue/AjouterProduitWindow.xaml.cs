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

namespace ProjetBCC.Vue
{
    /// <summary>
    /// Logique d'interaction pour AjouterProduitWindow.xaml
    /// </summary>
    public partial class AjouterProduitWindow : Window
    {
        ProduitViewModel myDataObjectProduit;
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<ProduitViewModel> lpr;
        ObservableCollection<CategorieViewModel> c;
        int compteur = 0;
        public AjouterProduitWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadProduits();
            loadCategories();
        }
        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            AppliWindow win2 = new AppliWindow();
            win2.Show();
            this.Close();
        }
        void loadProduits()
        {
            lpr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            listeArtistes.ItemsSource = lpr;
            listeStyles.ItemsSource = lpr;
        }

        void loadCategories()
        {
            c = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            listeCategories.ItemsSource = c;
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            AppliWindow win3 = new AppliWindow();
            this.Close();
            win3.Show();
        }
        private void nomPrenomButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectProduit.idProperty = ProduitDAL.getMaxIdProduit() + 1;

            lpr.Add(myDataObjectProduit);
            ProduitORM.insertProduit(myDataObjectProduit);
            compteur = lpr.Count();

            listeProduits.Items.Refresh();
            myDataObjectProduit = new ProduitViewModel();

            nomProduit.DataContext = myDataObjectProduit;
            estimation.DataContext = myDataObjectProduit;
            description.DataContext = myDataObjectProduit;
            //style.DataContext = myDataObjectProduit;
            //artiste.DataContext = myDataObjectProduit;
            //categorie.DataContext = myDataObjectProduit;
            nomPrenomButton2.DataContext = myDataObjectProduit;
        }
        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // On ne fait rien
        }
    }
}
