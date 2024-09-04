﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Reason { get; set; }
        public string OtherReason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int TotalDays { get; set; }
        public string FamilyAndMedical { get; set; }
        public string FuneralRelationship { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

    }
}
