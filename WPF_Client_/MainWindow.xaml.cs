using _2024_09_11___Lesson__CRUD_Interface_;
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

namespace WPF_Client_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportShop sportShop = null;
        public MainWindow()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["SportShopDbConnection"]
                .ConnectionString;
            SportShop sportShop = new SportShop(connectionString);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = sportShop.GetALL();
        }
    }
}