using System.Windows;
using System.Windows.Controls;

namespace ProjetBCC.Vue
{
    public partial class UC_ListeLieux : UserControl
    {
        public UC_ListeLieux()
        {
            InitializeComponent();
        }
        private void Button_Click_addLieu(object sender, RoutedEventArgs e)
        {
            UC_AjoutLieu ajoutLieu = new UC_AjoutLieu();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutLieu);
            
        }
    }
}