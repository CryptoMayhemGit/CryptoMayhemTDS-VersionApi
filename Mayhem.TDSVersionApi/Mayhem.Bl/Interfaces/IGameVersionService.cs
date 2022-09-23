using Mayhem.Dal.Dto.Requests;

namespace Mayhem.Bl.Interfaces
{
    public interface IGameVersionService
    {
        Task<TicketResponse> GetVersionDetailsAsync();
    }
}
