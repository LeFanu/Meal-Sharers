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
        public enum pvg_hygiene_statuses
        {
            None,
            AwaitingResults,
            OK,
            Rejected,
            RenevalWith3months,
        };

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

        private pvg_hygiene_statuses validPVG;
        public pvg_hygiene_statuses ValidPVG
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

        private pvg_hygiene_statuses validHygieneCertificate;
        public pvg_hygiene_statuses ValidHygieneCertificate
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

        private List<Meal> meals = new List<Meal>();
        public List<Meal> Meals
        {
            get
            {
                return meals;
            }

            set
            {
                meals = value;
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

        public DateTime ActiveSince
        {
            get
            {
                return activeSince;
            }

            set
            {
                activeSince = value;
            }
        }
        private DateTime activeSince = new DateTime();

        private DateTime hygieneRenevalDate = new DateTime();
        public DateTime HygieneRenevalDate
        {
            get
            {
                return hygieneRenevalDate;
            }

            set
            {
                hygieneRenevalDate = value;
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
