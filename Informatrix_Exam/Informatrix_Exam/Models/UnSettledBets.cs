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
            return lstUnSettledBets;
        }


        public void GetMidLevelStake()
        {
            SettledBets ReadSettledBets = new SettledBets();
            //Order by Customer...
            var objList = ReadSettledBets.ParseSettleBetCsv().OrderBy(sb => sb.CustomerId).ToList();
            var customers = objList.Select(x => x.CustomerId).Distinct();

            foreach (var customer in customers)
            {
                var stakes = objList.Where(x => x.CustomerId == customer).Sum(x => x.Stake);
            }

        }

    }
}