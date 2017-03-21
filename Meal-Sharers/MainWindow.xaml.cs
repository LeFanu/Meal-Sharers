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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Meal_Sharers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SingletonDatabaseAccess dbAccess;
        public MainWindow()
        {
            InitializeComponent();
            ////creating file reader object and using it's method to read the Database and for file operations
            dbAccess = SingletonDatabaseAccess.DBInstance;
            ////reading our database and filling in the data to operate on
            dbAccess.readDB_OnStartup();
        }

        private void btnCook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEater_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow createNewUser = new NewUserWindow();
            this.Close();
            createNewUser.ShowDialog();
    
        }
    }
}
