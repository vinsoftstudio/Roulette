using AutoMapper;

namespace Roulette
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Entities.Bet, Models.Bet>();
			CreateMap<Entities.Player, Models.Player>();
			CreateMap<Entities.Spin, Models.Spin>();
		}
	}
}
