using AutoMapper;
using Mayhem.Dal.Context;
using Mayhem.Dal.Dto.Dtos;
using Mayhem.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mayhem.Dal.Repositories.Services
{
    public class GameVersionRepository : IGameVersionRepository
    {
        private readonly MayhemDataContext mayhemDataContext;
        private readonly IMapper mapper;

        public GameVersionRepository(MayhemDataContext mayhemDataContext, IMapper mapper)
        {
            this.mayhemDataContext = mayhemDataContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GameVersionDto>> GetGameVersions() => await mayhemDataContext
                .GameVersions
                .AsNoTracking()
                .Select(x => mapper.Map<GameVersionDto>(x))
                .ToListAsync();
    }
}
