using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Application.Dtos;

namespace TicketMate.Admin.Application.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserReturn>>
    {
        public GetUsersQueryHandler() { }
        public async Task<IList<UserReturn>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserReturn> userReturn = new List<UserReturn>();
            request.TrainId = "abcd";
            userReturn.Capacity = 10;
            return userReturn;
        }
    }
}
