using System.Windows;

namespace RentACarApp
{
    public partial class ProfileSection : Window
    {
        public ProfileSection()
        {
            InitializeComponent(); // This connects to the XAML file
        }

        // Event handler for "View All Cars" button
        private void ViewAllCars_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("View All Cars button clicked!");
        }

        // Event handler for "Add Car" button
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Car button clicked!");
        }

        // Event handler for "Car Düzenleme" button
        private void CarDüzenleme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Car Düzenleme button clicked!");
        }
    }
}

