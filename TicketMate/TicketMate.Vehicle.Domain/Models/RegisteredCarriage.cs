using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class RegisteredCarriage
    {
        [Key]
        public int CarriageId { get; set; }
        public string CarriageNo { get; set; }
        public int CarriageClass { get; set; }
        public int SeatsCount { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        [JsonIgnore]
        public List<SelCarriageSeatStructure>? SelCarriageSeatStructures { get; set; }

        [JsonIgnore]
        public List<ScheduledCarriage>? ScheduledCarriages { get; set; }
    }
}
