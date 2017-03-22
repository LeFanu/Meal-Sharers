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
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        SingletonDatabaseAccess dbAccess;
        Cook cookAccount;
        Eater eaterAccount;
        Administrator adminAccount;

        public NewUserWindow()
        {
            InitializeComponent();
            createAdmin.Visibility = Visibility.Hidden;
            createCook.Visibility = Visibility.Hidden;
            createEater.Visibility = Visibility.Hidden;
            ////creating file reader object and using it's method to read the Database and for file operations
            dbAccess = SingletonDatabaseAccess.DBInstance;
        }


        private void cmbChooseAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbChooseAccount.SelectedIndex == 0)
            {
                createAdmin.Visibility = Visibility.Hidden;
                createCook.Visibility = Visibility.Visible;
                createEater.Visibility = Visibility.Hidden;  
            }
            else if (cmbChooseAccount.SelectedIndex == 1)
            {
                createAdmin.Visibility = Visibility.Hidden;
                createCook.Visibility = Visibility.Hidden;
                createEater.Visibility = Visibility.Visible;
            }
            else
            {
                createAdmin.Visibility = Visibility.Visible;
                createCook.Visibility = Visibility.Hidden;
                createEater.Visibility = Visibility.Hidden;
            }
        }

        private void btnSubmit_Cook_Click(object sender, RoutedEventArgs e)
        {
            cookAccount = new Cook();
            cookAccount.Name = txtCookName.Text;
            cookAccount.PhoneNumber = txtCookPhone.Text;
            if (cmbChoosePVG.SelectedIndex == 0)
            {
                cookAccount.ValidPVG = Cook.pvg_hygiene_statuses.OK;
            }
            else if (cmbChoosePVG.SelectedIndex == 1)
            {
                cookAccount.ValidPVG = Cook.pvg_hygiene_statuses.Rejected;
            }
            else
            {
                cookAccount.ValidPVG = Cook.pvg_hygiene_statuses.AwaitingResults;
                MessageBox.Show("In order to be able to share the meals you need to have valid PVG Certificate");
            }
            if (cmbChooseHygieneCertificate.SelectedIndex == 0)
            {
                cookAccount.ValidHygieneCertificate = Cook.pvg_hygiene_statuses.OK;
            }
            else
            {
                cookAccount.ValidHygieneCertificate = Cook.pvg_hygiene_statuses.None;
                MessageBox.Show("In order to be able to share the meals you need to have valid Hygiene Certificate and renew that when it is needed.");
            }
            cookAccount.City = txtCityCook.Text;
            if (cookAccount.ValidPVG == Cook.pvg_hygiene_statuses.OK && (cookAccount.ValidHygieneCertificate == Cook.pvg_hygiene_statuses.OK || cookAccount.ValidHygieneCertificate == Cook.pvg_hygiene_statuses.RenevalWith3months))
            {
                cookAccount.ActiveSince = DateTime.Today.Date;
                Console.WriteLine("Today is " + cookAccount.ActiveSince.Date);
            }
            dbAccess.CooksDB.Add(cookAccount);
            savingAccountAndClosingWindow(e);
            
        }

        private void btnSubmit_Eater_Click(object sender, RoutedEventArgs e)
        {
            eaterAccount = new Eater();
            eaterAccount.Name = txtEaterName.Text;
            eaterAccount.PhoneNumber = txtEaterPhone.Text;
            eaterAccount.Age = Int32.Parse(txtEaterAge.Text);
            if (cmbChooseDisability.SelectedIndex  == 0)
            {
                eaterAccount.HasDisability = true; 
            }
            eaterAccount.City = txtCityEater.Text;
            eaterAccount.MealPreferences = txtMealPreferencesEater.Text;
            dbAccess.EatersDB.Add(eaterAccount);
            savingAccountAndClosingWindow(e);
        }

        private void btnSubmit_Admin_Click(object sender, RoutedEventArgs e)
        {
            adminAccount = new Administrator();
            adminAccount.Name = txtAdminName.Text;
            dbAccess.AdminsDB.Add(adminAccount);
            savingAccountAndClosingWindow(e);
        }


        //this method closes the window and comes back to the main one
        private void cancelAccountCreation(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }


        //this method saves the DB and call the method above
        private void savingAccountAndClosingWindow(RoutedEventArgs e)
        {
            dbAccess.saveFiles();
            //closing this window
            cancelAccountCreation(this, e);
        }
    }
}
