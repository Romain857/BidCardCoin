using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {        
        //AdminViewModel myDataObject;
        //ObservableCollection<AdminViewModel> lp;
        public MainWindow()
        {
            InitializeComponent();
            //DALConnection.OpenConnection();
            //loadAdmins();
        }
        /*
        void loadAdmins()
        {
            lp = AdminORM.listeAdmins();
            myDataObject = new AdminViewModel();
            listeAdmins.ItemsSource = lp;
        }*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppliWindow win2 = new AppliWindow();
            win2.Show();
            this.Close();
        }
    }
}