using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Sharers
{
    [Serializable]
    class Cook
    {
        //instance fields with getters and setters
        private String name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private Boolean validPVG = false;
        public bool ValidPVG
        {
            get
            {
                return validPVG;
            }

            set
            {
                validPVG = value;
            }
        }

        private Boolean validHygieneCertificate = false;
        public bool ValidHygieneCertificate
        {
            get
            {
                return validHygieneCertificate;
            }

            set
            {
                validHygieneCertificate = value;
            }
        }

        private List<Eater> eaters;
        public List<Eater> Eaters
        {
            get
            {
                return eaters;
            }

            set
            {
                eaters = value;
            }
        }

        private String phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }


        //constructor
        public Cook() {

        }


        //instance methods

    }
}
