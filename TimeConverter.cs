using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private const int TotalTimeParts = 3;
        private const int HoursIndex = 0;
        private const int MinutesIndex = 1;
        private const int SecondsIndex = 2;
       
        public string convertTime(string aTime)
        {
            var timeParts = aTime.Split(':');
            if (timeParts.Length != TotalTimeParts)
                throw new ArgumentException("time format should be in hh:mm:ss");

            var strTime = new string[] { getSeconds(Convert.ToInt32(timeParts[SecondsIndex])),
                getFirstRowHours(Convert.ToInt32(timeParts[HoursIndex])),
                getSecondRowHours(Convert.ToInt32(timeParts[HoursIndex])),
                getFirstRowMinutes(Convert.ToInt32(timeParts[MinutesIndex])),
                getSecondRowMinutes(Convert.ToInt32(timeParts[MinutesIndex])) };

            return string.Join(Environment.NewLine , strTime);

        }

        // code for top yellow lamp on or off
        public string getSeconds(int seconds)
        {
            if (seconds % 2 == 0)
                return "Y";
            else
                return "O";
        }

        // code for first hours row lamp on or off
        public string getFirstRowHours(int number)
        {
            return getOnOff(4, getTopNumberOfOnLamps(number), "R");
        }

        // code for second hours row lamp on or off
        public string getSecondRowHours(int number)
        {
            return getOnOff(4, number % 5, "R");
        }

        // code for first minites row lamp on or off
        public string getFirstRowMinutes(int number)
        {
            return getOnOff(11, getTopNumberOfOnLamps(number), "Y").Replace("YYY", "YYR");
        }

        // code for second minite row lamp on or off
        public string getSecondRowMinutes(int number)
        {
            return getOnOff(4, number % 5, "Y");
        }

        // code to get output string for on and off lamps
        public string getOnOff(int totalLamps, int onLamps, string onSign)
        {
            string output = "";
            for(int i = 0; i < onLamps; i++)
            {
                output += onSign;
            }
            
            for(int i = 0; i < (totalLamps - onLamps); i++)
            {
                output += "O";
            }
            return output;
        }

        public int getTopNumberOfOnLamps(int number)
        {
            return (number - (number % 5)) / 5;
        }
    }
}

