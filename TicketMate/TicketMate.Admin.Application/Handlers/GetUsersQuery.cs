using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Application.Dtos;

namespace TicketMate.Admin.Application.Handlers
{
    public class GetUsersQuery : IRequest<IList<UserReturn>>
    {
        public string TrainId { get; set; }
    }
}
