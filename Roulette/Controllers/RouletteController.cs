using Microsoft.AspNetCore.Mvc;
using Roulette.Models;
using Roulette.Services;

namespace Roulette.Controllers
{
	[ApiController]
	[Route("roulette")]
	public class RouletteController : Controller
	{
		private IRouletteService _service;
		private readonly ILogger<RouletteController> _logger;

		public RouletteController(IRouletteService service, ILogger<RouletteController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpPut("get-player/{id}", Name = "GetPlayer")]
		public async Task<ActionResult<Player>> GetPlayer(string id)
		{
			var player = await _service.GetPlayerById(id);
			return Json(player);
		}

		[HttpGet("place-types", Name = "GetPlaceTypes")]
		public async Task<ActionResult<List<string>>> GetPlaceTypes()
		{
			var placeTypes = await _service.GetPlaceTypes();
			return Json(placeTypes);
		}

		[HttpPost("place-bet", Name = "PlaceBet")]
		public async Task<ActionResult<string>> PlaceBet([FromBody] Bet model)
		{
			var response = await _service.PlaceBet(model);
			return Json(response);
		}

		[HttpPost("spin", Name = "Spin")]
		public async Task<ActionResult<string>> Spin()
		{
			var response = await _service.Spin();
			return Json(response);
		}

		[HttpPut("payout/{id}", Name = "PayOut")]
		public async Task<ActionResult<string>> PayOut(int id)
		{
			var response = await _service.PayOut(id);
			return Json(response);
		}

		[HttpGet("get-spin-history", Name = "GetSpinHistory")]
		public async Task<ActionResult<List<Spin>>> GetSpinHistory()
		{
			var spins = await _service.GetSpinHistory();
			return Json(spins);
		}
	}
}