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
        Cook newCookAccount;
        Eater newEaterAccount;
        Administrator newAdminAccount;

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
            newCookAccount = new Cook();
            newCookAccount.Name = txtCookName.Text;
            newCookAccount.PhoneNumber = txtCookPhone.Text;
            if (cmbChoosePVG.SelectedIndex == 0)
            {
                newCookAccount.ValidPVG = true;
            }
            if (cmbChooseHygieneCertificate.SelectedIndex == 0)
            {
                newCookAccount.ValidHygieneCertificate = true;
            }
            newCookAccount.City = txtCityCook.Text;
            dbAccess.CooksDB.Add(newCookAccount);
            savingAccountAndClosingWindow(e);
            
        }

        private void btnSubmit_Eater_Click(object sender, RoutedEventArgs e)
        {
            newEaterAccount = new Eater();
            newEaterAccount.Name = txtEaterName.Text;
            newEaterAccount.PhoneNumber = txtEaterPhone.Text;
            newEaterAccount.Age = Int32.Parse(txtEaterAge.Text);
            if (cmbChooseDisability.SelectedIndex  == 0)
            {
                newEaterAccount.HasDisability = true; 
            }
            newEaterAccount.City = txtCityEater.Text;
            dbAccess.EatersDB.Add(newEaterAccount);
            savingAccountAndClosingWindow(e);
        }

        private void btnSubmit_Admin_Click(object sender, RoutedEventArgs e)
        {
            newAdminAccount = new Administrator();
            newAdminAccount.Name = txtAdminName.Text;
            dbAccess.AdminsDB.Add(newAdminAccount);
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
