using System.ComponentModel.DataAnnotations;

namespace Roulette.Entities
{
	public class Player
	{
		[Key]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
