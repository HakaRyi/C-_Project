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
    /// Interaction logic for RoomManagementWindow.xaml
    /// </summary>
    public partial class RoomManagementWindow : Window
    {
        private readonly IRoomService _roomService;
        private Room _selectedRoom;
        private UserService userService;

        public RoomManagementWindow()
        {
            InitializeComponent();
            _roomService = new RoomService();
            userService = new UserService();
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            var account = userService.getLoginAccount();
            if (account != null)
            {
                if (account.RoleId != "1")
                {
                    btnAdd.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                }
            }
            LoadRooms();
        }

        private void LoadRooms()
        {
            var rooms = _roomService.GetAllRooms();
            dataGridRooms.ItemsSource = rooms;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _roomService.DeleteRoom(_selectedRoom.RoomId);
                LoadRooms();
                ClearInputFields();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom != null)
            {
                _selectedRoom.Availability = txtAvailability.Text;
                _selectedRoom.AvailebleDate = dtpAvailableDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dtpAvailableDate.SelectedDate.Value) : null;
                _selectedRoom.Capacity = int.Parse(txtCapacity.Text);
                _selectedRoom.Description = txtDescription.Text;
                _selectedRoom.Name = txtName.Text;
                _selectedRoom.Price = double.Parse(txtPrice.Text);
                _selectedRoom.BuildingId = txtBuildingId.Text;
                _selectedRoom.TypeId = txtTypeId.Text;

                _roomService.UpdateRoom(_selectedRoom);
                LoadRooms();
                ClearInputFields();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            int numberID = _roomService.GetAllRooms().Count + 1;
            if (numberID < 10)
            {
                id = "R-0" + numberID;
            }
            else
            {
                id = "R-" + numberID;
            }
            var newRoom = new Room
            {
                RoomId = id,
                Availability = txtAvailability.Text,
                AvailebleDate = dtpAvailableDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dtpAvailableDate.SelectedDate.Value) : null,
                Capacity = int.Parse(txtCapacity.Text),
                Description = txtDescription.Text,
                Name = txtName.Text,
                Price = double.Parse(txtPrice.Text),
                BuildingId = txtBuildingId.Text,
                TypeId = txtTypeId.Text
            };

            _roomService.AddRoom(newRoom);
            LoadRooms();
            ClearInputFields();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedRoom = dataGridRooms.SelectedItem as Room;
            if (_selectedRoom != null)
            {
                txtRoomID.Text = _selectedRoom.RoomId;
                txtAvailability.Text = _selectedRoom.Availability;
                dtpAvailableDate.SelectedDate = _selectedRoom.AvailebleDate?.ToDateTime(TimeOnly.MinValue);
                txtCapacity.Text = _selectedRoom.Capacity.ToString();
                txtDescription.Text = _selectedRoom.Description;
                txtName.Text = _selectedRoom.Name;
                txtPrice.Text = _selectedRoom.Price.ToString();
                txtBuildingId.Text = _selectedRoom.BuildingId;
                txtTypeId.Text = _selectedRoom.TypeId;
            }
            txtRoomID.IsEnabled = false;
        }

        private void ClearInputFields()
        {
            txtRoomID.Clear();
            txtAvailability.Clear();
            dtpAvailableDate.SelectedDate = null;
            txtCapacity.Clear();
            txtDescription.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtBuildingId.Clear();
            txtTypeId.Clear();
            _selectedRoom = null;
        }


        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = dataGridRooms.SelectedItem as Room;
            if (selectedRoom != null)
            {
                BookingWindow bookingWindow = new BookingWindow();
                bookingWindow.bookingRoom = selectedRoom;
                bookingWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a room before proceeding.");
            }
        }
    }
}
