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
namespace ProjetBCC
{
    /// <summary>
    /// Logique d'interaction pour UC_AjoutProd.xaml
    /// </summary>
    public partial class UC_AjoutProd : UserControl
    {
        ProduitViewModel myDataObjectProduit;
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<ProduitViewModel> lpr;
        PhotoViewModel myDataObjectPhoto;
        ObservableCollection<PhotoViewModel> lph;
        ObservableCollection<CategorieViewModel> c;
        LotViewModel myDataObjectLot;
        ObservableCollection<LotViewModel> lo;
        VendeurViewModel myDataObjectVendeur;
        ObservableCollection<VendeurViewModel> v;
        AcheteurViewModel myDataObjectAcheteur;
        ObservableCollection<AcheteurViewModel> a;
        int compteur = 0;
        int selectedProduitId;
        public UC_AjoutProd()
        {
            
            InitializeComponent();
            DALConnection.OpenConnection();
            loadProduits();
            //loadCategories();
            loadLots();
            loadProduits();
            loadPhotos();
            loadVendeurs();
            loadAcheteurs();
            appliquerContexte();
        }
        void loadVendeurs()
        {
            v = VendeurORM.listeVendeur();
            myDataObjectVendeur = new VendeurViewModel();
            ComboBoxVendeur.ItemsSource = v;
        }
        void loadProduits()
        {
            lpr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            listeProduits.ItemsSource = lpr;
        }
        void loadPhotos()
        {
            lph = PhotoORM.listePhoto();
            myDataObjectPhoto = new PhotoViewModel();
            ComboBoxPhoto.ItemsSource = lph;
        }
        void loadLots()
        {
            lo = LotORM.listeLot();
            myDataObjectLot = new LotViewModel();
            ComboBoxLot.ItemsSource = lo;
        }
        void loadAcheteurs()
        {
            a = AcheteurORM.listeAcheteur();
            myDataObjectAcheteur = new AcheteurViewModel();
            ComboBoxAcheteur.ItemsSource = a;
        }

        /*void loadCategories()
        {
            c = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            listeCategories.ItemsSource = c;
        }*/

        private void nomProduitButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectProduit.idProperty = ProduitDAL.getMaxIdProduit() + 1;

            lpr.Add(myDataObjectProduit);
            ProduitORM.insertProduit(myDataObjectProduit);
            compteur = lpr.Count();

            listeProduits.Items.Refresh();
            myDataObjectProduit = new ProduitViewModel();

            nomProduit.DataContext = myDataObjectProduit;
            estimation.DataContext = myDataObjectProduit;
            prixVente.DataContext = myDataObjectProduit;
            description.DataContext = myDataObjectProduit;
            style.DataContext = myDataObjectProduit;
            artiste.DataContext = myDataObjectProduit;
            dateVente.DataContext = myDataObjectProduit;
            ComboBoxAcheteur.DataContext = myDataObjectProduit;
            ComboBoxLot.DataContext = myDataObjectProduit;
            ComboBoxPhoto.DataContext = myDataObjectProduit;
            ComboBoxVendeur.DataContext = myDataObjectProduit;
            //categorie.DataContext = myDataObjectProduit;
            nomProduitButton.DataContext = myDataObjectProduit;
        }
        void appliquerContexte()
        {
            nomProduit.DataContext = myDataObjectProduit;
            estimation.DataContext = myDataObjectProduit;
            prixVente.DataContext = myDataObjectProduit;
            description.DataContext = myDataObjectProduit;
            style.DataContext = myDataObjectProduit;
            artiste.DataContext = myDataObjectProduit;
            dateVente.DataContext = myDataObjectProduit;
            ComboBoxAcheteur.DataContext = myDataObjectProduit;
            ComboBoxLot.DataContext = myDataObjectProduit;
            ComboBoxPhoto.DataContext = myDataObjectProduit;
            ComboBoxVendeur.DataContext = myDataObjectProduit;
            //categorie.DataContext = myDataObjectProduit;
            nomProduitButton.DataContext = myDataObjectProduit;
        }
        private void listeProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeProduits.SelectedIndex < lpr.Count) && (listeProduits.SelectedIndex >= 0))
            {
                selectedProduitId = (lpr.ElementAt<ProduitViewModel>(listeProduits.SelectedIndex)).idProperty;
            }
        }
    }
}
