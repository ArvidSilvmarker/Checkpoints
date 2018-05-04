using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Space.Domain
{


    public class Ravioli
    {
        public int Id { get; set; }
        public DateTime PackDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Ravioli(string dateString)
        {
            var dateList = dateString.Split('-', StringSplitOptions.RemoveEmptyEntries);
            var year = Convert.ToInt32(dateList[0]);
            var month = Convert.ToInt32(dateList[1]);
            var day = Convert.ToInt32(dateList[2]);
            PackDate = new DateTime(year, month, day);
            ExpiryDate = new DateTime(year, month, day);
            ExpiryDate = ExpiryDate.AddMonths(6);
            ExpiryDate = ExpiryDate.AddDays(15);
        }

        public Ravioli()
        {
            
        }
    }
}
