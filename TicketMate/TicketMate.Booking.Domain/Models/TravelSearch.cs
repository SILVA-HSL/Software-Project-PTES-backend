namespace TicketMate.Booking.Api.Models
{
    public class TravelSearch
    {
        public int id { get; set; }
        public string VehicleType { get; set; }
        public string StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public String TravelDate { get; set; }


        /*public TravelSearch()
        {
            if (TravelDate == null)
            {
                TravelDate = DateOnly.FromDateTime(DateTime.Now);
            }
        }
        */
    }
}
