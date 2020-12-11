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
    public partial class UC_ListeEncheres : UserControl
    {
        /*EnchereViewModel myDataObjectEnchere;
        ObservableCollection<EnchereViewModel> e;
        int compteur = 0;
        int selectedEnchereId;
        public static string onglet;*/
        public UC_ListeEncheres()
        {
            InitializeComponent();
            //DALConnection.OpenConnection();
            //loadEncheres();
            //appliquerContexte();
        }

        /*void loadEncheres()
        {
            e = EnchereORM.listeEncheres();
            myDataObjectEnchere = new EnchereViewModel();
            listeEncheres.ItemsSource = e;
        }
        private void nomEnchereButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectEnchere.idProperty = EnchereDAL.getMaxIdEnchere() + 1;

            e.Add(myDataObjectEnchere);
            EnchereORM.insertEnchere(myDataObjectEnchere);
            compteur = e.Count();

            listeEncheres.Items.Refresh();
            myDataObjectEnchere = new EnchereViewModel();
            nomEnchereButton.DataContext = myDataObjectEnchere;
            nomTextBox.DataContext = myDataObjectEnchere;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeEncheres.SelectedItem is EnchereViewModel)
            {
                EnchereViewModel toRemove = (EnchereViewModel)listeEncheres.SelectedItem;
                e.Remove(toRemove);
                listeEncheres.Items.Refresh();
                EnchereORM.supprimerEnchere(selectedEnchereId);
            }
        }
        private void listeEnchere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEncheres.SelectedIndex < e.Count) && (listeEncheres.SelectedIndex >= 0))
            {
                selectedEnchereId = (e.ElementAt<EnchereViewModel>(listeEncheres.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            nomTextBox.DataContext = myDataObjectEnchere;
            nomEnchereButton.DataContext = myDataObjectEnchere;
        }*/
        private void Button_Click_addEnchere(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}