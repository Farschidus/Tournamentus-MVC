using Microsoft.AspNetCore.Mvc;
using System;

namespace Tournamentus.WebApp.Features.Diagnostic
{
    public class DiagnosticsController : Controller
    {
        [HttpGet]
        public static IActionResult Error()
        {
            throw new Exception("This is a server error");
        }
    }
}
