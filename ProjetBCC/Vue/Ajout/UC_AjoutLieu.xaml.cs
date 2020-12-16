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
    public partial class UC_AjoutLieu : UserControl
    {
        LieuViewModel myDataObjectLieu;
        ObservableCollection<LieuViewModel> li;
        int compteur = 0;
        int selectedLieuId;
        public static string onglet;
        public UC_AjoutLieu()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadLieux();
            appliquerContexte();
        }
        void loadLieux()
        {
            li = LieuORM.listeLieu();
            myDataObjectLieu = new LieuViewModel();
            listeLieu.ItemsSource = li;
        }
        private void nomLieuButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectLieu.idProperty = LieuDAL.getMaxIdLieu() + 1;

            li.Add(myDataObjectLieu);
            LieuORM.insertLieu(myDataObjectLieu);
            compteur = li.Count();

            listeLieu.Items.Refresh();
            myDataObjectLieu = new LieuViewModel();
            ville.DataContext = myDataObjectLieu;
            adresse.DataContext = myDataObjectLieu;
            codePostal.DataContext = myDataObjectLieu;
            departement.DataContext = myDataObjectLieu;
            nomLieuButton.DataContext = myDataObjectLieu;
        }

        private void listeLieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLieu.SelectedIndex < li.Count) && (listeLieu.SelectedIndex >= 0))
            {
                selectedLieuId = (li.ElementAt<LieuViewModel>(listeLieu.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            ville.DataContext = myDataObjectLieu;
            adresse.DataContext = myDataObjectLieu;
            codePostal.DataContext = myDataObjectLieu;
            departement.DataContext = myDataObjectLieu;
        }
        private void Button_Click_submitLieu(object sender, RoutedEventArgs e)
        {
            
        }
    }
}