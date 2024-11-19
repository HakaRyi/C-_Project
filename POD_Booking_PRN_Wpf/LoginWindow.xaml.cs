using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        private readonly IRoomService roomService;

        public LoginWindow()
        {
            InitializeComponent();
            var context = new PodBookingSystemContext(); // Tạo context
            var userRepository = new UserRepository(); // Truyền context vào repository
            userService = new UserService();

            // Đọc thông tin từ appsettings.json
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User account = userService.Authenticate(EmailTextBox.Text, PasswordBox.Password);
            if (EmailTextBox.Text.IsNullOrEmpty() ||
              PasswordBox.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Both email and pass required", "Wrong credential", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (account == null)
            {
                MessageBox.Show("Invalid email or pass", "Wrong credential", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (account.RoleId == "Staff")
            {
                MessageBox.Show("You have no permission", "Wrong credential", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MainWindow m = new();
            m.CurrentAccount = account; //day account
            m.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
