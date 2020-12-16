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
    /// Logique d'interaction pour UC_assocOrdreAchat.xaml
    /// </summary>
    public partial class UC_assocOrdreAchat : UserControl
    {
        OrdreAchatViewModel myDataObjectOrdreAchat;
        ObservableCollection<OrdreAchatViewModel> oa;
        ProduitViewModel myDataObjectProduit;
        ObservableCollection<ProduitViewModel> produ;
        AcheteurViewModel myDataObjectAcheteur;
        ObservableCollection<AcheteurViewModel> achet;
        EnchereViewModel myDataObjectEnchere;
        ObservableCollection<EnchereViewModel> ench;
        int compteur = 0;
        int selectedOrdreAchatId;
        int selectedOrdreAchatAcheteurId;
        int selectedOrdreAchatEnchereId;
        public static string onglet;
        public UC_assocOrdreAchat()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadAcheteurs();
            loadProduits();
            loadOrdreAchats();
            loadEncheres();
            appliquerContexte();
        }
        void loadAcheteurs()
        {
            achet = AcheteurORM.listeAcheteur();
            myDataObjectAcheteur = new AcheteurViewModel();
            ComboBoxAcheteur.ItemsSource = achet;
        }
        void loadProduits()
        {
            produ = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = produ;
        }
        void loadEncheres()
        {
            ench = EnchereORM.listeEncheres();
            myDataObjectEnchere = new EnchereViewModel();
            ComboBoxEnchere.ItemsSource = ench;
        }
        void loadOrdreAchats()
        {
            oa = OrdreAchatORM.listeOrdreAchat();
            myDataObjectOrdreAchat = new OrdreAchatViewModel();
            listeOrdreAchats.ItemsSource = oa;
        }
        private void nomOrdreAchatButton_Click(object sender, RoutedEventArgs e)
        {
            oa.Add(myDataObjectOrdreAchat);
            OrdreAchatORM.insertOrdreAchat(myDataObjectOrdreAchat);
            compteur = oa.Count();

            listeOrdreAchats.Items.Refresh();
            myDataObjectOrdreAchat = new OrdreAchatViewModel();
            nomOrdreAchatButton.DataContext = myDataObjectOrdreAchat;
            montantMax.DataContext = myDataObjectOrdreAchat;
            adresseDepot.DataContext = myDataObjectOrdreAchat;
            ComboBoxProduit.DataContext = myDataObjectOrdreAchat;
            ComboBoxAcheteur.DataContext = myDataObjectOrdreAchat;
            ComboBoxEnchere.DataContext = myDataObjectOrdreAchat;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeOrdreAchats.SelectedItem is OrdreAchatViewModel)
            {
                OrdreAchatViewModel toRemove = (OrdreAchatViewModel)listeOrdreAchats.SelectedItem;
                oa.Remove(toRemove);
                listeOrdreAchats.Items.Refresh();
                OrdreAchatORM.supprimerOrdreAchat(selectedOrdreAchatId, selectedOrdreAchatAcheteurId, selectedOrdreAchatEnchereId);
            }
        }
        private void listeOrdreAchat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeOrdreAchats.SelectedIndex < oa.Count) && (listeOrdreAchats.SelectedIndex >= 0))
            {
                selectedOrdreAchatId = (oa.ElementAt<OrdreAchatViewModel>(listeOrdreAchats.SelectedIndex)).idProduitProperty;
            }
            if ((listeOrdreAchats.SelectedIndex < oa.Count) && (listeOrdreAchats.SelectedIndex >= 0))
            {
                selectedOrdreAchatAcheteurId = (oa.ElementAt<OrdreAchatViewModel>(listeOrdreAchats.SelectedIndex)).idAcheteurProperty;
            }
            if ((listeOrdreAchats.SelectedIndex < oa.Count) && (listeOrdreAchats.SelectedIndex >= 0))
            {
                selectedOrdreAchatEnchereId = (oa.ElementAt<OrdreAchatViewModel>(listeOrdreAchats.SelectedIndex)).idEnchereProperty;
            }
        }
        void appliquerContexte()
        {
            montantMax.DataContext = myDataObjectOrdreAchat;
            adresseDepot.DataContext = myDataObjectOrdreAchat;
            ComboBoxProduit.DataContext = myDataObjectOrdreAchat;
            ComboBoxAcheteur.DataContext = myDataObjectOrdreAchat;
            ComboBoxEnchere.DataContext = myDataObjectOrdreAchat;
            nomOrdreAchatButton.DataContext = myDataObjectOrdreAchat;
        }
    }
}