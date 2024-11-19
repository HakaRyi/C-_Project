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
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        private IBookingDetailService bookingDetailService;
        private IBookingService bookingService;
        private IUserService userService;
        private RoomSlotService roomSlotService;

        public Room bookingRoom;
        public Booking newBooking;
        public BookingDetail newBookingDetail;
        public BookingWindow()
        {
            InitializeComponent();
            bookingDetailService = new BookingDetailService();
            bookingService = new BookingService();
            userService = new UserService();
            roomSlotService = new RoomSlotService();
        }

        public void Window_loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = new List<Room> { bookingRoom };
            btnBook.IsEnabled = false;
            enableSlot();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            if(cboBookType.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content.ToString() == "DAY")
            {
                DateTime? startDate = dpStartDate.SelectedDate;
                DateTime? endDate = dpEndDate.SelectedDate;

                if (!startDate.HasValue || !endDate.HasValue)
                {
                    MessageBox.Show("Please select both start and end dates.", "Date Required", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (startDate.Value > endDate.Value)
                {
                    MessageBox.Show("Start date must be earlier than end date", "Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                int numberOfDays = (endDate.Value - startDate.Value).Days + 1;
                double total = bookingRoom.Price * 12 * numberOfDays;

                string id = "";
                int number = bookingService.GetBooking().Count+1;
                if (number < 10)
                {
                    id = "Bo-0" + number;
                }
                else
                {
                    id = "Bo-" + number;
                }
                //Create Booking
                Booking booking = new Booking();
                booking.BookingId = id;
                booking.BookingDate = DateOnly.FromDateTime(DateTime.Now);
                booking.Status = "PENDING";
                booking.Total = total;
                booking.User = userService.getLoginAccount();
                bookingService.AddBooking(booking);
                newBooking = booking;

                //Create Booking Detail
                string DetailId = "";
                int detailNumber = bookingDetailService.GetAll().Count+1;
                if (detailNumber < 10)
                {
                    DetailId = "BD-0" + detailNumber;
                }
                else
                {
                    DetailId = "BD-" + detailNumber;
                }

                BookingDetail bookingDetail = new BookingDetail();
                bookingDetail.BookingDetailId = DetailId;
                bookingDetail.Booking = booking;
                bookingDetail.StartTime = DateOnly.FromDateTime(startDate.Value);
                bookingDetail.EndTime = DateOnly.FromDateTime(endDate.Value);
                bookingDetail.Status = "PENDING";
                bookingDetail.TotalPrice = total;
                bookingDetail.Timestamp = DateTime.Now;
                bookingDetail.Room = bookingRoom;

                bookingDetailService.AddBookingDetail(bookingDetail);
                newBookingDetail = bookingDetail;

                //Create Room Slot
                DateTime currentDate = startDate.Value;
                while (currentDate <= endDate.Value)
                {
                    RoomSlot roomSlot = new RoomSlot();
                    roomSlot.BookingDate = DateOnly.FromDateTime(currentDate);
                    roomSlot.SlotId = "DAY";
                    roomSlot.Booking = booking; 
                    roomSlot.Room = bookingRoom;

                    roomSlotService.AddRoomSlot(roomSlot);

                    currentDate = currentDate.AddDays(1);
                }
                if (booking != null && !string.IsNullOrEmpty(booking.BookingId))
                {
                    PaymentWindow paymentWindow = new PaymentWindow();
                    if (paymentWindow != null)
                    {
                        paymentWindow.booking = newBooking;
                        paymentWindow.bookingDetail = newBookingDetail;
                        paymentWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("PaymentWindow could not be initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Booking ID is invalid or booking is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                DateTime? startDate = dpDateSlot.SelectedDate;
                DateTime? endDate = dpDateSlot.SelectedDate;

                if (!startDate.HasValue || !endDate.HasValue)
                {
                    MessageBox.Show("Please select both start and end dates.", "Date Required", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var selectedSlots = lstSlots.SelectedItems;
                int slotCount = selectedSlots.Count;
                double total = bookingRoom.Price * slotCount;

                string id = "";
                int number = bookingService.GetBooking().Count+1;
                if (number < 10)
                {
                    id = "Bo-0" + number;
                }
                else
                {
                    id = "Bo-" + number;
                }
                //Create Booking
                Booking booking = new Booking();
                booking.BookingId = id;
                booking.BookingDate = DateOnly.FromDateTime(DateTime.Now);
                booking.Status = "PENDING";
                booking.Total = total;
                booking.User = userService.getLoginAccount();
                bookingService.AddBooking(booking);
                newBooking= booking;

                //Create Booking Detail
                string DetailId = "";
                int detailNumber = bookingDetailService.GetAll().Count+1;
                if (detailNumber < 10)
                {
                    DetailId = "BD-0" + detailNumber;
                }
                else
                {
                    DetailId = "BD-" + detailNumber;
                }

                BookingDetail bookingDetail = new BookingDetail();
                bookingDetail.BookingDetailId = DetailId;
                bookingDetail.Booking = booking;
                bookingDetail.StartTime = DateOnly.FromDateTime(startDate.Value);
                bookingDetail.EndTime = DateOnly.FromDateTime(endDate.Value);
                bookingDetail.Status = "PENDING";
                bookingDetail.TotalPrice = total;
                bookingDetail.Timestamp = DateTime.Now;
                bookingDetail.Room = bookingRoom;

                bookingDetailService.AddBookingDetail(bookingDetail);
                newBookingDetail = bookingDetail;

                //Create Room Slot
                DateTime currentDate = startDate.Value;
                foreach (ListBoxItem slot in selectedSlots)
                {
                    string slotId = slot.Content.ToString(); 

                    RoomSlot roomSlot = new RoomSlot();
                    roomSlot.BookingDate = DateOnly.FromDateTime(currentDate);
                    roomSlot.SlotId = slotId;
                    roomSlot.Booking = booking;
                    roomSlot.Room = bookingRoom;

                    if (roomSlot.BookingDate == null || roomSlot.SlotId == null || roomSlot.Room == null || roomSlot.Booking == null)
                    {
                        MessageBox.Show("Room slot information is incomplete. Please check and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }


                    roomSlotService.AddRoomSlot(roomSlot);
                }
                enableSlot();
                MessageBox.Show("Booking SuccessFully!!!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);

                if (booking != null && !string.IsNullOrEmpty(booking.BookingId))
                {
                    PaymentWindow paymentWindow = new PaymentWindow();
                    if (paymentWindow != null)
                    {
                        paymentWindow.booking = newBooking;
                        paymentWindow.bookingDetail = newBookingDetail;
                        paymentWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("PaymentWindow could not be initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Booking ID is invalid or booking is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (cboBookType.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content.ToString() == "DAY")
            {
                DateTime? startDate = dpStartDate.SelectedDate;
                DateTime? endDate = dpEndDate.SelectedDate;

                if (!startDate.HasValue || !endDate.HasValue)
                {
                    MessageBox.Show("Please select both start and end dates.", "Date Required", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (startDate.Value > endDate.Value)
                {
                    MessageBox.Show("Start date must be earlier than end date", "Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                int numberOfDays = (endDate.Value - startDate.Value).Days;
                double total = bookingRoom.Price * 12 * (numberOfDays+1);

                lbPrice.Content = total.ToString() + "$";
            }
            else
            {
                var selectedSlots = lstSlots.SelectedItems;
                int slotCount = selectedSlots.Count;
                double total = bookingRoom.Price * slotCount;

                lbPrice.Content = total.ToString();
                
            }
            
            btnBook.IsEnabled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void enableSlot()
        {
            var bookedSlots = roomSlotService.GetRoomBookedSlots(bookingRoom.RoomId);

            foreach (var booked in bookedSlots)
            {
                if (booked.BookingDate.HasValue && booked.SlotId.Equals("DAY"))
                {
                    DateTime bookingDateTime = booked.BookingDate.Value.ToDateTime(TimeOnly.MinValue); 
                    if (!dpStartDate.BlackoutDates.Contains(new CalendarDateRange(bookingDateTime)))
                    {
                        dpStartDate.BlackoutDates.Add(new CalendarDateRange(bookingDateTime));
                    }
                    if (!dpEndDate.BlackoutDates.Contains(new CalendarDateRange(bookingDateTime)))
                    {
                        dpEndDate.BlackoutDates.Add(new CalendarDateRange(bookingDateTime));
                    }
                    if (!dpDateSlot.BlackoutDates.Contains(new CalendarDateRange(bookingDateTime)))
                    {
                        dpDateSlot.BlackoutDates.Add(new CalendarDateRange(bookingDateTime));
                    }
                }
            }
        }

        public void DatePicker_SelectedDateChanged(object sender, EventArgs e)
        {
            var bookedSlots = roomSlotService.GetRoomBookedSlots(bookingRoom.RoomId);

            foreach (ListBoxItem slot in lstSlots.Items)
            {
                slot.IsEnabled = true;
            }

            foreach (ListBoxItem slot in lstSlots.Items)
            {
                foreach (var booked in bookedSlots)
                {
                    DateTime? bookingDateTime = booked.BookingDate?.ToDateTime(TimeOnly.MinValue);
                    if (slot.Content.ToString() == booked.SlotId.ToString() && dpDateSlot.SelectedDate?.Date == bookingDateTime?.Date)
                    {
                        slot.IsEnabled = false;
                        break;
                    }
                }
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
