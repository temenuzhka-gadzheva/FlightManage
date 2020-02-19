using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Entity
{
    public class Flight
    {
        public int Id { get; set; }

        public string LocationFrom { get; set; }

        public string LocationTo { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public string AircraftType { get; set; }

        public int AircraftNumber { get; set; }

        public string PilotName { get; set; }

        public int PassengerCapacity { get; set; }

        public int BusinessPassengerCapacity { get; set; }
    }
}
