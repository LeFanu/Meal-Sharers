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

namespace Meal_Sharers
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        Administrator currentAdministrator;
        SingletonDatabaseAccess dbAccess;
        

        public AdminWindow(Administrator admin)
        {
            InitializeComponent();
            currentAdministrator = admin;
            dbAccess = SingletonDatabaseAccess.DBInstance;

            foreach (Cook cook in dbAccess.CooksDB)
            {
                lstAvailableCooks.Items.Add("Name: " + cook.Name + ", Valid PVG: " + cook.ValidHygieneCertificate + ", Valid Hygiene Certificate: " + cook.ValidHygieneCertificate);
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
