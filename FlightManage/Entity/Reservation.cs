using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Entity
{
    public class Reservation
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int PersonalNumber { get; set; }

        public int TelephoneNumber { get; set; }

        public string Nationality { get; set; }

        public int TicketNumber { get; set; }
    }
}
