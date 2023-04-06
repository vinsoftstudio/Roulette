using System.ComponentModel.DataAnnotations;

namespace Roulette.Entities
{
	public class Spin
	{
		[Key]
		public int Id { get; set; }
		public int Result { get; set; }
		public decimal BetAmount { get; set; }
		public decimal PayoutAmount { get; set; }
		public bool PaidOut { get; set; }
	}
}
