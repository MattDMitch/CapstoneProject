using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasperGreen.Models
{
    public class Check
    {
        //checks for unique values when adding/editing crew
        public static string UniqueCrew(JasperGreenContext context, int crew1, int crew2, int crew3)
        {
            string message = "";

            if(!(crew1 != crew2 && crew1 != crew3 && crew2 != crew3))
            {
                message = "Duplicate names selected. Please ensure each member of the crew is different.";
            }

            return message;
        }

        //checks that service fee entered is greater than or equal to the service fee stored with the associated property 
        public static string ServiceFeeCheck(JasperGreenContext context, int propertyID, decimal ServiceFee)
        {
            string message = "";
            var property = context.Properties.FirstOrDefault(p => p.PropertyID == propertyID);

            if (property != null)
            {
                if (ServiceFee < property.ServiceFee)
                {
                    message = $"Service Fee must be greater than or equal to the service fee stored with the associated property: ${property.ServiceFee}";
                }
            }

            return message;
        }
    }
}
