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
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace flamingoCarList
{
    /// <summary>
    /// Interaction logic for carListWindow.xaml
    /// </summary>
    public partial class carListWindow : Window
    {
        SqlConnection sqlConnection;
        public carListWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["flamingoCarList.Properties.Settings.flamingoRentConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            FillCarListBox();
        }

        public class Car
        {
            public string CarImage { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public decimal Price { get; set; }
            public string NumPlate {  get; set; }
        }

        private void FillCarListBox()
        {
            List<Car> cars = new List<Car>();
            string query = "SELECT CAR_IMAGE, BRAND, MODEL, YEAR, RENT_PRICE, NUMBER_PLATE FROM CAR";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car
                    {
                        CarImage = reader["CAR_IMAGE"] != DBNull.Value
                        ? Convert.ToBase64String((byte[])reader["CAR_IMAGE"]) 
                        : null,  
                        Brand = reader["BRAND"].ToString(),
                        Model = reader["MODEL"].ToString(),
                        Year = Convert.ToInt32(reader["YEAR"]),
                        Price = Convert.ToDecimal(reader["RENT_PRICE"]),
                        NumPlate = reader["NUMBER_PLATE"].ToString()
                    };

                    cars.Add(car);
                }
            }
            catch(Exception e) { 
                MessageBox.Show(e.Message);
            }
            finally { sqlConnection.Close(); }
            CarListBox.ItemsSource = cars;
        }


        private void ClickableImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCar = CarListBox.SelectedItem as Car;
            if (selectedCar != null)
            {
                string numberPlate = selectedCar.NumPlate;
                MessageBox.Show($"Selected Car Number Plate: {numberPlate}");
                CarListBox.SelectedItem = null;
            }
        }
    }
}
