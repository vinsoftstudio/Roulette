using FakeItEasy;
using Microsoft.Extensions.Logging;
using Roulette.Controllers;
using Roulette.Services;

namespace RouletteTests
{
	[TestClass]
	public class RouletteTests
	{
		[TestMethod]
		public async void TestGetSpinHistory()
		{
			//Arrange
			var service = A.Fake<IRouletteService>();
			var logger = A.Fake<ILogger<RouletteController>>();
			var controller = new RouletteController(service, logger);

			//Act
			var actionResult = await controller.GetSpinHistory(); 

			//Assert
		}
	}
}