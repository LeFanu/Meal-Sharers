using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Meal_Sharers
{
    [Serializable]
    public class Meal
    {
        //instance fields with getters and setters
        private Cook cookParticipant;
        private Eater eaterParticipant;
        private DateTime date = new DateTime();
        private String time;
        private string cookComments;
        private string eaterComments;
        private string administratorComments;
        private string messageToEater;
        private bool offerAccepeted = false;

        private byte[]  mealPhoto = new byte[10000000];

        public Cook CookParticipant
        {
            get
            {
                return cookParticipant;
            }

            set
            {
                cookParticipant = value;
            }
        }

        public Eater EaterParticipant
        {
            get
            {
                return eaterParticipant;
            }

            set
            {
                eaterParticipant = value;
            }
        }

        public string CookComments
        {
            get
            {
                return cookComments;
            }

            set
            {
                cookComments = value;
            }
        }

        public string EaterComments
        {
            get
            {
                return eaterComments;
            }

            set
            {
                eaterComments = value;
            }
        }

        public string AdministratorComments
        {
            get
            {
                return administratorComments;
            }

            set
            {
                administratorComments = value;
            }
        }

        public string MessageToEater
        {
            get
            {
                return messageToEater;
            }

            set
            {
                messageToEater = value;
            }
        }

        public bool OfferAccepeted
        {
            get
            {
                return offerAccepeted;
            }

            set
            {
                offerAccepeted = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public byte[] MealPhoto
        {
            get
            {
                return mealPhoto;
            }

            set
            {
                mealPhoto = value;
            }
        }

        public Meal ()
        {

        }


    }
}
