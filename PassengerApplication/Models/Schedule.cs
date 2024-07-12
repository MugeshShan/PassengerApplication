using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApplication.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public string ArrivalTime { get; set;}

        public string DepartureTime { get; set; }

        public int TrainId { get; set; }
    }
}
