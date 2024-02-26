using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Diagnostics;

namespace OOPWeek6
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Sqlconn = new SqlConnection(@"Server(DESKTOP-632FP9R);Database=Restaraunt;Trusted_Connection=Yes;");
            try
            {
                if (Sqlconn.State == ConnectionState.Closed)
                    Sqlconn.Open();
                string query = "SELECT COUNT(1) FROM user WHERE username=@Username AND password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, Sqlconn);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@PAssword", txtPassword.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar()); 
                if (count == 1)
                {
                    LoginScreen dashboard = new LoginScreen();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Sqlconn.Close();
            }


        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
