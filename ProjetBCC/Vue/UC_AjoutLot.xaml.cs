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
    public partial class UC_AjoutLot : UserControl
    {
        LotViewModel myDataObjectLot;
        ObservableCollection<LotViewModel> lo;
        EnchereViewModel myDataObjectEnchere;
        ObservableCollection<EnchereViewModel> en;
        int compteur = 0;
        int selectedLotId;
        public static string onglet;
        public UC_AjoutLot()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadLots();
            loadEnchere();
            appliquerContexte();
        }
        void loadLots()
        {
            lo = LotORM.listeLot();
            myDataObjectLot = new LotViewModel();
            listeLot.ItemsSource = lo;
        }
        void loadEnchere()
        {
            en = EnchereORM.listeEncheres();
            myDataObjectLot = new LotViewModel();
            ComboBoxEnchere.ItemsSource = en;
        }
        private void nomLotButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectLot.idProperty = LotDAL.getMaxIdLot() + 1;

            lo.Add(myDataObjectLot);
            LotORM.insertLot(myDataObjectLot);
            compteur = lo.Count();

            listeLot.Items.Refresh();
            myDataObjectLot = new LotViewModel();
            nomLot.DataContext = myDataObjectLot;
            descriptionLot.DataContext = myDataObjectLot;
            ComboBoxEnchere.DataContext = myDataObjectLot;
            nomLotButton.DataContext = myDataObjectLot;
        }

        private void listeLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLot.SelectedIndex < lo.Count) && (listeLot.SelectedIndex >= 0))
            {
                selectedLotId = (lo.ElementAt<LotViewModel>(listeLot.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            nomLot.DataContext = myDataObjectLot;
            descriptionLot.DataContext = myDataObjectLot;
            ComboBoxEnchere.DataContext = myDataObjectLot;
        }
        private void Button_Click_submitLot(object sender, RoutedEventArgs e)
        {
            
        }
    }
}