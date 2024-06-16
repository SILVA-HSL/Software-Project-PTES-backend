using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Admin.Application.Services
{
    public interface IMapConnections
    {
        //passenger page api's
        public int getBusScheduleId(int busDriveId);
        public int getTrainScheduleid(int trainDriveId);


       

    }
}
