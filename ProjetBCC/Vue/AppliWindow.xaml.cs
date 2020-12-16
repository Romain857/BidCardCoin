using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class AppliWindow : Window
    {
        public static string onglet;
        
        AdminViewModel myDataObject;
        ProduitViewModel myDataObjectProduit;
        CategorieViewModel myDataObjectCategorie;
        PersonneViewModel myDataObjectPersonne;
        ObservableCollection<AdminViewModel> la;
        AcheteurViewModel myDataObjectAcheteur;
        ObservableCollection<AcheteurViewModel> a;
        ObservableCollection<ProduitViewModel> lpr;
        ObservableCollection<CategorieViewModel> c;
        ObservableCollection<PersonneViewModel> lp;
        int selectedProduitId;
        int selectedPersonneId;

        int compteur = 0;
        int selectedCategorieId;
        
        
        public AppliWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadAdmins();
            loadProduits();
            loadCategories();
            loadPersonnes();
            loadAcheteurs();

        }
        
        void loadAdmins()
        {
            la = AdminORM.listeAdmins();
            myDataObject = new AdminViewModel();
            listeAdmins.ItemsSource = la;
        }

        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            listePersonnes.ItemsSource = lp;
        }
        void loadAcheteurs()
        {
            a = AcheteurORM.listeAcheteur();
            myDataObjectAcheteur = new AcheteurViewModel();
            //listeAcheteurs.ItemsSource = a;
        }

        void loadProduits()
        {
            lpr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            listeProduits.ItemsSource = lpr;
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
            
            UC_AjoutProd ajoutProd = new UC_AjoutProd();
            MainProd.Visibility = Visibility.Collapsed;
            returnButtonProd.Visibility = Visibility.Visible;
            DisplayUCProd.Children.Clear();
            DisplayUCProd.Children.Add(ajoutProd);     
        }

        private void Button_Click_addCategorie(object sender, RoutedEventArgs e)
        {
            UC_AjoutCat ajoutCat = new UC_AjoutCat();
            MainProd.Visibility = Visibility.Collapsed;
            returnButtonProd.Visibility = Visibility.Visible;
            DisplayUCProd.Children.Clear();
            DisplayUCProd.Children.Add(ajoutCat);
        
        }
        private void Button_Click_assignProd_Cat(object sender, RoutedEventArgs e)
        {
            UC_assocProd_Cat assocProdCat = new UC_assocProd_Cat();
            MainProd.Visibility = Visibility.Collapsed;
            returnButtonProd.Visibility = Visibility.Visible;
            DisplayUCProd.Children.Clear();
            DisplayUCProd.Children.Add(assocProdCat);
        
        }

        private void Button_Click_addVendeur(object sender, RoutedEventArgs e)
        {
            UC_AjoutVendeur ajoutVendeur = new UC_AjoutVendeur();
            MainUtil.Visibility = Visibility.Collapsed;
            returnButtonUtil.Visibility = Visibility.Visible;
            DisplayUCUtil.Children.Clear();
            DisplayUCUtil.Children.Add(ajoutVendeur);
            
        }
        private void Button_Click_addheriteVendeur(object sender, RoutedEventArgs e)
        {
            UC_heriteVendeur heriteVendeur = new UC_heriteVendeur();
            MainUtil.Visibility = Visibility.Collapsed;
            returnButtonUtil.Visibility = Visibility.Visible;
            DisplayUCUtil.Children.Clear();
            DisplayUCUtil.Children.Add(heriteVendeur);
        }
        private void Button_Click_addheriteAcheteur(object sender, RoutedEventArgs e)
        {
            UC_heriteAcheteur heriteAcheteur = new UC_heriteAcheteur();
            MainUtil.Visibility = Visibility.Collapsed;
            returnButtonUtil.Visibility = Visibility.Visible;
            DisplayUCUtil.Children.Clear();
            DisplayUCUtil.Children.Add(heriteAcheteur);
        }

        private void Button_cancel_prod(object sender, RoutedEventArgs e)
        {
            DisplayUCProd.Children.Clear();
            returnButtonProd.Visibility = Visibility.Collapsed;
            MainProd.Visibility = Visibility.Visible;

        }
        private void Button_cancel_util(object sender, RoutedEventArgs e)
        {
            DisplayUCUtil.Children.Clear();
            returnButtonUtil.Visibility = Visibility.Collapsed;
            MainUtil.Visibility = Visibility.Visible;

        }

        private void Button_Click_ListEnchere(object sender, RoutedEventArgs e)
        {
            UC_ListeEncheres listeEncheres = new UC_ListeEncheres();
            DisplayUCAccueil.Children.Clear();
            DisplayUCAccueil.Children.Add(listeEncheres);
        }
        private void Button_Click_ListLieux(object sender, RoutedEventArgs e)
        {
            UC_ListeLieux listeLieux = new UC_ListeLieux();
            DisplayUCAccueil.Children.Clear();
            DisplayUCAccueil.Children.Add(listeLieux);
        }
        
        private void Button_Click_ListLots(object sender, RoutedEventArgs e)
        {
            UC_ListeLots listeLots = new UC_ListeLots();
            DisplayUCAccueil.Children.Clear();
            DisplayUCAccueil.Children.Add(listeLots);
        }
        private void Button_Click_addEstimation(object sender, RoutedEventArgs e)
        {
            UC_assocEstimation assocEstimation = new UC_assocEstimation();
            MainUtil.Visibility = Visibility.Collapsed;
            returnButtonUtil.Visibility = Visibility.Visible;
            DisplayUCUtil.Children.Clear();
            DisplayUCUtil.Children.Add(assocEstimation);
        }
        private void Button_Click_addOrdreAchat(object sender, RoutedEventArgs e)
        {
            UC_assocOrdreAchat assocOrdreAchat = new UC_assocOrdreAchat();
            MainProd.Visibility = Visibility.Collapsed;
            returnButtonProd.Visibility = Visibility.Visible;
            DisplayUCProd.Children.Clear();
            DisplayUCProd.Children.Add(assocOrdreAchat);
        }
        private void supprimerButton_Click2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listePersonnes.SelectedItem is PersonneViewModel)
            {
                PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
                lp.Remove(toRemove);
                listePersonnes.Items.Refresh();
                PersonneORM.supprimerPersonne(selectedPersonneId);
            }
        }
        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idProperty;
            }
        }
        
        }
    }
