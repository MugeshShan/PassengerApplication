using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApplication.Models
{
    public class Trains
    {
        public int Id { get; set; }
        public string TrainName { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public List<string> ArrivalTimings { get; set; }

        public List<string> DepatureTimings { get; set; }

        //public int PlatformNumber { get; set; }
    }
}
