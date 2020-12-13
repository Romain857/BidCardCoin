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
        EnchereViewModel myDataObjectEnchere;
        ObservableCollection<EnchereViewModel> el;
        int compteur = 0;
        int selectedEnchereId;
        public static string onglet;
        public UC_ListeEncheres()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadEncheres();
        }

        void loadEncheres()
        {
            el = EnchereORM.listeEncheres();
            myDataObjectEnchere = new EnchereViewModel();
            listeEncheres.ItemsSource = el;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeEncheres.SelectedItem is EnchereViewModel)
            {
                EnchereViewModel toRemove = (EnchereViewModel)listeEncheres.SelectedItem;
                el.Remove(toRemove);
                listeEncheres.Items.Refresh();
                EnchereORM.supprimerEnchere(selectedEnchereId);
            }
        }
        private void listeEnchere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEncheres.SelectedIndex < el.Count) && (listeEncheres.SelectedIndex >= 0))
            {
                selectedEnchereId = (el.ElementAt<EnchereViewModel>(listeEncheres.SelectedIndex)).idProperty;
            }
        }
        private void Button_Click_addEnchere(object sender, RoutedEventArgs e)
        {
            UC_AjoutEnchere ajoutEnchere = new UC_AjoutEnchere();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutEnchere);
            
        }
    }
}