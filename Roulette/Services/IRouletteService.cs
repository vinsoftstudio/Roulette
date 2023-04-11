using Roulette.Models;

namespace Roulette.Services
{
	public interface IRouletteService
	{
		Task<List<string>> GetPlaceTypes();
		Task<Player> GetPlayerById(string id);
		Task<string> PlaceBet(Models.Bet model);
		Task<string> Spin();
		Task<string> PayOut(int spinId);
		Task<List<Spin>> GetSpinHistory();
	}
}
