using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Roulette.Enums;
using Roulette.Extensions;
using Roulette.Helpers;
using Roulette.Models;

namespace Roulette.Services
{
	public class RouletteService : IRouletteService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public RouletteService(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Player> GetPlayerById(string id)
		{
			var player = _context.Players.Find(id);
			if (player == null) 
				throw new KeyNotFoundException("Player not found");
			return _mapper.Map<Player>(player);
		}

		public async Task<List<string>> GetPlaceTypes()
		{
			var enumValues = (PlaceType[])Enum.GetValues(typeof(PlaceType));
			return enumValues.Select(x => x.GetDescription()).ToList();
		}

		public async Task<string> PlaceBet(Bet model)
		{
			try
			{
				var entity = new Entities.Bet
				{
					PlayerId = model.PlayerId,
					PlaceType = model.PlaceType,
					Combination = model.Combination,
					BetAmount = model.BetAmount
				};
				_context.Bets.Add(entity);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception("Error occurred: Could not place bet");
			}

			return $"Bet placed by player {model.PlayerId}";
		}

		public async Task<string> Spin()
		{
			int result = 0;

			try
			{
				//get all bets placed not yet allocated to a spin
				var bets = _context.Bets
					.Where(b => b.SpinId == 0)
					.ToList();

				var betAmount = bets.Sum(b => b.BetAmount);
				Random rnd = new Random();
				result = rnd.Next(36);

				var entity = new Entities.Spin
				{ 
					Result = result,
					BetAmount = betAmount
				};
				var entry = _context.Spins.Add(entity);

				await _context.SaveChangesAsync();

				int spinId = entry.Entity.Id;

				foreach (var bet in bets)
				{
					bet.SpinId = spinId;
					var payOff = 36/(int)bet.PlaceType.GetEnumValueFromDescription<PlaceType>();										
					var chosenNrs = bet.Combination.Split(',');
					var match = chosenNrs.FirstOrDefault(n => n == result.ToString());
					if (match != null)
					{
						bet.Match = true;
						bet.Payout = bet.BetAmount * payOff;
					}
					_context.Bets.Update(bet);
				}

				entity = _context.Spins.FirstOrDefault(s => s.Id == spinId);
				if (entity != null)
				{
					entity.PayoutAmount = bets.Where(b => b.Match).Sum(b => b.Payout);
					_context.Spins.Update(entity);
				}
								
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception("Error occurred during spin");
			}

			return $"Spin result = {result}";
		}

		public async Task<string> PayOut(int spinId)
		{
			var entity = _context.Spins.FirstOrDefault(s => s.Id == spinId);
			if (entity != null)
			{
				entity.PaidOut = true;
				_context.Spins.Update(entity);
				await _context.SaveChangesAsync();

				return $"Paid out {entity.PayoutAmount} for spin nr {entity.Id}";
			}
			else
			{
				throw new ArgumentNullException("Spin not found");
			}
		}

		public async Task<List<Spin>> GetSpinHistory()
		{
			var spins = await _context.Spins.ToListAsync();
			return _mapper.Map<List<Spin>>(spins);
		}
	}
}
