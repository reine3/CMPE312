using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Cmpe312TermProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddItems();
            // Marka ComboBox'ını doldur
            foreach (var brand in carData.Keys)
            {
                brandBox.Items.Add(brand);
            }
            IsAllBoxChoosen();
        }

        private Dictionary<string, List<string>> carData = new Dictionary<string, List<string>>()
        {
            { "Toyota", new List<string> { "Corolla", "Camry", "Yaris" } },
            { "Ford", new List<string> { "Focus", "Fiesta", "Mustang" } },
            { "BMW", new List<string> { "3 Series", "5 Series", "X5" } },
            { "Mercedes-Benz", new List<string> { "C-Class", "E-Class", "GLA" } },
            { "Honda", new List<string> { "Civic", "Accord", "CR-V" } },
            { "Nissan", new List<string> { "Altima", "Rogue", "GT-R" } },
            { "Hyundai", new List<string> { "Elantra", "Tucson", "Santa Fe" } },
            { "Kia", new List<string> { "Rio", "Sportage", "Sorento" } },
            { "Volkswagen", new List<string> { "Golf", "Passat", "Tiguan" } },
            { "Chevrolet", new List<string> { "Cruze", "Malibu", "Tahoe" } },
            { "Tesla", new List<string> { "Model S", "Model 3", "Model X" } },
            { "Mazda", new List<string> { "Mazda3", "Mazda6", "CX-5" } },
            { "Subaru", new List<string> { "Impreza", "Outback", "Forester" } },
            { "Lexus", new List<string> { "RX", "NX", "ES" } },
            { "Ferrari", new List<string> { "488", "Portofino", "SF90" } },
            { "Lamborghini", new List<string> { "Huracán", "Aventador", "Urus" } },
            { "Volvo", new List<string> { "XC40", "XC60", "S90" } },
            { "Audi", new List<string> { "A3", "A4", "Q5" } },
            { "Porsche", new List<string> { "911", "Cayenne", "Panamera" } },
            { "Jeep", new List<string> { "Wrangler", "Cherokee", "Grand Cherokee" } }
        };

        public void IsAllBoxChoosen()
        {
            // ComboBox'lardan seçim yapılıp yapılmadığını ve TextBox'ların boş olup olmadığını kontrol et
            if (brandBox.SelectedIndex == -1 || modelBox.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(yearBox.Text) || string.IsNullOrWhiteSpace(kmBox.Text) ||
                string.IsNullOrWhiteSpace(numberPlateBox.Text) || locationBox.SelectedIndex == -1 ||
                fuelTypeBox.SelectedIndex == -1 || gearTypeBox.SelectedIndex == -1 ||
                colorBox.SelectedIndex == -1 || seatingBox.SelectedIndex == -1 ||
                vehicleTypeBox.SelectedIndex == -1 || vehicleConditionBox.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(priceBox.Text))

            {
                label2.Content = "Lütfen tüm ComboBox'ları ve TextBox'ları doldurun!";
                button3.Visibility = Visibility.Hidden;
            }
            else
            {
                label2.Content = string.Empty;
                button3.Visibility = Visibility.Visible;
            }
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelBox.Items.Clear();

            if (brandBox.SelectedItem != null)
            {
                string selectedBrand = brandBox.SelectedItem.ToString();

                if (carData.ContainsKey(selectedBrand))
                {
                    foreach (var model in carData[selectedBrand])
                    {
                        modelBox.Items.Add(model);
                    }
                }
            }
            IsAllBoxChoosen();
        }

        private void addPictureButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Bir resim seçin",
                Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath));
                uploadImage.Source = bitmap;
            }
        }
        private void AddItems()
        {
            fuelTypeBox.Items.Add("Petrol");
            fuelTypeBox.Items.Add("Diesel");
            fuelTypeBox.Items.Add("Electric");
            fuelTypeBox.Items.Add("Hybrid");

            gearTypeBox.Items.Add("Manual Transmission");
            gearTypeBox.Items.Add("Automatic Transmission");
            gearTypeBox.Items.Add("Continuously Variable Transmission");
            gearTypeBox.Items.Add("Dual-Clutch Transmission");
            gearTypeBox.Items.Add("Automated Manual Transmission");
            gearTypeBox.Items.Add("Tiptronic Transmission");

            colorBox.Items.Add("White");
            colorBox.Items.Add("Black");
            colorBox.Items.Add("Gray/Metallic Gray");
            colorBox.Items.Add("Red");
            colorBox.Items.Add("Blue");
            colorBox.Items.Add("Green");
            colorBox.Items.Add("Yellow/Gold");

            seatingBox.Items.Add("2");
            seatingBox.Items.Add("4");
            seatingBox.Items.Add("5");
            seatingBox.Items.Add("7");
            seatingBox.Items.Add("8");
            seatingBox.Items.Add("9+");

            vehicleTypeBox.Items.Add("Sedan");
            vehicleTypeBox.Items.Add("Hatchback");
            vehicleTypeBox.Items.Add("Coupe");
            vehicleTypeBox.Items.Add("Convertible");
            vehicleTypeBox.Items.Add("SUV");
            vehicleTypeBox.Items.Add("Crossover");
            vehicleTypeBox.Items.Add("Minivan");
            vehicleTypeBox.Items.Add("Pickup Truck");
            vehicleTypeBox.Items.Add("Electric Vehicle");
            vehicleTypeBox.Items.Add("Hybrid Vehicle");

            vehicleConditionBox.Items.Add("Brand New");
            vehicleConditionBox.Items.Add("Pre-owned");
            vehicleConditionBox.Items.Add("Total Loss");
            vehicleConditionBox.Items.Add("Good");
            vehicleConditionBox.Items.Add("Fair");
            vehicleConditionBox.Items.Add("Poor");

            locationBox.Items.Add("Ankara");
            locationBox.Items.Add("İstanbul");
            locationBox.Items.Add("İzmir");
            locationBox.Items.Add("Antalya");
            locationBox.Items.Add("Balıkesir");

        }

        private void fuelTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void locationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void yearBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void kmBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void gearTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void colorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void seatingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void numberPlateBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void vehicleTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void vehicleConditionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void priceBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsAllBoxChoosen();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow. contact = new MainWindow.Contact();
            ////If you use: using static WPFCaseStudy.MainWindow; above
            ////you can define object like that: Contact contact=new Contact();

            //contact.Name = tb_name.Text;
            //contact.Phone = tb_phone.Text;
            //contact.Email = tb_email.Text;
            //contact.Birthdate = bday_picker.SelectedDate.Value;
            //main.contacts.Add(contact);//add new contact to contacts list in main
            //MessageBox.Show("New contact added");

        }
    }   
}