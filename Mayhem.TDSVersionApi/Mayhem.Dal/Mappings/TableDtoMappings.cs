using AutoMapper;
using Mayhem.Dal.Dto.Dtos;
using Mayhem.Dal.Tables;

namespace Mayhem.Dal.Mappings
{
    public class TableDtoMappings : Profile
    {
        public TableDtoMappings()
        {
            CreateMap<GameVersion, GameVersionDto>()
                .ForMember(x => x.Version, y => y.MapFrom(z => new BuildVersion(z.Version)));
        }
    }
}
