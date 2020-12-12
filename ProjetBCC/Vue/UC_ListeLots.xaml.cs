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
        int selectedEnchereId;
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
        private void Button_Click_addLot(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}