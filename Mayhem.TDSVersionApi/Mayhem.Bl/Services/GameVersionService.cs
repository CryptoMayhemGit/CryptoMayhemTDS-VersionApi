using Mayhem.Bl.Interfaces;
using Mayhem.Dal.Dto.Dtos;
using Mayhem.Dal.Dto.Requests;
using Mayhem.Dal.Repositories.Interfaces;
using Mayhem.Util.Classes;
using Mayhem.Util.Exceptions;
using Microsoft.Extensions.Logging;

namespace Mayhem.Bl.Services
{
    public class GameVersionService : IGameVersionService
    {
        private readonly IGameVersionRepository gameVersionRepository;
        private readonly ILogger<GameVersionService> logger;

        public GameVersionService(
            IGameVersionRepository gameVersionRepository,
            ILogger<GameVersionService> logger)
        {
            this.gameVersionRepository = gameVersionRepository;
            this.logger = logger;
        }

        public async Task<TicketResponse> GetVersionDetailsAsync()
        {
            IEnumerable<GameVersionDto> gameVersions  = await gameVersionRepository.GetGameVersions();

            GameVersionDto gameVersion = GetLatestVersion(gameVersions);

            if(gameVersion == null)
            {
                string errorMessage = $"Current version is not avalable.";
                logger.LogInformation(errorMessage);
                throw new NotFoundException(new ValidationMessage(ResponseCodes.VersionEmpty, errorMessage));
            }

            return new TicketResponse()
            {
                BuildURL = gameVersion.BuildURL,
                LatestGameVersion = gameVersion.Version.ToString()
            };
        }

        private GameVersionDto GetLatestVersion(IEnumerable<GameVersionDto> gameVersions)
        {
            return gameVersions.OrderByDescending(x => x.Version.Major).ThenByDescending(x => x.Version.Minor).ThenByDescending(x => x.Version.SubMinor).FirstOrDefault();
        }
    }
}
