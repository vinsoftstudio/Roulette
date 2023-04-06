using System.ComponentModel.DataAnnotations;

namespace Roulette.Entities
{
	public class PlaceTypeCombination
	{
		[Key]
		public int Id { get; set; }
		public int PlaceTypeId { get; set; }
		public string Combination { get; set; }
	}
}
