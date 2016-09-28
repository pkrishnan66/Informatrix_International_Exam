using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Informatrix_Exam.Models
{
    public class UnSettledBets
    {
        public int CustomerId { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }


        /// <summary>
        /// Parse the CSV for the UnSettle Bets Information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnSettledBets> ParseUnSettledBetCsv()
        {
            List<UnSettledBets> listUnSettledBets = new List<UnSettledBets>();

            string unSettleBetsFile = ConfigurationManager.AppSettings["UnSettledBetCsv"].ToString();
            var unSettleBetFile = System.IO.File.ReadAllLines(unSettleBetsFile)
                      .Skip(1)
                      .ToList();

            //Create the Array 
            foreach (var unSettleBetRow in unSettleBetFile)
            {
                string[] settleBetArray = new string[5];
                settleBetArray = unSettleBetRow.Split(',');


                UnSettledBets objUnSettledBet = new UnSettledBets();
                objUnSettledBet.CustomerId = Convert.ToInt32(settleBetArray[0]);
                objUnSettledBet.Event = Convert.ToInt32(settleBetArray[1]);
                objUnSettledBet.Participant = Convert.ToInt32(settleBetArray[2]);
                objUnSettledBet.Stake = Convert.ToInt32(settleBetArray[3]);
                objUnSettledBet.Win = Convert.ToInt32(settleBetArray[4]);

                listUnSettledBets.Add(objUnSettledBet);
            }
            return listUnSettledBets;
        }
        /// <summary>
        /// All Bets where then Unsettled Amount to be won is greater is 1000 or More
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnSettledBets> GetHighestRiskBets()
        {
            UnSettledBets objUnsettledBets = new UnSettledBets();
            var lstUnSettledBets = objUnsettledBets.ParseUnSettledBetCsv().Where(x => x.Win > 1000).ToList();
            lstUnSettledBets.OrderByDescending(x => x.CustomerId).ToList();
            return lstUnSettledBets;
        }


        public IEnumerable<UnSettledBets> GetUsualHighlyUnsualBets(int stakeIncrease)
        {
            SettledBets ReadSettledBets = new SettledBets();
            UnSettledBets objUnsettledBets = new UnSettledBets();
            //Order by Customer...
            var lstSettledBets = ReadSettledBets.ParseSettleBetCsv().OrderBy(sb => sb.CustomerId).ToList();
            var lstUnSettledBets = objUnsettledBets.ParseUnSettledBetCsv().OrderBy(usb => usb.CustomerId).ToList();

            var customersSettledStake = lstSettledBets.Select(x => x.CustomerId).Distinct();
            List<UnSettledBets> unSettledRiskBets = new List<UnSettledBets>();


            foreach (var customer in customersSettledStake)
            {
                var stakes = lstSettledBets.Where(x => x.CustomerId == customer).Sum(x => x.Stake);
                var betCount = lstSettledBets.Where(x => x.CustomerId == customer).Count();
                var averageStake = ((double)stakes / (double)betCount);

                //Stake increase percentage...
                double customerAverageStake = Math.Round(Convert.ToDouble(averageStake * stakeIncrease), 2);

                //Iterate for each customer...
                var unSettledCutomers = lstUnSettledBets.Where(x => x.CustomerId == customer);
                foreach (var unSettledCustomer in unSettledCutomers)
                {
                    if ((double)unSettledCustomer.Stake >(double)customerAverageStake)
                    {
                        unSettledRiskBets.Add(unSettledCustomer);
                    }
                }

            }
            unSettledRiskBets.OrderBy(x => x.CustomerId);
            return unSettledRiskBets;

        }

    }
}