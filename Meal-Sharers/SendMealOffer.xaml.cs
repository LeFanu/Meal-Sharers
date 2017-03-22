using Microsoft.Win32;
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

        Meal currentMealOffer;


        //bool mealPhotoUploaded = false;

        public SendMealOffer()
        {
            InitializeComponent();
            dbAccess = SingletonDatabaseAccess.DBInstance;
        }

        public SendMealOffer(Cook cook, Eater eater)
        {
            
            InitializeComponent();
            dbAccess = SingletonDatabaseAccess.DBInstance;
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
            currentMealOffer = new Meal();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cookWindow = (CookWindow)this.Owner;
            cookWindow.btnSearch_Click(sender, e);
            cookWindow.readMeals();
            this.Close();
        }




        private void btnSendOffer_Click(object sender, RoutedEventArgs e)
        {
                
            currentMealOffer.CookParticipant = currentCook;
            currentMealOffer.EaterParticipant = currentEater;
            currentMealOffer.EaterParticipant.HasAwaitingMealOffer = true;
            currentMealOffer.EaterParticipant.AwaitingMeals = currentMealOffer;
            currentMealOffer.Date = dateMealDate.SelectedDate.Value;
            currentMealOffer.Time = cmbSetTime.SelectedItem.ToString();


            Console.WriteLine(currentMealOffer.GetType() + " current meal" );
            currentCook.Meals.Add(currentMealOffer);
            Eater.MealOffers++;
            Console.WriteLine("Meal offers = " + Eater.MealOffers);

            Console.WriteLine("Selected time " + cmbSetTime.SelectedItem.ToString());
            Console.WriteLine(currentCook.Meals.Count + " number of meals");


            dbAccess.saveFiles();
            btnCancel_Click(sender, e);
   
            
        }

        private void btnUploadPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select a meal image file to upload.";
            // Show open file dialog box 
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document 
                //currentMealOffer.MealPhoto = new Image();
                imgMeal.Source = new BitmapImage(new Uri(dialog.FileName));

              
                //mealPhotoUploaded = true;
                btnSendOffer.IsEnabled = true;
            }
        }


    }
}
