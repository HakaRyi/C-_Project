using BusinessObjects;
using Repositories;
using Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POD_Booking_PRN_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService userService;
        public User CurrentAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            var context = new PodBookingSystemContext();
            var userRepository = new UserRepository();
            userService = new UserService();
        }
        public void Window_loaded(object sender, RoutedEventArgs e)
        {
            var account = userService.getLoginAccount();
            if (account != null)
            {
                if (account.RoleId != "1")
                {
                    btnBuilding.IsEnabled = false;
                    btnRoom.IsEnabled = false;
                    btnUser.IsEnabled = false;
                }
            }
        }

        private void btnBuilding_Click(object sender, RoutedEventArgs e)
        {
            ManageBuildingWindow buildingWindow = new ManageBuildingWindow();
            buildingWindow.Show();
            
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomManagementWindow roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.Show();
           
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUserWindow manageUserWindow = new ManageUserWindow();
            manageUserWindow.Show();
           
        }

        private void btnBookNow_Click(object sender, RoutedEventArgs e)
        {
            RoomManagementWindow roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.Show();
            
        }
    }
}