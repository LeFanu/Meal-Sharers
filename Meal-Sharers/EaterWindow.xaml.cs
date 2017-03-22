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
    /// Interaction logic for EaterWindow.xaml
    /// </summary>
    public partial class EaterWindow : Window
    {
        Eater currentEater;

        public EaterWindow()
        {
            InitializeComponent();
            
        }

        public EaterWindow(Eater eater)
        {
            InitializeComponent();
            currentEater = eater;
            Console.WriteLine("Meal offers = " + Eater.MealOffers);
            if (Eater.MealOffers > 0)
            {
                var response =   MessageBox.Show("One of the cooks has sent you an offer", "Awaiting Meal Offer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (response == MessageBoxResult.Yes)
                {
                    Eater.MealOffers--;
                    Console.WriteLine("Meal offers after = " + Eater.MealOffers);
                }
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
