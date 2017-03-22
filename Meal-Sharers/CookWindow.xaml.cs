using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CookWindow.xaml
    /// </summary>
    public partial class CookWindow : Window
    {
        Cook currentCook;
        SingletonDatabaseAccess dbAccess;
        Eater selectedEater;

        public CookWindow()
        {
            InitializeComponent();
        }

        public CookWindow(Cook cook)
        {
            InitializeComponent();
            this.currentCook = cook;
            dbAccess = SingletonDatabaseAccess.DBInstance;

            lblCookActiveSince.Content = currentCook.ActiveSince.ToShortDateString();
            lblCookName.Content = currentCook.Name;
            lblCookCity.Content = currentCook.City;

            if (currentCook.ValidPVG == Cook.pvg_hygiene_statuses.OK)
            {
                lblPVGstatusOK.Visibility = Visibility.Visible;
                readMeals();

            }
            else if (currentCook.ValidPVG == Cook.pvg_hygiene_statuses.AwaitingResults)
            {
                lblPVGstatusAwaiting.Visibility = Visibility.Visible;
                disableButtons();
            }
            else
            {
                lblPVGstatusBAD.Visibility = Visibility.Visible;
                disableButtons();
                
            }

            if (currentCook.ValidHygieneCertificate == Cook.pvg_hygiene_statuses.OK)
            {
                lblHygieneStatusOK.Visibility = Visibility.Visible;
                readMeals();

            }
            else if (currentCook.ValidHygieneCertificate == Cook.pvg_hygiene_statuses.RenevalWith3months)
            {
                lblHygieneStatusRenew.Visibility = Visibility.Visible;
                lblHygieneTitle.Visibility = Visibility.Visible;
                lblCookRenewalDate.Visibility = Visibility.Visible;
                lblCookRenewalDate.Content = currentCook.HygieneRenevalDate.ToShortDateString();
                readMeals();
            }
            else
            {
                lblHygieneStatusBAD.Visibility = Visibility.Visible;
                lblHygieneTitle.Visibility = Visibility.Visible;
                lblHygieneOverdue.Visibility = Visibility.Visible;
                disableButtons();
            }



            
            
        }

        private void disableButtons()
        {
            btnCompletedMeal.IsEnabled = false;
            btnSendOffer.IsEnabled = false;
            btnSearch.IsEnabled = false;
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            listAvailableEaters.Items.Clear();
            List<Eater> results = null;
            results = dbAccess.eatersSearch("");
            foreach (Eater eater in results)
            {
                listAvailableEaters.Items.Add("Name: " + eater.Name + ", Age: " + eater.Age + ", City: " + eater.City + ", Meal preferences: " + eater.MealPreferences);
            }
        }

        private void listAvailableEaters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnSendOffer_Click(sender, e);
        }

        private void sendMealOfferWindowOpen()
        {
            String nameToFind = Regex.Match(listAvailableEaters.SelectedItem.ToString(), @"Name: ([A-Za-z]+)").Value;
            //String nameToFind = Regex.Match(cmbChooseAccount.SelectedItem.ToString(), @"\bName\W+\s\w+\W+\s\b").Value;
            nameToFind = Regex.Replace(nameToFind, @"Name: ", "");
            Console.WriteLine("Name to find is " + nameToFind);
            selectedEater = new Eater();

            foreach (Eater cook in dbAccess.EatersDB)
            {
                selectedEater = dbAccess.EatersDB.Find(c => c.Name == nameToFind);
            }
                SendMealOffer sendMealOfferWindow = new SendMealOffer(currentCook, selectedEater);
                sendMealOfferWindow.Owner = this;
                sendMealOfferWindow.ShowDialog();
            
        }

        public void readMeals()
        {

            if (currentCook.Meals != null)
            {
                listUpcomingMeals.Items.Clear();
                foreach (Meal meal in currentCook.Meals)
                {
                    listUpcomingMeals.Items.Add("" + meal.EaterParticipant.Name + ", " + meal.EaterParticipant.Age + ", " + meal.EaterParticipant.City + ", "
                        + meal.Date.ToShortDateString() + ", " + meal.Time);
                }
            }
        }

        private void btnSendOffer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sendMealOfferWindowOpen();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select an Eater.");
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void btnCompletedMeal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                completeMealWindowOpen();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a Meal from the list.");
            }
        }

        private void listUpcomingMeals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnCompletedMeal_Click(sender, e);
        }

        private void completeMealWindowOpen()
        {
            String nameToFind = Regex.Match(listUpcomingMeals.SelectedItem.ToString(), @"^([A-Za-z]+)").Value;
            //String nameToFind = Regex.Match(cmbChooseAccount.SelectedItem.ToString(), @"\bName\W+\s\w+\W+\s\b").Value;
            //nameToFind = Regex.Replace(nameToFind, @"Name: ", "");
            Console.WriteLine("Name to find is======" + nameToFind);
            selectedEater = new Eater();

            foreach (Eater cook in dbAccess.EatersDB)
            {
                selectedEater = dbAccess.EatersDB.Find(c => c.Name == nameToFind);
            }
            CompleteMeal completeMealWindow = new CompleteMeal(currentCook, selectedEater);
            completeMealWindow.Owner = this;
            completeMealWindow.ShowDialog();

        }
    }

    


}
