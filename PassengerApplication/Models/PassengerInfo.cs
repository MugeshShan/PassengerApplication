using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApplication.Models
{
    public class PassengerInfo
    {
        public string PassengerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TrainName { get; set; }

        public string TicketCount { get; set; }

        public string Amount { get; set; }

        public string Class { get; set; }

        public string DOB { get; set; }

        public string DOJ { get; set; }

        public string PaymentMode { get; set; }
    }
}
