using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface ISelectedTrainStationSer
    {
        Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStations();
        Task<ActionResult<SelectedTrainStation>> GetSelectedTrainStation(int id);
        Task<ActionResult<IEnumerable<SelectedTrainStation>>> GetSelectedTrainStationsByScheduledTrainSchedulId(int scheduledTrainSchedulId);
        Task<ActionResult<SelectedTrainStation>> PostSelectedTrainStation(SelectedTrainStation selectedTrainStation);
        Task<ActionResult> PutSelectedTrainStation(int id, SelectedTrainStation selectedTrainStation);
        Task<ActionResult> DeleteSelectedTrainStation(int id);
    }
}
