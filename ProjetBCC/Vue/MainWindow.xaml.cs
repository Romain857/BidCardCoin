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
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using ProjetBCC.Ctrl;
using ProjetBCC.DAO;
using ProjetBCC.DAL;
using ProjetBCC.ORM;
using ProjetBCC.Vue;

namespace ProjetBCC.Vue
{
    public partial class MainWindow : Window
    {
        AdminViewModel myDataObject;
        ObservableCollection<AdminViewModel> la;
        MySqlDataReader reader = null;
        
        public MainWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text.Length == 0)  
            {  
                errorMessage.Text = "Entrez un Email";  
                emailTextBox.Focus();  
            }  
            else if (!Regex.IsMatch(emailTextBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))  
            {  
                errorMessage.Text = "Entrez un Email valide";  
                emailTextBox.Select(0, emailTextBox.Text.Length);  
                emailTextBox.Focus();  
            }
            else
            {
                
                //string email = "";
                //string mdp = "";
                //MySqlCommand cmd = new MySqlCommand("Select * from admin where mail=\"" + @email + "\" and motDePasse=\"" + mdp + "\"", DALConnection.OpenConnection());
                MySqlCommand cmd = new MySqlCommand("Select * from admin where mail=@email",
                    DALConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@email", emailTextBox.Text.ToString());
                reader = cmd.ExecuteReader();
                errorMessage.Text = "1";
                
                
                if (reader.Read())
                {
                    errorMessage.Text = "2";
                    if (reader["motDePasse"].ToString().Equals(mdpTextBox.Password.ToString(),StringComparison.InvariantCulture))
                    {
                        errorMessage.Text = "oui";
                        reader.Close();
                        AppliWindow win2 = new AppliWindow(); 
                        win2.Show();
                        this.Close();
                    }
                    else
                    {
                        errorMessage.Text = "Mot de passe invalide";
                    }
                }
                
            } 
            
        }

        private void appliwindow()
        {
            
        }
    }
}