using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Managements_app.Calculations
{
    internal class Calculations
    {
        public double finalPrice;
        public double calculateMembeshipFee(string paymentType, string membershipType, double membershipTypePrice, string personalTraining, double personalTrainingPrice)
        {
            // individual = 4000, per month
            // family = 12000 per month
            // couple = 6000 per month
            // if personal trainig is yes add 4000 more
            // if the payment method is per year multiply and give 25% off discount

            // double finalPrice;

            if (paymentType == "monthly")
            {
                if(membershipType == "Individual" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice; 
                } 
                else if (membershipType == "Individual" && personalTraining == "no") 
                {
                    finalPrice = membershipTypePrice;
                }

                if (membershipType == "Family" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice;
                } else if (membershipType == "Family" && personalTraining == "no")
                {
                    finalPrice = membershipTypePrice;
                }

                if(membershipType == "Couple" && personalTraining == "yes")
                {
                    finalPrice = membershipTypePrice + personalTrainingPrice;
                } else if (membershipType == "Couple" && personalTraining == "no")
                {
                    finalPrice = membershipTypePrice;
                }
            } else
            {
                if (membershipType == "Individual" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Individual" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }

                if (membershipType == "Family" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Family" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }

                if (membershipType == "Couple" && personalTraining == "yes")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25)) + (personalTrainingPrice * 12);
                }
                else if (membershipType == "Couple" && personalTraining == "no")
                {
                    finalPrice = ((membershipTypePrice * 12) - ((membershipTypePrice / 100) * 25));
                }
            }
            return finalPrice; 
        }
    }
}
