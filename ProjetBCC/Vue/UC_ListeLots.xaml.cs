using System.Windows;
using System.Windows.Controls;

namespace ProjetBCC.Vue
{
    public partial class UC_ListeLots : UserControl
    {
        public UC_ListeLots()
        {
            InitializeComponent();
        }
        private void Button_Click_addLot(object sender, RoutedEventArgs e)
        {
            UC_AjoutLot ajoutLot = new UC_AjoutLot();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutLot);
            
        }
    }
}