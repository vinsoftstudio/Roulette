using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Entities
{
	public class Bet
	{
		[Key]
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public int SpinId { get; set; }
		public string PlaceType { get; set; }
		public string Combination { get; set; }
		public decimal BetAmount { get; set; }
		public bool Match { get; set; }
		public decimal Payout { get; set; }
	}
}
