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
    public partial class UC_AjoutVendeur : UserControl
    {
        PersonneViewModel myDataObjectPersonne;
        ObservableCollection<PersonneViewModel> pe;
        VendeurViewModel myDataObjectVendeur;
        ObservableCollection<VendeurViewModel> v;

        int compteur = 0;
        int selectedPersonneId;
        public static string onglet;
        public UC_AjoutVendeur()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            loadPersonnes();
            loadVendeurs();
            appliquerContexte();
        }
        void loadPersonnes()
        {
            pe = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            listePersonnes.ItemsSource = pe;
        }
        void loadVendeurs()
        {
            v = VendeurORM.listeVendeur();
            myDataObjectVendeur = new VendeurViewModel();
            //listePersonnes.ItemsSource = pe;
        }
        private void nomPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectPersonne.idProperty = PersonneDAL.getMaxIdPersonne() + 1;

            pe.Add(myDataObjectPersonne);
            PersonneORM.insertPersonne(myDataObjectPersonne);
            compteur = pe.Count();

            listePersonnes.Items.Refresh();
            myDataObjectPersonne = new PersonneViewModel();
            nomVendeur.DataContext = myDataObjectPersonne;
            prenomVendeur.DataContext = myDataObjectPersonne;
            mailVendeur.DataContext = myDataObjectPersonne;
            numVendeur.DataContext = myDataObjectPersonne;
            mdpVendeur.DataContext = myDataObjectPersonne;
            adresseVendeur.DataContext = myDataObjectPersonne;
            code_postalVendeur.DataContext = myDataObjectPersonne;
            ageVendeur.DataContext = myDataObjectPersonne;
            nomPersonnesButton.DataContext = myDataObjectPersonne;
        }

        private void listePersonne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < pe.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (pe.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idProperty;
            }
        }
        void appliquerContexte()
        {
            nomVendeur.DataContext = myDataObjectPersonne;
            prenomVendeur.DataContext = myDataObjectPersonne;
            mailVendeur.DataContext = myDataObjectPersonne;
            numVendeur.DataContext = myDataObjectPersonne;
            mdpVendeur.DataContext = myDataObjectPersonne;
            adresseVendeur.DataContext = myDataObjectPersonne;
            code_postalVendeur.DataContext = myDataObjectPersonne;
            ageVendeur.DataContext = myDataObjectPersonne;
        }
        private void Button_Click_submitVendeur(object sender, RoutedEventArgs e)
        {
            
        }
    }
}