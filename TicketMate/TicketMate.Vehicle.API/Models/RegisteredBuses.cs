﻿namespace TicketMate.Vehicle.API.Models
{
    public class RegisteredBuses
    {
        public int BusId { get; set; }
        public string BusNo { get; set; }
        public string LicenNo { get; set; }

        public int SetsCount { get; set; }
        public bool ACorNONAC { get; set; }
    }
}
