using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Vehicle.Domain.Models;

namespace TicketMate.Vehicle.Application.Services
{
    public interface ITrainRaliwaySer
    {
        Task<ActionResult<IEnumerable<TrainRaliway>>> GetTrainRaliways();
        Task<ActionResult<TrainRaliway>> GetTrainRaliway(int id);
        Task<ActionResult<TrainRaliway>> GetTrainRaliwayByNo(int railwayNo);
        Task<ActionResult<TrainRaliway>> PostTrainRaliway(TrainRaliway trainRaliway);
        Task<ActionResult> PutTrainRaliway(int id, TrainRaliway trainRaliway);
        Task<ActionResult> DeleteTrainRaliway(int id);
    }
}
