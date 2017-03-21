using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Sharers
{
    [Serializable]
    public class Cook
    {
        //Instance fields with getters and setters
        private static int orderNumberCount = 0;
        public static int OrderNumberCount
        {
            get
            {
                return Cook.orderNumberCount;
            }

            set
            {
                Cook.orderNumberCount = value;
            }
        }

        private int orderNumber;
        public int OrderNumber
        {
            get
            {
                return orderNumber;
            }

            set
            {
                orderNumber = value;
            }
        }

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

        private String city;
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }





        //constructor
        public Cook() {

        }


        //instance methods
        public int calculateOrderCount()
        {
            return orderNumberCount++;
        }
    }
}
