using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.API.Models
{
    public class RegisteredBus
    {
        [Key]
        public int BusId { get; set; }
        public string BusNo { get; set; }
        public string LicenNo { get; set; }
        public int SetsCount { get; set; }
        public bool ACorNONAC { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LicenseImgURL { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string InsuranceImgURL { get; set; }

        [JsonIgnore]
        public List<SelectedSeatStructure>? SelectedSeatStructures { get; set; }
        [JsonIgnore]
        public List<ScheduledBus>? ScheduledBuses { get; set; }
    }
}
