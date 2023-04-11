using Roulette.Models;
using Roulette.Services;

namespace RouletteTests
{
	public class RouletteServiceFake : IRouletteService
	{
		private readonly List<string> _placeTypes;
		private readonly Player _player;
		private readonly List<Bet> _bets;
		private readonly List<Spin> _spins;

		public RouletteServiceFake()
		{
			_placeTypes = new List<string>()
			{
				"Single Number",
				"Double Numbers",
				"Three Numbers",
				"Four Numbers",
				"Twelve Numbers",
				"Eighteen Numbers"
			};

			_spins = new List<Spin>()
			{
				new Spin {
					Id = 1,
					Result = 30,
					BetAmount = 20,
					PayoutAmount = 0,
					PaidOut = false
				},
				new Spin {
					Id = 2,
					Result = 7,
					BetAmount = 20,
					PayoutAmount = 0,
					PaidOut = false
				},
				new Spin {
					Id = 3,
					Result = 26,
					BetAmount = 20,
					PayoutAmount = 0,
					PaidOut = false
				},
				new Spin {
					Id = 4,
					Result = 9,
					BetAmount = 20,
					PayoutAmount = 0,
					PaidOut = false
				},
				new Spin {
					Id = 5,
					Result = 2,
					BetAmount = 20,
					PayoutAmount = 720,
					PaidOut = false
				}
			};

			_player = new Player
			{
				Id = "8112085129083",
				Name = "Johan",
				Surname = "Fourie"
			};
		}

		public async Task<Player> GetPlayerById(string id)
		{
			return _player;
		}

		public async Task<List<string>> GetPlaceTypes()
		{
			return _placeTypes;
		}

		public async Task<string> PlaceBet(Bet model)
		{
			model.Id = new Random().Next();
			_bets.Add(model);
			return $"Bet placed by player {_player.Id}";
		}

		public async Task<string> Spin()
		{
			Random rnd = new Random();
			int result = rnd.Next(36);
			var spin = new Spin
			{
				Result = result,
				BetAmount = 1000
			};
			_spins.Add(spin);

			return $"Spin result = {result}";
		}

		public async Task<string> PayOut(int spinId)
		{
			return $"Paid out 1000 for spin nr {spinId}";
		}

		public async Task<List<Spin>> GetSpinHistory()
		{
			return _spins;
		}
	}
}
