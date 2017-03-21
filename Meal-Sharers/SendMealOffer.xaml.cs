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
    /// Interaction logic for SendMealOffer.xaml
    /// </summary>
    public partial class SendMealOffer : Window
    {
        Cook currentCook;
        Eater currentEater;
        SingletonDatabaseAccess dbAccess;
        CookWindow cookWindow;

        Meal currentMealOffer = new Meal();


        bool messageSent = false;

        public SendMealOffer()
        {
            InitializeComponent();
        }

        public SendMealOffer(Cook cook, Eater eater)
        {
            
            InitializeComponent();
            this.currentCook = cook;
            this.currentEater = eater;
            //filling in the combobox with available times
            for (int i = 12; i < 20; i++)
            {
                cmbSetTime.Items.Add(i + ":00");
                cmbSetTime.Items.Add(i + ":30");
            }

            this.lblCookName.Content = currentCook.Name;
            this.lblEaterName.Content = currentEater.Name;
            this.lblEaterCity.Content = currentEater.City;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cookWindow = (CookWindow)this.Owner;
            cookWindow.btnSearch_Click(sender, e);
            this.Close();
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            currentMealOffer.MessageToEater = txtMessageToEater.Text;
            currentMealOffer.HasMessage = true;
            txtMessageToEater.Text = "";
            MessageBox.Show("Message was sent.");
            messageSent = true;
        }

        private void btnSendOffer_Click(object sender, RoutedEventArgs e)
        {
            if (!messageSent)
            {
                btnSendMessage_Click(sender, e);
            }

            currentMealOffer.CookParticipant = currentCook;
            currentMealOffer.EaterParticipant = currentEater;
        }
    }
}
