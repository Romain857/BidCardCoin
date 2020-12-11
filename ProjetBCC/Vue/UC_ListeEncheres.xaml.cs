using System.Windows;
using System.Windows.Controls;

namespace ProjetBCC.Vue
{
    public partial class UC_ListeEncheres : UserControl
    {
        public UC_ListeEncheres()
        {
            InitializeComponent();
        }
        private void Button_Click_addEnchere(object sender, RoutedEventArgs e)
        {
            UC_AjoutEnchere ajoutEnchere = new UC_AjoutEnchere();
            DisplayUC.Children.Clear();
            DisplayUC.Children.Add(ajoutEnchere);
            
        }
    }
}