using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApplication.Models
{
    public class Price
    {
        public int Id { get; set; }

        public string Class { get; set; }

        public string Amount { get; set; }

        public int TrainId { get; set; }
    }
}
