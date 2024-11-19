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
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        //private string bookingId; //biến lưu BookingId
        private BankService bankService;
        private BankAccountService bankAccountService;
        private IPaymentService paymentService;
        private IPaymentDetailService paymentDetailService;
        private IBookingService bookingService;
        private IBookingDetailService bookingDetailService;
        public  Booking booking;
        public BookingDetail bookingDetail;
        //public PaymentWindow()
        //{

        //}
        public PaymentWindow()
        {
            try
            {
                InitializeComponent();
                
                bankService = new BankService();
                bankAccountService = new BankAccountService();
                paymentService = new PaymentService();
                paymentDetailService = new PaymentDetailService();
                bookingService = new BookingService();
                bookingDetailService=new BookingDetailService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing PaymentWindow: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void FillComboBox()
        {

            cbBank.ItemsSource = bankService.GetBanks();
            //hiển thị column nào
            cbBank.DisplayMemberPath = "BankName";

            cbBank.SelectedValuePath = "BankID";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int bankID = int.Parse(cbBank.SelectedValue.ToString());
            string number = txtNumber.Text;
            string name = txtNameOfBank.Text;
            string releaseDate = txtReleaseDate.Text;

           


            bool isValid = bankAccountService.ValidateBankAccount(bankID, number, name, releaseDate);
            if (isValid)
            {
                // Booking booking = bookingService.GetBookingById(bookingId);
                double totalAmount = booking.Total;

                string id = "";
                int numberID = paymentService.GetPayments().Count + 1;
                if (numberID < 10)
                {
                    id = "P-0" + numberID;
                }
                else
                {
                    id = "P-" + numberID;
                }

                //CREATE PAYMENT
                Payment payment = new Payment();
                payment.PaymentId = id;
                payment.TotalAmount = totalAmount;
                payment.Booking = booking;
                paymentService.AddPayment(payment);


                string DetailId = "";
                int detailNumber = paymentDetailService.GetPaymentDetails().Count + 1;
                if (detailNumber < 10)
                {
                    DetailId = "PD-0" + detailNumber;
                }
                else
                {
                    DetailId = "PD-" + detailNumber;
                }
                //CREATE PAYMENT DETAIL
                double totalPrice = bookingDetail.TotalPrice;
                PaymentDetail paymentDetail = new PaymentDetail();
                paymentDetail.PaymentDetailId = DetailId;
                paymentDetail.Room = bookingDetail.Room;
                paymentDetail.PaymentMethod = "E-Wallet";
                paymentDetail.PaymentStatus = "Success";
                paymentDetail.Payment = payment;
                paymentDetail.PaymentDate = DateTime.Now;
                paymentDetail.Price = totalPrice;
                paymentDetailService.AddPaymentDetail(paymentDetail);
                //UPDATE STATUS
                booking.Status = "CONFIRM";
                bookingDetail.Status = "CONFIRM";
                bookingDetailService.UpdateBookingDetail(bookingDetail);
                bookingService.UpdateBooking(booking);

                SuccessWindow s = new SuccessWindow();
                s.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Validation failed. Please check your input.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            PriceValue.Content=booking.Total+"$";
        }
    }
}
