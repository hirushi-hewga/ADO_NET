using _2024_09_13___Sales;
using System.Configuration;
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

namespace _2024_09_13___WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalesDb salesDb = null;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager
                .ConnectionStrings["SportShopDbConnection"]
                .ConnectionString;
            salesDb = new SalesDb(connectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = salesDb.GetALLBuyers();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = salesDb.GetALLSellers();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = salesDb.GetALLSales();
        }
    }
}