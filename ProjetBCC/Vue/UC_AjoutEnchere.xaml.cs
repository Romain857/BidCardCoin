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
    public partial class UC_AjoutEnchere : UserControl
    {
        EnchereViewModel myDataObjectEnchere;
        LieuViewModel myDataObjectLieu;
        AdminViewModel myDataObjectAdmin;
        ObservableCollection<EnchereViewModel> el;
        ObservableCollection<LieuViewModel> li;
        ObservableCollection<AdminViewModel> pers;
        int compteur = 0;
        int selectedEnchereId;
        public static string onglet;
        public UC_AjoutEnchere()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadEncheres();
            loadLieux();
            loadAdmins();
            appliquerContexte();
        }
        void loadEncheres()
        {
            el = EnchereORM.listeEncheres();
            myDataObjectEnchere = new EnchereViewModel();
            listeEncheres.ItemsSource = el;
        }
        void loadLieux()
        {
            li = LieuORM.listeLieu();
            myDataObjectLieu = new LieuViewModel();
            ComboBoxLieu.ItemsSource = li;
        }
        void loadAdmins()
        {
            pers = AdminORM.listeAdmins();
            myDataObjectAdmin = new AdminViewModel();
            ComboBoxAdmin.ItemsSource = pers;
        }
        private void nomEnchereButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectEnchere.idProperty = EnchereDAL.getMaxIdEnchere() + 1;

            el.Add(myDataObjectEnchere);
            EnchereORM.insertEnchere(myDataObjectEnchere);
            compteur = el.Count();

            listeEncheres.Items.Refresh();
            myDataObjectEnchere = new EnchereViewModel();
            nomEnchere.DataContext = myDataObjectEnchere;
            heure.DataContext = myDataObjectEnchere;
            dateVente.DataContext = myDataObjectEnchere;
            ComboBoxLieu.DataContext = myDataObjectEnchere;
            ComboBoxAdmin.DataContext = myDataObjectEnchere;
            nomEnchereButton.DataContext = myDataObjectEnchere;
        }
        
        private void listeEnchere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEncheres.SelectedIndex < el.Count) && (listeEncheres.SelectedIndex >= 0))
            {
                selectedEnchereId = (el.ElementAt<EnchereViewModel>(listeEncheres.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            nomEnchere.DataContext = myDataObjectEnchere;
            heure.DataContext = myDataObjectEnchere;
            dateVente.DataContext = myDataObjectEnchere;
            ComboBoxLieu.DataContext = myDataObjectEnchere;
            ComboBoxAdmin.DataContext = myDataObjectEnchere;
        }
    }
}