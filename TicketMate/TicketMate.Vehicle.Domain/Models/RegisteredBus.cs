namespace TicketMate.Vehicle.API.Models
{
    public class RegisteredBus
    {
        public int BusId { get; set; }
        public string BusNo { get; set; }
        public string LicenNo { get; set; }

        public int SetsCount { get; set; }
        public bool ACorNONAC { get; set; }

        //public byte[] LicenseImg { get; set; } // Change data type as per your image storage mechanism
        //public byte[] InsuranceImg { get; set; } // Change data type as per your image storage mechanism

    }
}
