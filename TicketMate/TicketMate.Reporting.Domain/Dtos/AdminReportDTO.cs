namespace TicketMate.Reporting.Domain.Dtos
{
    public class AdminReportDTO
    {
        
    public string VehicleOwner { get; set; }
        public string VehicleNo { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalPassengers { get; set; }
        public DateTime Date { get; set; }
        public double AverageRate { get; set; }
        public decimal MonthlyTotalPredictedIncome { get; set; }
    
}
}
