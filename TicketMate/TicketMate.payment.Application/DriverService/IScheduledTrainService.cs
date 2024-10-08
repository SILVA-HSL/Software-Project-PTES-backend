﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Application.DriverService
{
    public interface IScheduledTrainService
    {
        Task<IEnumerable<object>> GetScheduledTrainDetailsAsync(bool isCompleted, int Id);

        public void endtraintrip(int id);
    }
}
