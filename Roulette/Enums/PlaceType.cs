using System.ComponentModel;

namespace Roulette.Enums
{
	public enum PlaceType
	{
		[Description("Single Number")]
		SingleNumber = 1,

		[Description("Double Numbers")]
		DoubleNumbers = 2,

		[Description("Three Numbers")]
		ThreeNumbers = 3,

		[Description("Four Numbers")]
		FourNumbers = 4,

		[Description("Twelve Numbers")]
		TwelveNumbers = 12,

		[Description("Eighteen Numbers")]
		EighteenNumbers = 18
	}
}
