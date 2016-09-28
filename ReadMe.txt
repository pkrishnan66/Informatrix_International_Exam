            var values = File.ReadAllLines("C:\\Users\\Prashanth\\Documents\\GitHub\\Informatrix_International_Exam\\Informatrix_Exam\\CSVRepository\\Settled.csv")
                                   .Skip(1)
                                    .Select(sb => SettledBets.FromCsv(sb)).ToList();

            var values = File.ReadAllLines("C:\\Users\\Prashanth\\Documents\\GitHub\\Informatrix_International_Exam\\Informatrix_Exam\\Informatrix_Exam\\CsvRepository\\Settled.csv")
                                   .Skip(1)
                                    .Select(sb => SettledBets.FromCsv(sb)).ToList();








            string[] settleBetArray = new string[5];
            settleBetArray = SettledBetRow.Split(',');
             


            SettledBets objSettledBet = new SettledBets();
            objSettledBet.Customer = Convert.ToInt32(settleBetArray[0]);
            objSettledBet.Event = Convert.ToInt32(settleBetArray[1]);
            objSettledBet.Participant =Convert.ToInt32(settleBetArray[2]);
            objSettledBet.Stake = Convert.ToInt32(settleBetArray[3]);
            objSettledBet.Win = Convert.ToInt32(settleBetArray[4]);