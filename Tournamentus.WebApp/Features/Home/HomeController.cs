using Tournamentus.Core.Business.Participator;
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
        public async Task<IActionResult> Index(ParticipatorList.Query query)
        {
            var response = await _mediator.Send(query);
            return View(response.Result);
        }
    }
}
