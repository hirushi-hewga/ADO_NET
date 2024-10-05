using _2024_09_11___Lesson__CRUD_Interface_;
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

namespace Wpf_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string connectionString = @"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                        Initial Catalog=SportShop;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            SportShop sportShop = new SportShop(connectionString);
            InitializeComponent();
        }
    }
}