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
    public partial class UC_ListeLieux : UserControl
    {
        LieuViewModel myDataObjectLieu;
        ObservableCollection<LieuViewModel> li;
        int compteur = 0;
        int selectedEnchereId;
        public static string onglet;
        public UC_ListeLieux()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadLieux();
            //appliquerContexte();
        }
        void loadLieux()
        {
            li = LieuORM.listeLieu();
            myDataObjectLieu = new LieuViewModel();
            listeLieux.ItemsSource = li;
        }
        private void Button_Click_addLieu(object sender, RoutedEventArgs e)
        {
            UC_AjoutLieu ajoutLieu = new UC_AjoutLieu();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutLieu);
            
        }
    }
}