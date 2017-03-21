using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Sharers
{
    [Serializable]
    public class Administrator
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
    }
}
