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

        private int accountToLogIn = 0;

        private void btnCook_Click(object sender, RoutedEventArgs e)
        {
            cmbChooseAccount.Items.Clear();
            cmbChooseAccount.Text = "Select your Cook account from the list.";
            foreach (Cook cook in dbAccess.CooksDB)
            {
                cmbChooseAccount.Items.Add("Name: " + cook.Name + ", PVG: " + cook.ValidPVG + ", Hygiene: " + cook.ValidPVG);
            }
            accountToLogIn = 1;
        }

        private void btnEater_Click(object sender, RoutedEventArgs e)
        {
            cmbChooseAccount.Items.Clear();
            cmbChooseAccount.Text = "Select your Eater account from the list.";
            foreach (Eater eater in dbAccess.EatersDB)
            {
                cmbChooseAccount.Items.Add("Name: " + eater.Name + ", Age: " + eater.Age + ", Hygiene: " + eater.HasDisability);
            }
            accountToLogIn = 2;
        }

        private void btnAdministrator_Click(object sender, RoutedEventArgs e)
        {
            cmbChooseAccount.Items.Clear();
            cmbChooseAccount.Text = "Select your Admnistrator account from the list.";
            foreach (Administrator admin in dbAccess.AdminsDB)
            {
                cmbChooseAccount.Items.Add("Name: " + admin.Name);
            }
            accountToLogIn = 3;
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow createNewUser = new NewUserWindow();
            this.Close();
            createNewUser.ShowDialog();
            accountToLogIn = 0;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            String nameToFind = Regex.Match(cmbChooseAccount.SelectedItem.ToString(), @"Name: ([A-Za-z]+)").Value;
            //String nameToFind = Regex.Match(cmbChooseAccount.SelectedItem.ToString(), @"\bName\W+\s\w+\W+\s\b").Value;
            nameToFind = Regex.Replace(nameToFind, @"Name: ", "");
            //MessageBox.Show("Name to find is " + nameToFind);
            Console.WriteLine("Name to find is " + nameToFind);

            if (accountToLogIn == 1)
            {
                Cook currentCook = new Cook();
                foreach (Cook cook in dbAccess.CooksDB)
                {
                    currentCook = dbAccess.CooksDB.Find(c => c.Name == nameToFind);
                }

                    if (passwordBox.Password == SingletonDatabaseAccess.PasswordForAll)
                    {
                        CookWindow cookWindow = new CookWindow(currentCook);
                        this.Close();
                        cookWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please enter the valid password!");
                    }
            }
            else if (accountToLogIn == 2)
            {
                Eater currentEater = new Eater();
                foreach (Eater eater in dbAccess.EatersDB)
                {
                    currentEater = dbAccess.EatersDB.Find(eat => eat.Name == nameToFind);
                }
                    if (passwordBox.Password == SingletonDatabaseAccess.PasswordForAll)
                    {
                        EaterWindow eaterWindow = new EaterWindow(currentEater);
                        this.Close();
                        eaterWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please enter the valid password!");
                    }
            }
            else if (accountToLogIn == 3)
            {
                Administrator currentAdmin = new Administrator();
                foreach (Administrator admin in dbAccess.AdminsDB)
                {
                    currentAdmin = dbAccess.AdminsDB.Find(a => a.Name == nameToFind);
                }
                    if (passwordBox.Password == SingletonDatabaseAccess.PasswordForAll)
                    {
                        AdminWindow adminWindow = new AdminWindow(currentAdmin);
                        this.Close();
                    adminWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please enter the valid password!");
                    }
            }
            else
            {
                MessageBox.Show("Please select one of the accounts from above to Log In");
            }
        }
    }
}
