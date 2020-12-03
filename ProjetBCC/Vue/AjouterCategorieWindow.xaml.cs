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
    /// Logique d'interaction pour AjouterCategorieWindow.xaml
    /// </summary>
    public partial class AjouterCategorieWindow : Window
    {
        CategorieViewModel myDataObjectCategorie;
        ObservableCollection<CategorieViewModel> c;
        int compteur = 0;
        int selectedCategorieId;
        public AjouterCategorieWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadCategories();
        }

        void loadCategories()
        {
            c = CategorieORM.listeCategorie();
            myDataObjectCategorie = new CategorieViewModel();
            listeCategories.ItemsSource = c;
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppliWindow win3 = new AppliWindow();
            win3.Show();
            this.Close();
        }
        private void nomCategorieButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectCategorie.idProperty = CategorieDAL.getMaxIdCategorie() + 1;

            c.Add(myDataObjectCategorie);
            CategorieORM.insertCategorie(myDataObjectCategorie);
            compteur = c.Count();

            listeCategories.Items.Refresh();
            myDataObjectCategorie = new CategorieViewModel();

            nomCategorie.DataContext = myDataObjectCategorie;
            nomCategorieButton.DataContext = myDataObjectCategorie;
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
    }
}