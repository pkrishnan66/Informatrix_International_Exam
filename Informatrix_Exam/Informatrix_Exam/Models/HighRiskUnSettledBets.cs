using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatrix_Exam.Models
{
    public class HighRiskUnSettledBets : UnSettledBets
    {

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