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
    /// Interaction logic for CompleteMeal.xaml
    /// </summary>
    public partial class CompleteMeal : Window
    {
        Cook currentCook;
        Eater currentEater;
        SingletonDatabaseAccess dbAccess;
        CookWindow cookWindow;
        Meal currentMealOffer;

        public CompleteMeal(Cook cook, Eater eater)
        {
            InitializeComponent();
            dbAccess = SingletonDatabaseAccess.DBInstance;
            this.currentCook = cook;
            this.currentEater = eater;
            this.lblCookName.Content = currentCook.Name;
            this.lblEaterName.Content = currentEater.Name;
            this.lblEaterCity.Content = currentEater.City;
            


        }





        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cookWindow = (CookWindow)this.Owner;
            cookWindow.btnSearch_Click(sender, e);
            cookWindow.readMeals();
            this.Close();
        }

        private void btnCompleteMeal_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Thank you for your submission.");
            btnCancel_Click(sender, e);
        }
    }
}
