using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerApplication.Models
{
    public class Utility
    {
        public static Passengers Customer = new Passengers();

        public static List<Trains> TrainsList = new List<Trains>();

        public static Trains Train = new Trains();

        public static Trains SelectedTrain = new Trains();

        public static int Price { get; set; }

        public static int Count { get; set; }

        public static DateTime JourneyDate { get; set; }

        public static string Class { get; set; }

        public static Employee Employee = new Employee();
    }
}
