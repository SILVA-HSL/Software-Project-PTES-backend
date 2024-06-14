using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface ITrainRaliwayStationSer
    {
        Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStations();
        Task<ActionResult<TrainRaliwayStation>> GetTrainRaliwayStation(int id);
        Task<ActionResult<IEnumerable<TrainRaliwayStation>>> GetTrainRaliwayStationsByRaliwayId(int trainRaliwayId);
        Task<ActionResult<TrainRaliwayStation>> PostTrainRaliwayStation(TrainRaliwayStation trainRaliwayStation);
        Task<ActionResult> PutTrainRaliwayStation(int id, TrainRaliwayStation trainRaliwayStation);
        Task<ActionResult> DeleteTrainRaliwayStation(int id);
    }
}
