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

            if (this.currentCook.ValidPVG && this.currentCook.ValidHygieneCertificate)
            {
                lstCurrentStatus.Items.Add("Approved!");
                
            }
            else
            {
                String missing = "";
                if (!this.currentCook.ValidHygieneCertificate)
                {
                    missing += "Hygiene Certificate is Missing! ";
                }
                if (!this.currentCook.ValidPVG)
                {
                    missing += "\nPVG is Missing!";
                }
                lstCurrentStatus.Items.Add(missing);
            }
            lstCurrentStatus.Items.Add("\n");
            lstCurrentStatus.Items.Add("\n");
            lstCurrentStatus.Items.Add("\n" + currentCook.Name);


            
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            listAvailableEaters.Items.Clear();
            List<Eater> results = null;
            results = dbAccess.eatersSearch("");
            foreach (Eater eater in results)
            {
                listAvailableEaters.Items.Add("Name: " + eater.Name + ", Age: " + eater.Age + ", City: " + eater.City);
            }
        }

        private void listAvailableEaters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
    }


}
