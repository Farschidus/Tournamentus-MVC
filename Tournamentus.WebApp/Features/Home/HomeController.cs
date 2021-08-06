using Tournamentus.Core.Business.TournamentParticipator;
using Tournamentus.WebApp.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tournamentus.WebApp.Features.Home
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(TournamentParticipatorList.Query query)
        {
            var response = await _mediator.Send(query);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ParticipatorList", response.Result);
            }

            return View(response.Result);
        }
    }
}
