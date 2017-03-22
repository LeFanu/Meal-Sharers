using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Sharers
{
    [Serializable]
    public class Eater
    {
        private static int mealOffers = 0;
        public static int MealOffers
        {
            get
            {
                return mealOffers;
            }

            set
            {
                mealOffers = value;
            }
        }

        //Instance fields with getters and setters
        private static int orderNumberCount = 0;
        public static int OrderNumberCount
        {
            get
            {
                return Eater.orderNumberCount;
            }

            set
            {
                Eater.orderNumberCount = value;
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

        private int age;
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        private bool hasDisability = false;
        public bool HasDisability
        {
            get
            {
                return hasDisability;
            }

            set
            {
                hasDisability = value;
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

        private bool hasAwaitingMealOffer = false;
        public bool HasAwaitingMealOffer
        {
            get
            {
                return hasAwaitingMealOffer;
            }

            set
            {
                hasAwaitingMealOffer = value;
            }
        }

        private String mealPreferences;
        public string MealPreferences
        {
            get
            {
                return mealPreferences;
            }

            set
            {
                mealPreferences = value;
            }
        }

        public Meal AwaitingMeals
        {
            get
            {
                return awaitingMeals;
            }

            set
            {
                awaitingMeals = value;
            }
        }


        private Meal awaitingMeals = new Meal();

        public int calculateOrderCount()
        {
            return orderNumberCount++;
        }
        
        public Eater()
        {

        }


    }
}
