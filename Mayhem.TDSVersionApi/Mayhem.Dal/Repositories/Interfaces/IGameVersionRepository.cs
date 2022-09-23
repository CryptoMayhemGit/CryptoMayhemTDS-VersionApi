using Mayhem.Dal.Dto.Dtos;

namespace Mayhem.Dal.Repositories.Interfaces
{
    public interface IGameVersionRepository
    {
        Task<IEnumerable<GameVersionDto>> GetGameVersions();
    }
}
