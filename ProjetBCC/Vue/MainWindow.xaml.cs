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

namespace ProjetBCC
{
    public partial class MainWindow : Window
    {        
        //PersonneViewModel myDataObject;
        //ObservableCollection<PersonneViewModel> lp;
        public MainWindow()
        {
            InitializeComponent();
            //DALConnection.OpenConnection();
            //loadPersonnes();
        }
        /*
        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            listePersonnes.ItemsSource = lp;
        }*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppliWindow win2 = new AppliWindow();
            win2.Show();
            this.Close();
        }
    }
}