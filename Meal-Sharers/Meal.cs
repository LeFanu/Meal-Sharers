using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Sharers
{
    class Meal
    {
        //instance fields with getters and setters
        private Cook cookParticipant;
        private Eater eaterParticipant;
        private DateTime date = new DateTime();
        private DateTime time;
        private string cookComments;
        private string eaterComments;
        private string administratorComments;
        private string messageToEater;
        private bool hasMessage = false;

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

        public bool HasMessage
        {
            get
            {
                return hasMessage;
            }

            set
            {
                hasMessage = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return Date;
            }

            set
            {
                Date = value;
            }
        }



        public Meal ()
        {

        }


    }
}
