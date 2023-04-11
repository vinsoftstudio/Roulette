using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Controllers;
using Roulette.Models;
using Roulette.Services;

namespace RouletteTests
{
	public class RouletteControllerTest
	{
		private readonly RouletteController _controller;
		private readonly IRouletteService _service;
		private readonly ILogger<RouletteController> _logger;
		private readonly ILoggerFactory _loggerFactory;

		public RouletteControllerTest()
		{
			_service = new RouletteServiceFake();
			_loggerFactory = new LoggerFactory();
			_logger = new Logger<RouletteController>(_loggerFactory);
			_controller = new RouletteController(_service, _logger);
		}

		[Fact]
		public void GetPlayer_ReturnsPlayer()
		{
			// Arrange
			var playerId = "8112085129083";

			//Act
			var player = _controller.GetPlayer(playerId).Result;

			//Assert
			Assert.IsType<Player>(player);
		}
	}
}