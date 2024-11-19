using BusinessObjects;
using Services;
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

namespace POD_Booking_PRN_Wpf
{
    /// <summary>
    /// Interaction logic for ManageBuildingWindow.xaml
    /// </summary>
    public partial class ManageBuildingWindow : Window
    {
        private readonly IBuildingService _buildingService;
        private Building _selectedBuilding;
        public ManageBuildingWindow()
        {
            InitializeComponent();
            _buildingService = new BuildingService();
        }
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            LoadBuildings();
        }

        private void LoadBuildings()
        {
            var buildings = _buildingService.GetAllBuildings();
            dataGridBuildings.ItemsSource = buildings;
        }
        private void dataGridBuildings_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedBuilding = dataGridBuildings.SelectedItem as Building;
            if (_selectedBuilding != null)
            {
                txtBuildingID.Text = _selectedBuilding.BuildingId;
                txtName.Text = _selectedBuilding.Name;
                txtAddress.Text = _selectedBuilding.Address;
                txtLocation.Text = _selectedBuilding.Location;
                txtDescription.Text = _selectedBuilding.Description;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            int numberID = _buildingService.GetAllBuildings().Count + 1;
            if (numberID < 10)
            {
                id = "B-0" + numberID;
            }
            else
            {
                id = "B-" + numberID;
            }
            var newBuilding = new Building
            {
                BuildingId = id,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Location = txtLocation.Text,
                Description = txtDescription.Text
            };

            _buildingService.AddBuilding(newBuilding);
            LoadBuildings();
            ClearInputFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBuilding != null)
            {
                _selectedBuilding.Name = txtName.Text;
                _selectedBuilding.Address = txtAddress.Text;
                _selectedBuilding.Location = txtLocation.Text;
                _selectedBuilding.Description = txtDescription.Text;

                _buildingService.UpdateBuilding(_selectedBuilding);
                LoadBuildings();
                ClearInputFields();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBuilding != null)
            {
                _buildingService.DeleteBuilding(_selectedBuilding.BuildingId);
                LoadBuildings();
                ClearInputFields();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearInputFields()
        {
            txtBuildingID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtLocation.Clear();
            txtDescription.Clear();
            _selectedBuilding = null;
        }
    }
}
