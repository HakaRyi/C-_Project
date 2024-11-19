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
    /// Interaction logic for ManageUserWindow.xaml
    /// </summary>
    public partial class ManageUserWindow : Window
    {
        private readonly IUserService _userService;
        

        private List<User> _users;

        public ManageUserWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUserData();
        }

        private void LoadUserData()
        {
            _users = _userService.GetAllUsers();
            dataGridUsers.ItemsSource = _users;
        }

        private void dataGridUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridUsers.SelectedItem is User selectedUser)
            {
                txtUserId.Text = selectedUser.UseridId;
                txtUserEmail.Text = selectedUser.Email;
                txtUserName.Text = selectedUser.Name;
                txtUserPhone.Text = selectedUser.Phone;
                txtUsername.Text = selectedUser.Username;
                txtRoleId.Text = selectedUser.RoleId;
                txtPassword.Text = selectedUser.Password;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem is User selectedUser)
            {
                selectedUser.Email = txtUserEmail.Text;
                selectedUser.Name = txtUserName.Text;
                selectedUser.Phone = txtUserPhone.Text;
                selectedUser.Username = txtUsername.Text;
                selectedUser.RoleId = txtRoleId.Text;
                selectedUser.Password = txtPassword.Text;

                _userService.UpdateUser(selectedUser);
                LoadUserData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedItem is User selectedUser)
            {
                _userService.DeleteUser(selectedUser.UseridId);
                LoadUserData();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                UseridId = txtUserId.Text,
                Email = txtUserEmail.Text,
                Name = txtUserName.Text,
                Phone = txtUserPhone.Text,
                Username = txtUsername.Text,
                RoleId = txtRoleId.Text,
                Password = txtPassword.Text
            };

            _userService.AddUser(newUser);
            LoadUserData();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRoomManangement_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
