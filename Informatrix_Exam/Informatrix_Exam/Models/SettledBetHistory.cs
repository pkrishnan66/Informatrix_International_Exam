using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatrix_Exam.Models
{
    public class SettledBetHistory 
    {
        public int BetCount { get; set; }
        public int WinCount { get; set; }
        public double WinPercent { get; set; }
        public int CustomerId { get; set; }
        /// <summary>
        /// Fetch Settled bets for unusual winning rate...greater than 60%.
        /// </summary>
        /// <returns></returns>
        public List<SettledBetHistory> GetSettledBetHistory()
        {
            SettledBets ReadSettledBets = new SettledBets();
            //Order by Customer...
            var objList = ReadSettledBets.ParseSettleBetCsv().OrderBy(sb => sb.CustomerId).ToList();

            var customers = objList.Select(x => x.CustomerId).Distinct();

            List<SettledBetHistory> objSbhList = new List<SettledBetHistory>();
            foreach (var customer in customers)
            {
                SettledBetHistory objSettleBetHistory = new SettledBetHistory();
                objSettleBetHistory.BetCount = objList.Where(x => x.CustomerId == customer).Count();
                objSettleBetHistory.WinCount = objList.Where(x => x.CustomerId == customer && x.Win > 0).Count();
                objSettleBetHistory.CustomerId = customer;
                objSettleBetHistory.WinPercent = ((double)objSettleBetHistory.WinCount / (double)objSettleBetHistory.BetCount);
                if (objSettleBetHistory.WinPercent >= 0.6)
                {
                    objSettleBetHistory.WinPercent = Math.Round(Convert.ToDouble(objSettleBetHistory.WinPercent * 100), 2); 

                    objSbhList.Add(objSettleBetHistory);
                }
            }

            //Find the Number of Bets for each customer
            return objSbhList;
        }
    }
}