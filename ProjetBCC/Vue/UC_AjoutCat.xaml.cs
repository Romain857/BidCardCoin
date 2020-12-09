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
    /// Logique d'interaction pour UC_AjoutCat.xaml
    /// </summary>
    public partial class UC_AjoutCat : UserControl
    {
        
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<CategorieViewModel> c;
        int compteur = 0;
        int selectedCategorieId;
        public static string onglet;
        public UC_AjoutCat()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadCategories();
            appliquerContexte();
        }
        void loadCategories()
        {
            c = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            listeCategories.ItemsSource = c;
        }
        private void nomCategorieButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectCategorie.idProperty = CategorieDAL.getMaxIdCategorie() + 1;

            c.Add(myDataObjectCategorie);
            CategorieORM.insertCategorie(myDataObjectCategorie);
            compteur = c.Count();

            listeCategories.Items.Refresh();
            myDataObjectCategorie = new CategorieViewModel();
            nomCategorieButton.DataContext = myDataObjectCategorie;
            nomTextBox.DataContext = myDataObjectCategorie;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeCategories.SelectedItem is CategorieViewModel)
            {
                CategorieViewModel toRemove = (CategorieViewModel)listeCategories.SelectedItem;
                c.Remove(toRemove);
                listeCategories.Items.Refresh();
                CategorieORM.supprimerCategorie(selectedCategorieId);
            }
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectCategorie.nomCategorieProperty = nomTextBox.Text;
        }
        private void listeCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCategories.SelectedIndex < c.Count) && (listeCategories.SelectedIndex >= 0))
            {
                selectedCategorieId = (c.ElementAt<CategorieViewModel>(listeCategories.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            nomTextBox.DataContext = myDataObjectCategorie;
            nomCategorieButton.DataContext = myDataObjectCategorie;
        }
        
    }
}
