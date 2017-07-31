using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string ReservationNumber { get; set; }
        public string PmsReservationID { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

    }
}
