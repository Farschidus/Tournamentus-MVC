using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tournamentus.Core.Contracts;
using Tournamentus.Core.Data;
using Tournamentus.Core.Data.Identity;

namespace Tournamentus.Core.Business.TournamentParticipator
{
    public class TournamentParticipatorList
    {
        public class Query : IRequest<IResponseBase<QueryResult>>
        {
            public int TournoumentId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
        }

        public class QueryResult
        {
            public List<User> Participators { get; set; }
        }

        public class QueryHandler : AbstractHandler<Query, IResponseBase<QueryResult>>
        {
            private readonly TournamentusDb _db;

            public QueryHandler(TournamentusDb db)
            {
                _db = db;
            }

            public override async Task<IResponseBase<QueryResult>> Handle(Query message, CancellationToken cancellationToken)
            {
                var result = new QueryResult();
                var participators = await _db.TournamentParticipators
                    .Include(x => x.User)
                    .Where(x => x.TournamentId == message.TournoumentId)
                    .ToListAsync();

                participators.ForEach(x => result.Participators.Add(new User
                {
                    Id = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    PhoneNumber = x.User.PhoneNumber,
                }));
                

                return Response(result);
            }
        }
    }
}
