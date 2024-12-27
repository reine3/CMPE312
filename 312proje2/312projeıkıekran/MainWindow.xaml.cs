using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _312projeıkıekran
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["_312projeıkıekran.Properties.Settings.flamingoRentConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void CheckUsername_Click(object sender, RoutedEventArgs e)
        {
            string username = usernametextbox.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [dbo].[USER] WHERE userName = @userName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userName", username);

                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                          
                            kullanıcıyön kullanıcıYönEkranı = new kullanıcıyön(); // Doğru sınıf adıyla nesne oluşturun.
                            kullanıcıYönEkranı.Show(); // Yeni pencereyi göster
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect pasword or user name!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
