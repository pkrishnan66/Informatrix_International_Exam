using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


    public class SettledBetsTest
    {
        public int CustomerId { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }

        /// <summary>
        /// Parse the CSV for the settle Bets Information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SettledBetsTest> ParseSettleBetCsv()
        {
            List<SettledBetsTest> listSettledBets = new List<SettledBetsTest>();

            string settleBetsFile = "C:\\Users\\Prashanth\\Documents\\GitHub\\Informatrix_International_Exam\\Informatrix_Exam\\Informatrix_Exam\\CsvRepository\\Settled.csv";
            var settleBetFile = System.IO.File.ReadAllLines(settleBetsFile)
                      .Skip(1)
                      .ToList();

            //Create the Array 
            foreach (var settleBetRow in settleBetFile)
            {
                string[] settleBetArray = new string[5];
                settleBetArray = settleBetRow.Split(',');


                SettledBetsTest objSettledBet = new SettledBetsTest();
                objSettledBet.CustomerId = Convert.ToInt32(settleBetArray[0]);
                objSettledBet.Event = Convert.ToInt32(settleBetArray[1]);
                objSettledBet.Participant = Convert.ToInt32(settleBetArray[2]);
                objSettledBet.Stake = Convert.ToInt32(settleBetArray[3]);
                objSettledBet.Win = Convert.ToInt32(settleBetArray[4]);

                listSettledBets.Add(objSettledBet);
            }
            return listSettledBets;
        }
    }
