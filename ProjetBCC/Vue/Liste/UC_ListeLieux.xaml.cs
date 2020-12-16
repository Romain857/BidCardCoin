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
        int selectedLieuId;
        public static string onglet;
        public UC_ListeLieux()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadLieux();
        }
        void loadLieux()
        {
            li = LieuORM.listeLieu();
            myDataObjectLieu = new LieuViewModel();
            listeLieu.ItemsSource = li;
        }
        private void supprimerButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listeLieu.SelectedItem is LieuViewModel)
            {
                LieuViewModel toRemove = (LieuViewModel)listeLieu.SelectedItem;
                li.Remove(toRemove);
                listeLieu.Items.Refresh();
                LieuORM.supprimerLieu(selectedLieuId);
            }
        }
        private void listeLieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLieu.SelectedIndex < li.Count) && (listeLieu.SelectedIndex >= 0))
            {
                selectedLieuId = (li.ElementAt<LieuViewModel>(listeLieu.SelectedIndex)).idProperty;
            }
        }
        private void Button_Click_addLieu(object sender, RoutedEventArgs e)
        {
            UC_AjoutLieu ajoutLieu = new UC_AjoutLieu();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutLieu);
            
        }
        
    }
}