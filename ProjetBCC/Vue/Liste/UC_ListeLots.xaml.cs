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
    public partial class UC_ListeLots : UserControl
    {
        LotViewModel myDataObjectLot;
        ObservableCollection<LotViewModel> lo;
        int compteur = 0;
        int selectedLotId;
        public static string onglet;
        public UC_ListeLots()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadLots();
            //appliquerContexte();
        }
        void loadLots()
        {
            lo = LotORM.listeLot();
            myDataObjectLot = new LotViewModel();
            listeLots.ItemsSource = lo;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeLots.SelectedItem is LotViewModel)
            {
                LotViewModel toRemove = (LotViewModel)listeLots.SelectedItem;
                lo.Remove(toRemove);
                listeLots.Items.Refresh();
                LotORM.supprimerLot(selectedLotId);
            }
        }
        private void listeLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLots.SelectedIndex < lo.Count) && (listeLots.SelectedIndex >= 0))
            {
                selectedLotId = (lo.ElementAt<LotViewModel>(listeLots.SelectedIndex)).idProperty;
            }
        }
        private void Button_Click_addLot(object sender, RoutedEventArgs e)
        {
            UC_AjoutLot ajoutLot = new UC_AjoutLot();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutLot);
            
        }
    }
}